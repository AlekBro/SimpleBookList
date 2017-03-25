import { Component, OnInit } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';

import { AuthorService } from '../../services/authors.service';

import { AuthorViewModel } from '../../models/AuthorViewModel';

@Component({
  selector: 'app-author-view',
  templateUrl: './author-view.component.html',
  styleUrls: ['./author-view.component.css']
})
export class AuthorViewComponent implements OnInit {

  constructor(private _activatedRoute: ActivatedRoute, private _authorService: AuthorService) {

  }

  authorId: number;

  Author: AuthorViewModel;

  ngOnInit() {

    this._activatedRoute.params.subscribe(params => {
      if (params['authorId']) {
        this.authorId = params['authorId'];
      }

      console.log('URL params ', params);
    });


    this._authorService.getAuthor(this.authorId)
      .then(Author => {
        this.Author = Author;

        console.log(this.Author);
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
