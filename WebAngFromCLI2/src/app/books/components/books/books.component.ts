import { Component, ViewEncapsulation, OnInit } from '@angular/core';

import { TemplateRef, ViewChild } from '@angular/core';
import { ViewContainerRef } from '@angular/core';
import { Overlay } from 'angular2-modal';
import { Modal } from 'angular2-modal/plugins/bootstrap';

import { BooksService } from '../../services/books.service';

import { BookViewModel } from '../../models/BookViewModel';

import { DTResult } from 'app/core/models/DTResult';
import { DTParameters } from 'app/core/models/DTParameters';
import { DTColumn } from 'app/core/models/DTColumn';
import { DTOrder } from 'app/core/models/DTOrder';
import { DTOrderDir } from 'app/core/models/DTOrderDir';

import { NgxDatatableParams } from 'app/core/models/NgxDatatableParams';

import { BaseGridComponent } from 'app/core/components/base-grid-component';

@Component({
  selector: 'app-books',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css',
    '../../../../../node_modules/@swimlane/ngx-datatable/release/index.css',
    '../../../../../node_modules/@swimlane/ngx-datatable/release/themes/material.css',
    '../../../../../node_modules/@swimlane/ngx-datatable/release/assets/icons.css',
  ]
})
export class BooksComponent extends BaseGridComponent<BookViewModel> implements OnInit {

  @ViewChild('optionsTmpl') optionsTmpl: TemplateRef<any>;
  @ViewChild('idTmpl') idTmpl: TemplateRef<any>;

  constructor(
    private _booksService: BooksService,
    overlay: Overlay, vcRef: ViewContainerRef, public modal: Modal,
  ) {
    super();

    overlay.defaultViewContainer = vcRef;
  }

  ngOnInit() {
    super.ngOnInit();

    this.ngxDatatableParams.columns = [
      { prop: 'Id', name: 'Id', sortable: true, cellTemplate: this.idTmpl },
      { prop: 'Name', name: 'Name', sortable: true },
      { prop: 'FormattedReleaseDate', name: 'Release Date', sortable: true },
      { prop: 'Pages', name: 'Pages', sortable: true },
      { prop: 'Rating', name: 'Rating', sortable: true },
      { prop: 'Publisher', name: 'Publisher', sortable: true },
      { prop: 'ISBN', name: 'ISBN', sortable: true },
      { prop: 'Id', name: 'Options', sortable: false, cellTemplate: this.optionsTmpl, minWidth: 160 },
    ];

    this.ngxDatatableParams.columns.forEach((item, index) => {
      this.dtParameters.Columns.push(new DTColumn(item.prop));
    });

    this.rowsOnPage = '10';

    this.updateGrid();
  }

  updateGrid() {
    super.updateGrid();

    this._booksService.list(this.dtParameters)
      .then(books => {

        this.ngxDatatableParams.setData(books.data);
        this.ngxDatatableParams.count = books.recordsTotal;

        if (this.rowsOnPage == 'All') {
          this.ngxDatatableParams.limit = books.recordsTotal;
        }

        this.loading = false;
      })
      .catch((ex) => {
        this.handleError(ex);
      });
  }

  deleteEntity(id: number) {
    this.errorMessage = null;

    const dialog = this.modal.confirm()
      .title('Deleting Author')
      .body('Do you really want to delete this Book?')
      .open()
      .then((resultPromise) => {
        resultPromise.result.then((result) => {

          this._booksService.delete(id)
            .then(
            res => {
              if (res == true) {
                this.updateGrid();
              } else {
                this.errorMessage = 'Error while sending your request!';
              }

            },
            error => this.errorMessage = error)
            .catch((ex) => {
              this.handleError(ex);
            });;
        },
          () => {
            //console.log("deleteEntity dialog - cancel");
          });
      });
  }

  showEntity(id) {
    this.errorMessage = null;

    this.showedEntityId = id;
  }

}
