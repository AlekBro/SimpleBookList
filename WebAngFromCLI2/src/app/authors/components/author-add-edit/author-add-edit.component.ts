import { Component, OnInit } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';

import { AuthorService } from '../../services/authors.service';

@Component({
  selector: 'app-author-add-edit',
  templateUrl: './author-add-edit.component.html',
  styleUrls: ['./author-add-edit.component.css']
})
export class AuthorAddEditComponent implements OnInit {

  entity: any;

  private sub: any;

  constructor(
    private _authorService: AuthorService,
    private _route: ActivatedRoute,
    private _router: Router
  ) { }

  ngOnInit() {

    this.sub = this._route.params.subscribe(params => {
      console.log(params);
      let entityId = +params['id'];

      if (entityId > 0) {
        this._authorService.getAuthor(entityId)
          .then(Author => {
            this.entity = Author;

            console.log(Author);
          })
          .catch((ex) => {
            this.handleError(ex);
          });
      }

    });

  }

  handleError(error: any) {
    //this.isError = true;

    console.log(error);

    return Promise.resolve();
  }

}
