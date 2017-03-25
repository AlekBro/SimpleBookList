import { Component, OnInit } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';

import { AuthorService } from '../../services/authors.service';

import { AuthorViewModel } from '../../models/AuthorViewModel';

@Component({
  selector: 'app-author-add-edit',
  templateUrl: './author-add-edit.component.html',
  styleUrls: ['./author-add-edit.component.css']
})
export class AuthorAddEditComponent implements OnInit {

  errorMessage: string = null;
  successMessage: string = null;

  entity: AuthorViewModel;

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
      } else {
        this.entity = new AuthorViewModel();
      }

    });

  }

  handleError(error: any) {
    //this.isError = true;

    console.log(error);

    this.errorMessage = error;

    return Promise.resolve();
  }


  save(form) {
    console.log('save', form);

    this.errorMessage = null;
    this.successMessage = null;

    if (form.valid) {
      if (this.entity.Id > -1) {
        let result = this._authorService.updateAuthor(this.entity.Id, this.entity)
          .then(res => {
            if (res == true) {
              this.successMessage = "Author was successfully updated!";
              console.log(res);
              this.entity = null;
            }

          })
          .catch((ex) => {
            this.handleError(ex);
          });

      } else if (this.entity.Id == -1) {
        let result = this._authorService.createAuthor(this.entity)
          .then(res => {
            this.successMessage = "Author " + res.Name + " was successfully created!";
            console.log(res);
            this.entity = null;
          })
          .catch((ex) => {
            this.handleError(ex);
          });
      }
    }

  }
}
