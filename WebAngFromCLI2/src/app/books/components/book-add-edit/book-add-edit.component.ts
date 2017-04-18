import { Component, Input, Output, OnChanges, OnInit, EventEmitter } from '@angular/core';

import { Router, ActivatedRoute } from '@angular/router';

import { BooksService } from '../../services/books.service';
import { AuthorService } from 'app/authors/services/authors.service';

import { BookViewModel } from '../../models/BookViewModel';
import { AuthorViewModel } from 'app/authors/models/AuthorViewModel';

import * as moment from 'moment';

import { IMultiSelectOption, IMultiSelectSettings } from 'angular-2-dropdown-multiselect';

import { DTParameters } from 'app/core/models/DTParameters';

@Component({
  selector: 'app-book-add-edit',
  templateUrl: './book-add-edit.component.html',
  styleUrls: ['./book-add-edit.component.css']
})
export class BookAddEditComponent implements OnInit, OnChanges {

  @Input() entityId: number;
  @Output() clearEntityId = new EventEmitter();

  errorMessage: string = null;
  successMessage: string = null;

  entity: BookViewModel;

  haveId: boolean;

  ratingSelect: [{}];

  authorsOptions: IMultiSelectOption[];
  authorsOptionsSettings: IMultiSelectSettings;
  allAuthors: AuthorViewModel[];

  constructor(
    private _booksService: BooksService,
    private _authorService: AuthorService
  ) { }

  ngOnInit() {
    this.ratingSelect = [{}];
    for (let i = 0; i < 11; i++) {
      this.ratingSelect.push(
        { name: i.toString(), value: i }
      );
    };

    this.initRolesMultiselect();
  }


  initRolesMultiselect() {
    this.errorMessage = null;

    this.allAuthors = new Array<AuthorViewModel>();
    //this.entity.AuthorsIds = new Array<number>();

    this.authorsOptionsSettings = {
      pullRight: false,
      enableSearch: false,
      checkedStyle: 'checkboxes',
      buttonClasses: 'form-control fixed-height-30',
      selectionLimit: 0,
      closeOnSelect: false,
      autoUnselect: false,
      showCheckAll: false,
      showUncheckAll: false,
      maxHeight: '300px',
    };

    this.authorsOptions = new Array<IMultiSelectOption>();

    let dtParameters: DTParameters = new DTParameters();
    this._authorService.list(dtParameters)
      .then(
      res => {
        this.allAuthors = res.data;

        res.data.forEach((item, index) => {
          this.authorsOptions.push({
            id: item.Id, name: item.Name
          });
        });
      },
      error => this.errorMessage = error)
      .catch((ex) => {
        this.handleError(ex);
      });
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

        this._booksService.findById(this.entityId)
          .then(Book => {
            this.entity = Book;

            if (this.entity.ReleaseDate) {
              const releaseDate = moment(this.entity.ReleaseDate).format('MM/DD/YYYY');
              this.entity.ReleaseDate = new Date(releaseDate);
            }

            if (this.entity.Authors && this.entity.Authors.length > 0) {
              this.entity.AuthorsIds = new Array<number>();
              this.entity.Authors.forEach(author => {
                this.entity.AuthorsIds.push(author.Id);
              });
            }

            console.log(Book);
          })
          .catch((ex) => {
            this.handleError(ex);
          });


      } else {
        this.entity = new BookViewModel();
      }
    }
  }

  cancel() {
    this.errorMessage = null;
    this.successMessage = null;

    this.entity = new BookViewModel();
    this.clearEntityId.emit();
  }

  save(form) {
    this.errorMessage = null;
    this.successMessage = null;

    if (form.valid) {

      if (this.entity.ReleaseDate) {
        this.entity.ReleaseDate = moment(this.entity.ReleaseDate).format('MM/DD/YYYY');
      }

      if (this.entity.Id > -1) {
        let result = this._booksService.update(this.entity.Id, this.entity)
          .then(res => {
            if (res == true) {
              this.successMessage = "Book was successfully updated!";
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
        let result = this._booksService.create(this.entity)
          .then(res => {
            this.successMessage = "Book " + res.Name + " was successfully created!";
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
