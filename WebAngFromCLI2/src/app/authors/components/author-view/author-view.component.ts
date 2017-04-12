import { Component, Input, Output, OnChanges, OnInit, EventEmitter } from '@angular/core';

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

  @Input() entityId: number;
  @Output() clearEntityId = new EventEmitter();

  errorMessage: string = null;

  authorId: number;

  entity: AuthorViewModel;

  haveId: boolean;

  ngOnInit() {
    this.errorMessage = null;

    this.haveId = typeof this.entityId !== 'undefined' && this.entityId !== null;

    if (this.haveId) {
      if (this.entityId != -1) {

        this._authorService.getAuthor(this.entityId)
          .then(Author => {
            this.entity = Author;

          })
          .catch((ex) => {
            this.handleError(ex);
          });
      }
    }

  }

  cancel() {
    this.errorMessage = null;
    this.entity = undefined;
    this.clearEntityId.emit();
  }

  ngOnChanges(changes) {
    this.errorMessage = null;

    this.haveId = typeof this.entityId !== 'undefined' && this.entityId !== null;

    if (this.haveId) {
      if (this.entityId != -1) {

        this._authorService.getAuthor(this.entityId)
          .then(Author => {
            this.entity = Author;

          })
          .catch((ex) => {
            this.handleError(ex);
          });
      }
    }
  }

  handleError(error: any) {

    if (error && typeof error == 'string') {
      this.errorMessage = error;
    } else {
      this.errorMessage = "Error while sending your request!";
    }

    return Promise.resolve();
  }

}
