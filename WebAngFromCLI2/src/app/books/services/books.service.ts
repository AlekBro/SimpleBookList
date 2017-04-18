import { Injectable } from '@angular/core';

import { Observable } from 'rxjs/Observable';

import { ApiService } from '../../../app/core/services/api-service';

import { BookViewModel } from '../models/BookViewModel';

import { DTResult } from '../../../app/core/models/DTResult';

import { Http, Response } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { DTParameters } from 'app/core/models/DTParameters';

import { Repository } from 'app/core/components/repository';

@Injectable()
export class BooksService extends Repository<BookViewModel>{

    constructor(protected http: Http) {
        super(http);
        this.baseApiUlr = 'api/Books/';
    }

}