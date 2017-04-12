import { Component, ViewEncapsulation, OnInit } from '@angular/core';

import { TemplateRef, ViewChild } from '@angular/core';
import { ViewContainerRef } from '@angular/core';
import { Overlay } from 'angular2-modal';
import { Modal } from 'angular2-modal/plugins/bootstrap';

import { AuthorService } from '../../services/authors.service';

import { AuthorViewModel } from '../../models/AuthorViewModel';

import { DTResult } from '../../../../app/core/models/DTResult';
import { DTParameters } from 'app/core/models/DTParameters';
import { DTColumn } from 'app/core/models/DTColumn';
import { DTOrder } from 'app/core/models/DTOrder';
import { DTOrderDir } from 'app/core/models/DTOrderDir';

import { NgxDatatableParams } from 'app/core/models/NgxDatatableParams';

@Component({
  selector: 'app-authors',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css',
    '../../../../../node_modules/@swimlane/ngx-datatable/release/index.css',
    '../../../../../node_modules/@swimlane/ngx-datatable/release/themes/material.css',
    '../../../../../node_modules/@swimlane/ngx-datatable/release/assets/icons.css',
  ]
})
export class AuthorsComponent implements OnInit {

  rowsOnPage: string;

  pageSelector = [10, 20, 50, 100, 150, 200, 'All'];

  selectedEntityId: any;
  showedEntityId: any;
  errorMessage: string = null;


  ngxDatatableParams: NgxDatatableParams<AuthorViewModel>;

  dtResult: DTResult<AuthorViewModel>;
  dtParameters: DTParameters;

  @ViewChild('optionsTmpl') optionsTmpl: TemplateRef<any>;
  @ViewChild('idTmpl') idTmpl: TemplateRef<any>;

  loading: boolean = false;

  constructor(
    private _authorService: AuthorService,
    overlay: Overlay, vcRef: ViewContainerRef, public modal: Modal,
  ) {
    //this.dtResult = new DTResult<AuthorViewModel>();

    overlay.defaultViewContainer = vcRef;
  }

  ngOnInit() {
    this.dtParameters = new DTParameters();
    this.ngxDatatableParams = new NgxDatatableParams<AuthorViewModel>();

    this.ngxDatatableParams.columns = [
      { prop: 'Id', name: 'Id', sortable: true, cellTemplate: this.idTmpl },
      { prop: 'FirstName', name: 'FirstName', sortable: true },
      { prop: 'LastName', name: 'LastName', sortable: true },
      { prop: 'BooksNumber', name: 'BooksNumber', sortable: true },
      { prop: 'Id', name: 'Options', sortable: false, cellTemplate: this.optionsTmpl },
    ];

    this.ngxDatatableParams.columns.forEach((item, index) => {
      this.dtParameters.Columns.push(new DTColumn(item.prop));
    });

    this.rowsOnPage = "10";

    this.updateGrid();
  }

  // Change page number:
  onPage(event) {
    console.log(event);



    this.dtParameters.Draw = event.offset + 1;
    this.dtParameters.Length = event.pageSize;
    this.dtParameters.Start = event.pageSize * event.offset;

    this.ngxDatatableParams.offset = event.offset;
    this.ngxDatatableParams.rowsOffset = this.ngxDatatableParams.offset * this.ngxDatatableParams.limit;

    this.updateGrid();
  }

  onSort(event) {
    console.log(event);

    let columnName = event.column.prop;

    let orderDir: string = event.newValue;
    orderDir = orderDir.toUpperCase();

    this.dtParameters.SortOrder = columnName;


    let columnIndex = 0;
    this.dtParameters.Columns.forEach((column, index) => {
      if (column.Data == columnName) {
        columnIndex = index;
      }
    });

    let dtOrderDir = DTOrderDir[orderDir];

    this.dtParameters.Order = new Array<DTOrder>();
    this.dtParameters.Order.push(new DTOrder(columnIndex, dtOrderDir));

    this.updateGrid();
  }


  updateGrid() {
    this.errorMessage = null;
    this.loading = true;

    this._authorService.getAuthorsServerSide(this.dtParameters)
      .then(Authors => {

        this.ngxDatatableParams.setData(Authors.data);
        this.ngxDatatableParams.count = Authors.recordsTotal;

        if (this.rowsOnPage == 'All') {
          this.ngxDatatableParams.limit = Authors.recordsTotal;
        }
        /*
        let limit = Authors.data.length;
        if (this.ngxDatatableParams.limit > limit) {
          limit = this.ngxDatatableParams.limit;
        }
        this.ngxDatatableParams.limit = limit;
        */

        this.ngxDatatableParams.offset = Authors.draw - 1;

        this.loading = false;
      })
      .catch((ex) => {
        this.handleError(ex);
      });
  }

  // Change number of rows on page
  setRowsOnPage(value: string) {

    let newLimit: number = 10;
    let count: number = this.ngxDatatableParams.count;
    let rowsOffset: number = this.ngxDatatableParams.rowsOffset;
    let maxOffset: number = 0;

    if (value == 'All') {
      newLimit = this.ngxDatatableParams.count;
      rowsOffset = 0;
      // if 'All' then maxOffset is 0;
    } else {
      newLimit = Number.parseInt(value);
      maxOffset = Math.floor(rowsOffset / newLimit);
    }

    this.ngxDatatableParams.rowsOffset = maxOffset * newLimit;

    this.ngxDatatableParams.offset = maxOffset;
    this.ngxDatatableParams.limit = newLimit;


    this.dtParameters.Draw = this.ngxDatatableParams.offset + 1;
    this.dtParameters.Length = this.ngxDatatableParams.limit;
    this.dtParameters.Start = this.ngxDatatableParams.limit * this.ngxDatatableParams.offset;


    this.updateGrid();
  }

  selectEntityId(id) {
    this.errorMessage = null;

    this.selectedEntityId = id;
  }

  clearEntityId() {
    this.errorMessage = null;

    this.selectedEntityId = undefined;
    this.showedEntityId = undefined;
    
    this.updateGrid();
  }

  handleError(error: any) {

    if (error && typeof error == 'string') {
      this.errorMessage = error;
    } else {
      this.errorMessage = "Error while sending your request!";
    }

    return Promise.resolve();
  }

  deleteEntity(id: number) {
    this.errorMessage = null;

    const dialog = this.modal.confirm()
      .title("Deleting Author")
      .body("Do you really want to delete this Author?")
      .open()
      .then((resultPromise) => {
        resultPromise.result.then((result) => {

          this._authorService.deleteAuthor(id)
            .then(
            res => {
              if (res == true) {
                this.updateGrid();
              } else {
                this.errorMessage = "Error while sending your request!";
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

  showEntity(id){
    this.errorMessage = null;

    this.showedEntityId = id;
  }

}
