import { Component, ViewEncapsulation, OnInit } from '@angular/core';

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

  constructor(
    private _authorService: AuthorService
  ) {
    //this.dtResult = new DTResult<AuthorViewModel>();

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
    this.dtParameters.Order.push(new DTOrder( columnIndex, dtOrderDir));

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


  ngOnInit() {

    this.dtParameters = new DTParameters();

    this.ngxDatatableParams = new NgxDatatableParams<AuthorViewModel>();

    this.ngxDatatableParams.columns = [
      { prop: 'Id', name: 'Id', sortable: true },
      { prop: 'FirstName', name: 'FirstName', sortable: true },
      { prop: 'LastName', name: 'LastName', sortable: true },
      { prop: 'BooksNumber', name: 'BooksNumber', sortable: true },
    ];

    this.ngxDatatableParams.columns.forEach((item, index) => {
      this.dtParameters.Columns.push(new DTColumn(item.prop));
    });

    this.updateGrid();

  }

  handleError(error: any) {
    //this.isError = true;

    console.log(error);

    return Promise.resolve();
  }

}
