import { Component, OnInit } from '@angular/core';

import { AuthorService } from '../../services/authors.service';

import { AuthorViewModel } from '../../models/AuthorViewModel';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {

  constructor(private _authorService: AuthorService) {
    let test = 1;
  }

  Authors: AuthorViewModel[];

  ngOnInit() {
    this._authorService.getAuthors()
      .then(Authors => {
        this.Authors = Authors;

        console.log(this.Authors);
      })
      .catch((ex) => {
        this.handleError(ex);
      });;

  }

  handleError(error: any) {
    //this.isError = true;

    console.log(error);

    return Promise.resolve();
  }

}
