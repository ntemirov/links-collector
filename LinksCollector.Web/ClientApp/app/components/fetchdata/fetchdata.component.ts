import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Angular2PromiseButtonModule } from 'angular2-promise-buttons/dist';
import { RequestService } from "../../services/request.service";
import { Request } from "../../models/request";
import { Observable } from 'rxjs/Observable';
import { Subject } from "rxjs/Subject";
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html',
    styleUrls: ['./fetchdata.component.css']
})
export class FetchDataComponent implements OnInit {
    protected requests: Request[];
    
    protected deleteButtonPromice;
    
    protected limit = 15;

    protected urlTerm: string = '';
    protected urlTermSub = new Subject<string>();
    protected infiniteScrollDisabled: boolean = false;

    constructor(private requestService: RequestService) {
        requestService.getRequests(0, this.limit, this.urlTerm)
            .then(requests => {
                this.requests = requests;
            })
            .catch(err => {
                // TODO: Add unexpected error handling
                console.log(err);
            });
    }

    ngOnInit() {
        this.urlTermSub
            .debounceTime(300)
            .distinctUntilChanged()
            .subscribe(urlTerm => {
                this.urlTerm = urlTerm;

                this.requestService.getRequests(0, this.limit, this.urlTerm)
                    .then(requests => {
                        this.requests = requests;
                    })
                    .catch(err => {
                        // TODO: Add unexpected error handling
                        console.log(err);
                    });
            });
    }

    protected loadMore() {
        this.requestService.getRequests(this.requests.length, this.limit, this.urlTerm)
            .then(requests => {
                this.requests = this.requests.concat(requests);
                if (requests.length < this.limit) {
                    this.infiniteScrollDisabled = true;
                }
            })
            .catch(err => {
                // TODO: Add unexpected error handling
                console.log(err);
            });
    }

    protected search(term: string): void {
        this.urlTermSub.next(term);
    }

    protected deleteRequest(request: Request) {
        this.deleteButtonPromice = this.requestService.deleteRequest(request.id)
            .then(result => {
                if (result == 1) {
                    this.requests.splice(this.requests.indexOf(request), 1);
                }
            })
            .catch(err => {
                // TODO: Add unexpected error handling
                console.log(err);
            });
    }
}
