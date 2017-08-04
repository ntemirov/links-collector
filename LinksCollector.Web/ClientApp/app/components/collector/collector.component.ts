import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';

@Component({
    selector: 'collector',
    templateUrl: './collector.component.html',
    styleUrls: ['./collector.component.css']
})
export class CollectorComponent {
    protected collector: FormGroup;

    constructor(private fb: FormBuilder) {
        this.createCollectorForm();
    }

    protected createCollectorForm() {
        this.collector = this.fb.group({
            url: ['', [
                Validators.required,
                Validators.minLength(4),
                this.urlValidator(/^http(s?):\/\/(www\.)?(((\w+(([\.\-]{1}([a-z]{2,})+)+)(\/[a-zA-Z0-9\_\=\?\&\.\#\-\W]*)*$)|(\w+((\.([a-z]{2,})+)+)(\:[0-9]{1,5}(\/[a-zA-Z0-9\_\=\?\&\.\#\-\W]*)*$)))|(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}(([0-9]|([1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]+)+)(\/[a-zA-Z0-9\_\=\?\&\.\#\-\W]*)*)((\:[0-9]{1,5}(\/[a-zA-Z0-9\_\=\?\&\.\#\-\W]*)*$)*))$/)]
            ]
        })
    }

    protected urlValidator(urlRe: RegExp): ValidatorFn {
        return (control: AbstractControl): { [key: string]: any } => {
            const url = control.value;
            const yes = urlRe.test(url);
            return !yes ? { 'url': { url } } : null;
        };
    }
}
