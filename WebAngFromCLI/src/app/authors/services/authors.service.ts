import { Injectable } from '@angular/core';

import { Observable } from 'rxjs/Observable';



import { ApiService } from '../../../app/core/services/api-service';

import { AuthorViewModel } from '../models/AuthorViewModel';

import { DTResult } from '../../../app/core/models/DTResult';

import { Http, Response } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class AuthorService extends ApiService {

    constructor(private http: Http) {
        super(http);
    }

    getAuthors(): Promise<DTResult<AuthorViewModel>> {
        this.entityUrl = 'api/Authors';

        return this.callGet()
            .toPromise()
            .then(
            response => response.json() as DTResult<AuthorViewModel>
            )
            .catch(this.handleError);

    }
}