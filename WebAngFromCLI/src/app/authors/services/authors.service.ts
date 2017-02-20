import { Injectable } from '@angular/core';

import { Observable } from 'rxjs/Observable';



import { ApiService } from '../../../app/core/services/api-service';

import { AuthorViewModel } from '../models/AuthorViewModel';

import { Http, Response } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class AuthorService extends ApiService {

    constructor(private http: Http) {
        super(http);
    }

    getAuthors(): Promise<AuthorViewModel[]> {
        this.entityUrl = 'api/Authors';

        return this.callGet()
            .toPromise()
            .then(
            response => response.json() as AuthorViewModel[]
            )
            .catch(this.handleError);

    }
}