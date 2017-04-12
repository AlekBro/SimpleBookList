import { Component, Input, Output, OnChanges, OnInit, EventEmitter } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';

import { AuthorService } from '../../services/authors.service';

import { AuthorViewModel } from '../../models/AuthorViewModel';

@Component({
  selector: 'app-author-add-edit',
  templateUrl: './author-add-edit.component.html',
  styleUrls: ['./author-add-edit.component.css']
})
export class AuthorAddEditComponent implements OnInit {

  @Input() entityId: number;
  @Output() clearEntityId = new EventEmitter();

  errorMessage: string = null;
  successMessage: string = null;

  entity: AuthorViewModel;

  haveId: boolean;


  constructor(
    private _authorService: AuthorService,
  ) { }

  ngOnInit() {



  }

  handleError(error: any) {
    //this.isError = true;

    console.log(error);

    this.errorMessage = error;

    return Promise.resolve();
  }


  ngOnChanges(changes) {
    this.errorMessage = null;

    this.haveId = typeof this.entityId !== 'undefined' && this.entityId !== null;

    if (this.haveId) {
      if (this.entityId != -1) {

        this._authorService.getAuthor(this.entityId)
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
    }
  }

  cancel() {
    this.errorMessage = null;
    this.successMessage = null;

    this.entity = new AuthorViewModel();
    this.clearEntityId.emit();
  }

  save(form) {
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

              setTimeout(function () {
                this.cancel();
              }.bind(this), 4000);
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

            setTimeout(function () {
              this.cancel();
            }.bind(this), 5000);

          })
          .catch((ex) => {
            this.handleError(ex);
          });
      }
    }

  }
}
