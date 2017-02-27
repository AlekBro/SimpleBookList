import { Component, OnInit } from '@angular/core';

import { AuthorService } from '../../services/authors.service';

import { AuthorViewModel } from '../../models/AuthorViewModel';

import { DTResult } from '../../../../app/core/models/DTResult';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {

  constructor(private _authorService: AuthorService) {

  }

  Authors: DTResult<AuthorViewModel>;

  ngOnInit() {
    this._authorService.getAuthors()
      .then(Authors => {
        this.Authors = Authors;

        console.log(this.Authors);
      })
      .catch((ex) => {
        this.handleError(ex);
      });

  }

  handleError(error: any) {
    //this.isError = true;

    console.log(error);

    return Promise.resolve();
  }

}
