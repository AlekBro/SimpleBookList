import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { TemplateRef, ViewChild } from '@angular/core';

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


  ngxDatatableParams: NgxDatatableParams<AuthorViewModel>;

  dtResult: DTResult<AuthorViewModel>;
  dtParameters: DTParameters;

  @ViewChild('optionsTmpl') optionsTmpl: TemplateRef<any>;

  constructor(
    private _authorService: AuthorService
  ) {
    //this.dtResult = new DTResult<AuthorViewModel>();

  }

  ngOnInit() {
    this.dtParameters = new DTParameters();
    this.ngxDatatableParams = new NgxDatatableParams<AuthorViewModel>();

    this.ngxDatatableParams.columns = [
      { prop: 'Id', name: 'Id', sortable: true },
      { prop: 'FirstName', name: 'FirstName', sortable: true },
      { prop: 'LastName', name: 'LastName', sortable: true },
      { prop: 'BooksNumber', name: 'BooksNumber', sortable: true },
      { prop: 'Id', name: 'Options', sortable: false, cellTemplate: this.optionsTmpl },
    ];

    this.ngxDatatableParams.columns.forEach((item, index) => {
      this.dtParameters.Columns.push(new DTColumn(item.prop));
    });

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

    this._authorService.getAuthorsServerSide(this.dtParameters)
      .then(Authors => {

        this.ngxDatatableParams.setData(Authors.data);
        this.ngxDatatableParams.count = Authors.recordsTotal;

        /*
        let limit = Authors.data.length;
        if (this.ngxDatatableParams.limit > limit) {
          limit = this.ngxDatatableParams.limit;
        }
        this.ngxDatatableParams.limit = limit;
        */

        this.ngxDatatableParams.offset = Authors.draw - 1;

        console.log(Authors);
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

  pageSelector = [10, 20, 50, 100, 150, 200, 'All'];

  selectedEntityId: any;
  errorMessage: string;

  selectEntityId(id) {
    this.selectedEntityId = id;
  }

  clearEntityId() {
    this.selectedEntityId = undefined;
    this.updateGrid();
  }


  handleError(error: any) {
    //this.isError = true;

    console.log(error);

    return Promise.resolve();
  }

}
