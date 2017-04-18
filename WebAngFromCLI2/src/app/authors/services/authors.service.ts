import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { ApiService } from '../../../app/core/services/api-service';

import { AuthorViewModel } from '../models/AuthorViewModel';
import { DTResult } from '../../../app/core/models/DTResult';
import { DTParameters } from 'app/core/models/DTParameters';

import { Repository } from 'app/core/components/repository';

@Injectable()
export class AuthorService extends Repository<AuthorViewModel> {

    constructor(protected http: Http) {
        super(http);
        this.baseApiUlr = 'api/Authors/';
    }
}