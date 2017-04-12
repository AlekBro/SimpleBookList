import { Injectable } from '@angular/core';

import { Http, Response, Headers, RequestOptions, URLSearchParams, RequestOptionsArgs } from '@angular/http';

//import{isJsObject} from '@angular/core/'

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
            //let urlParams: URLSearchParams = this.formParams(params);

            /*
            let searchParams = new URLSearchParams();
            for (let key in params) {
                searchParams.set(key, params[key]);
            }
            */

            /*
            // https://hassantariqblog.wordpress.com/2016/12/03/angular2-http-get-with-complex-object-as-query-string-term-using-observable-in-angular-2-application/
            let urlSearchParams: URLSearchParams = new URLSearchParams();
            for (var key in params) {
                if (params.hasOwnProperty(key)) {
                    let val = params[key];

                    if (val instanceof Array) {
                        val.forEach((item, index) => {
                            urlSearchParams.append(key, item);
                        });

                    } else {
                        urlSearchParams.set(key, val);
                    }
                }
            }

            let options = new RequestOptions({
                search: urlSearchParams
            });

            return this._http.get(this.fullUrl, options);
            */

            let urlParams = this.objectToParams(params);

            return this._http.get(this.fullUrl + '/?' + urlParams);

        } else {
            return this._http.get(this.fullUrl);
        }
    }


    IsObject(item: any): boolean {
        if (item instanceof Object) {
            return true;
        } else {
            return false;
        }
    }

    objectToParams(object): string {
        let result = Object.keys(object).map((key) => this.IsObject(object[key]) ?
            this.subObjectToParams(encodeURIComponent(key), object[key]) :
            `${encodeURIComponent(key)}=${encodeURIComponent(object[key])}`
        ).join('&');

        return result;
    }

    /**
     * Converts a sub-object to a parametrised string.
     * @param object
     * @returns {string}
     */
    subObjectToParams(key, object): string {
        let result = Object.keys(object).map((childKey) => this.IsObject(object[childKey]) ?
            this.subObjectToParams(`${key}[${encodeURIComponent(childKey)}]`, object[childKey]) :
            `${key}[${encodeURIComponent(childKey)}]=${encodeURIComponent(object[childKey])}`
        ).join('&');

        return result;
    }


    callPost(body: any, params = null) {
        // need to add params

        return this._http.post(this.fullUrl, body);
    }

    callPut(body: any, params = null) {
        // need to add params

        return this._http.put(this.fullUrl, body);
    }

    callDelete(params = null) {
        // need to add params

        return this._http.delete(this.fullUrl);
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