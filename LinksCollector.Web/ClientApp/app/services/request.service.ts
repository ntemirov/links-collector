import { Injectable, Inject } from "@angular/core";
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class LinksCollectorService {
    private urls = {
        findUrl: '/api/RequestController/Find',
        patchUrl: 'api/RequestController/Patch'
    }

    constructor(private http: Http, @Inject('ORIGIN_URL') private originUrl: string) { }

    public find(): Promise<Request[]> {
        return this.http.get(`${this.originUrl}${this.urls.findUrl}`)
            .map(res => res.json() as Request[])
            .toPromise();
    }

    public update(request: Request): void {
        this.http.patch(`${this.originUrl}${this.urls.patchUrl}`, request);
    }
}