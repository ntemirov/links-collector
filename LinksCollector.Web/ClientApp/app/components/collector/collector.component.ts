import { Component, ViewContainerRef } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Angular2PromiseButtonModule } from 'angular2-promise-buttons/dist';

@Component({
    selector: 'collector',
    templateUrl: './collector.component.html',
    styleUrls: ['./collector.component.css']
})
export class CollectorComponent {
    protected collector: FormGroup;

    protected getButtonPromice;

    constructor(public toastr: ToastsManager, vcr: ViewContainerRef, private fb: FormBuilder) {
        this.toastr.setRootViewContainerRef(vcr);
        this.createCollectorForm();
    }

    protected getLinks(event) {
        this.getButtonPromice = new Promise((resolve, reject) => {
            this.toastr.success('You are awesome!', 'Success!');
            setTimeout(resolve, 2000);
        });
    }

    protected createCollectorForm() {
        this.collector = this.fb.group({
            url: ['', [
                Validators.required,
                this.urlValidator(/^http(s?):\/\/(www\.)?(((\w+(([\.\-]{1}([a-z]{2,})+)+)(\/[a-zA-Z0-9\_\=\?\&\.\#\-\W]*)*$)|(\w+((\.([a-z]{2,})+)+)(\:[0-9]{1,5}(\/[a-zA-Z0-9\_\=\?\&\.\#\-\W]*)*$)))|(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}(([0-9]|([1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]+)+)(\/[a-zA-Z0-9\_\=\?\&\.\#\-\W]*)*)((\:[0-9]{1,5}(\/[a-zA-Z0-9\_\=\?\&\.\#\-\W]*)*$)*))$/)]
            ]
        });

        this.collector.valueChanges
            .subscribe(data => this.onCollectorValueChanged(data));

        this.onCollectorValueChanged();
    }

    protected urlValidator(urlRe: RegExp): ValidatorFn {
        return (control: AbstractControl): { [key: string]: any } => {
            const url = control.value;
            if (url.length == 0) {
                return null;
            }
            const yes = urlRe.test(url);
            return !yes ? { 'url': { url } } : null;
        };
    }

    protected onCollectorValueChanged(data?: any) {
        if (!this.collector) {
            return;
        }
        const form = this.collector;
        for (const field in this.collectorFormErrors) {
            // clear previous error message (if any)
            this.collectorFormErrors[field] = '';
            const control = form.get(field);
            if (control && control.dirty && !control.valid) {
                const messages = this.collectorValidationMessages[field];
                for (const key in control.errors) {
                    this.collectorFormErrors[field] += messages[key] + ' ';
                }
            }
        }
    }

    protected collectorFormErrors = {
        'url': ''
    };

    collectorValidationMessages = {
        'url': {
            'required': 'Url is required',
            'url': 'Url is not valid'
        }
    };
}
