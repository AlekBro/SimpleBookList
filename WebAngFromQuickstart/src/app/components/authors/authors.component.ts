import { Component } from '@angular/core';

import { AuthorModel } from '../../models/author.model';

import { AuthorService } from '../../services/author.service';

@Component({
    moduleId: module.id,
    selector: 'autors',
    templateUrl: 'authors.component.html'
})

export class AuthorsComponent {

    authors: AuthorModel[];

    constructor(private _authorService: AuthorService) {
        this.getAuthors();
    }

    getAuthors(){
        this._authorService.getAuthors().then()
    }

private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

}
