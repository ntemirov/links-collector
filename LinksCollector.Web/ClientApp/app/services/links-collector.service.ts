import { Injectable, Inject } from "@angular/core";
import { CollectLinksResult } from "../models/collect-links-result";
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class LinksCollectorService {
    private urls = {
        getLinksUrl: '/api/LinksCollector/GetLinks?url='
    }

    constructor(private http: Http, @Inject('ORIGIN_URL') private originUrl: string) { }

    public getLinks(url: string): Promise<CollectLinksResult> {
        return this.http.get(`${this.originUrl}${this.urls.getLinksUrl}${url}`)
            .map(res => res.json() as CollectLinksResult)
            .toPromise();
    }
}