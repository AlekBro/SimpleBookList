import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Config } from '../../../config/config';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class ApiService {

    protected readonly baseUrl: string;

    protected entityUrl: string;

    public get url(): string {
        return this.baseUrl + this.entityUrl;
    }

    constructor(protected _http: Http, protected _config: Config) {
        this.baseUrl = _config.domain;
    }

    callGet(){
        
    }



}