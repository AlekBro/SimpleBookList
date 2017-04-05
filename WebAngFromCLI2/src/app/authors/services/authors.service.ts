import { Injectable } from '@angular/core';

import { Observable } from 'rxjs/Observable';



import { ApiService } from '../../../app/core/services/api-service';

import { AuthorViewModel } from '../models/AuthorViewModel';

import { DTResult } from '../../../app/core/models/DTResult';

import { Http, Response } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { DTParameters } from 'app/core/models/DTParameters';

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

    getAuthorsServerSide(params: DTParameters ): Promise<DTResult<AuthorViewModel>> {
        this.entityUrl = 'api/Authors';

        return this.callGet(params)
            .toPromise()
            .then(
            response => response.json() as DTResult<AuthorViewModel>
            )
            .catch(this.handleError);

    }

    getAuthor(id: number): Promise<AuthorViewModel> {
        this.entityUrl = 'api/Authors/' + id.toString();

        //this.entityUrl = 'api/Authors/';

        return this.callGet({ id: id })
            .toPromise()
            .then(
            response => response.json() as Promise<AuthorViewModel>
            )
            .catch(this.handleError);
    }

    createAuthor(author: AuthorViewModel): Promise<AuthorViewModel> {

        this.entityUrl = 'api/Authors';

        return this.callPost(author)
            .toPromise()
            .then(
            response => response.json() as Promise<AuthorViewModel>
            )
            .catch(this.handleError);
    }

    updateAuthor(authorId: number, author: AuthorViewModel): Promise<boolean> {
        this.entityUrl = 'api/Authors/' + authorId;

        return this.callPut(author)
            .toPromise()
            .then(
            response => {
                if (response.status == 200) {
                    return true;
                }
                
                return false;
            }
            )
            .catch(this.handleError);
    }

    deleteAuthor(id: number) {

    }

}