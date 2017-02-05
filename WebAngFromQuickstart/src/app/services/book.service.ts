import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { BookModel } from '../models/book.model';
import { BoosServerAnswerModel } from '../models/books-server-answer.model';


@Injectable()
export class BookService {

    private allBooksUrl = 'http://localhost:52211/api/Books';  // URL to web API

    constructor(private http: Http) { }



}