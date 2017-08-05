import { Injectable } from "@angular/core";
import { Link } from "../models/link";
import { Http } from "@angular/http";
import 'rxjs/add/operator/toPromise';

@Injectable()
export class CollectorService {
    private urls = {
        getLinksUrl: 'LinksCollector/GetLinks'
    }

    constructor(private http: Http) { }

    public getLinks(url: string): Promise<Link[]> {
        return this.http.get(this.urls.getLinksUrl, url)
            .toPromise()
            .then(response => response.json().data as Link[])
            .catch();
    }
}