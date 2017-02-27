import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';

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
            let urlParams: URLSearchParams = this.formParams(params);
            //urlParams.set()
            return this._http.get(this.fullUrl, urlParams);
        } else {
            return this._http.get(this.fullUrl);
        }
    }

    // NOT WORK!!!
    formParams(params): URLSearchParams {
        let urlParams: URLSearchParams = new URLSearchParams();

        let properties: string[] = Object.getOwnPropertyNames(params);

        properties.forEach(prop => {
            urlParams.append(prop, params[prop]);
        });

        return urlParams;
    }


    handleError(error: Response | any): Promise<any> {
  
        /*
        if (error instanceof Response) {
            let body = error.json() || '';
            
        }
        */

        console.log(error);


        return Promise.reject(error);
    }


}