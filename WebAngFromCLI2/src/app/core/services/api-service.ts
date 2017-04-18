import { Injectable } from '@angular/core';

import { Http, Response, Headers, RequestOptions, URLSearchParams, RequestOptionsArgs } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class ApiService {

    private baseUrl: string;

    protected entityUrl: string;

    public get fullUrl(): string {
        return this.baseUrl + this.entityUrl;
    }

    constructor(private _http: Http) {
        this.baseUrl = 'http://localhost:52211/';
    }

    callGet(params = null) {
        if (params != null) {
            let urlParams = this.objectToParams(params);

            return this._http.get(this.fullUrl + '/?' + urlParams);
        } else {
            return this._http.get(this.fullUrl);
        }
    }

    private IsObject(item: any): boolean {
        if (item instanceof Object) {
            return true;
        } else {
            return false;
        }
    }

    private objectToParams(object): string {
        let result = Object.keys(object).map((key) => this.IsObject(object[key]) ?
            this.subObjectToParams(encodeURIComponent(key), object[key]) :
            `${encodeURIComponent(key)}=${encodeURIComponent(object[key])}`
        ).join('&');

        return result;
    }

    private subObjectToParams(key, object): string {
        let result = Object.keys(object).map((childKey) => this.IsObject(object[childKey]) ?
            this.subObjectToParams(`${key}[${encodeURIComponent(childKey)}]`, object[childKey]) :
            `${key}[${encodeURIComponent(childKey)}]=${encodeURIComponent(object[childKey])}`
        ).join('&');

        return result;
    }

    callPost(body: any) {
        return this._http.post(this.fullUrl, body);
    }

    callPut(body: any) {
        return this._http.put(this.fullUrl, body);
    }

    callDelete() {
        return this._http.delete(this.fullUrl);
    }

    handleError(error: Response | any): Promise<any> {
        console.log(error);

        return Promise.reject(error);
    }

}