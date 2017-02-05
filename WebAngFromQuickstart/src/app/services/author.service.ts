import { Injectable }              from '@angular/core';
import { Http, Response }          from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { AuthorModel } from '../models/author.model';
import { AuthorsServerAnswerModel } from '../models/authors-server-answer.model';

@Injectable()
export class AuthorService {

    private allAuthorsUrl = 'http://localhost:52211/api/Authors';  // URL to web API

    constructor (private http: Http) {}



}