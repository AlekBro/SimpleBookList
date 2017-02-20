import { Injectable } from '@angular/core';

import { ApiService } from '../../../app/core/services/api-service';

import { BookViewModel } from '../models/BookViewModel';

import { DTResult } from '../../../app/core/models/DTResult';

import { Http, Response } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class BooksService extends ApiService {

    constructor(private http: Http) {
        super(http);
    }

    getBooks(): Promise<DTResult<BookViewModel>> {
        this.entityUrl = 'api/Books';

        return this.callGet()
            .toPromise()
            .then(
            response => response.json() as DTResult<BookViewModel>
            )
            .catch(this.handleError);

    }
}