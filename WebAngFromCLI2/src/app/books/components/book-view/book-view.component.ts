import { Component, Input, Output, OnChanges, OnInit, EventEmitter } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';

import { BooksService } from '../../services/books.service';

import { BookViewModel } from '../../models/BookViewModel';

@Component({
  selector: 'app-book-view',
  templateUrl: './book-view.component.html',
  styleUrls: ['./book-view.component.css']
})
export class BookViewComponent implements OnInit, OnChanges {

  @Input() entityId: number;
  @Output() clearEntityId = new EventEmitter();

  errorMessage: string = null;

  authorId: number;

  entity: BookViewModel;

  haveId: boolean;

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _booksService: BooksService
  ) {

  }

  ngOnInit() {

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

        this._booksService.findById(this.entityId)
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
      this.errorMessage = 'Error while sending your request!';
    }

    return Promise.resolve();
  }

}
