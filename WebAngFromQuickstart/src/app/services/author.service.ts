import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { AuthorModel } from '../models/author.model';
import { AuthorsServerAnswerModel } from '../models/authors-server-answer.model';

import { BaseApiService } from './base-api.service';

@Injectable()
export class AuthorService extends BaseApiService {

    private allAuthorsUrl = 'http://localhost:52211/api/Authors';  // URL to web API

    authorsServerAnswer: AuthorsServerAnswerModel;

    getAuthors(): Promise<AuthorsServerAnswerModel> {
        return this.get(this.allAuthorsUrl)
            .toPromise()
            .then(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Promise.reject(errMsg);
    }


}