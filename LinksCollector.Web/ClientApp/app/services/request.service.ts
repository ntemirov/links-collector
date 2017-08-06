import { Injectable, Inject } from '@angular/core';
import { Headers, Http, RequestOptions, BaseRequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Request } from '../models/request'

@Injectable()
export class RequestService {
    private urls = {
        findUrl: '/api/Request/Find',
        patchUrl: '/api/Request/SetProcessingTime',
        deleteUrl: '/api/Request/Delete'
    }

    constructor(private http: Http, @Inject('ORIGIN_URL') private originUrl: string) { }

    public getRequests(skip: number, limit: number, urlTerm: string): Promise<Request[]> {
        return this.http.get(`${this.originUrl}${this.urls.findUrl}?skip=${skip}&limit=${limit}&urlTerm=${urlTerm}`)
            .map(res => res.json() as Request[])
            .toPromise();
    }

    public setProcessingTime(request: Request): Promise<number> {
        let req = {
            Id: request.id,
            RequestProcessingTime: request.requestProcessingTime
        };

        return this.http.patch(`${this.originUrl}${this.urls.patchUrl}`, request)
            .map(res => res.json())
            .toPromise();
    }

    public deleteRequest(id: number): Promise<number> {
        return this.http.delete(`${this.originUrl}${this.urls.deleteUrl}?id=${id}`)
            .map(res => res.json())
            .toPromise();
    }
}