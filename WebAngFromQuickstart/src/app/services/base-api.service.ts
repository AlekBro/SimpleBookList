import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';


@Injectable()
export class BaseApiService {

    constructor(private http: Http) { }

    get(url: string): Observable<Response> {
        return this.http.get(url);
    }

    post(url: string, body: Object): Observable<Response> {
        let bodyString = JSON.stringify(body); // Stringify payload
        let headers = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
        let options = new RequestOptions({ headers: headers }); // Create a request option

        return this.http.post(url, bodyString, options);
    }

    // https://scotch.io/tutorials/angular-2-http-requests-with-observables
    put(url: string, body: Object): Observable<Response> {

        let bodyString = JSON.stringify(body); // Stringify payload
        let headers = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
        let options = new RequestOptions({ headers: headers }); // Create a request option

        return this.http.put(url, bodyString, options);
    }

    delete(url: string): Observable<Response> {
        return this.http.delete(url);
    }

}