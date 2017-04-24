import { Component, ViewEncapsulation, OnInit } from '@angular/core';

import { TemplateRef, ViewChild } from '@angular/core';
import { ViewContainerRef } from '@angular/core';
import { Overlay } from 'angular2-modal';
import { Modal } from 'angular2-modal/plugins/bootstrap';

import { AuthorService } from '../../services/authors.service';

import { AuthorViewModel } from '../../models/AuthorViewModel';

import { DTResult } from 'app/core/models/DTResult';
import { DTParameters } from 'app/core/models/DTParameters';
import { DTColumn } from 'app/core/models/DTColumn';
import { DTOrder } from 'app/core/models/DTOrder';
import { DTOrderDir } from 'app/core/models/DTOrderDir';

import { NgxDatatableParams } from 'app/core/models/NgxDatatableParams';

import { BaseGridComponent } from 'app/core/components/base-grid-component';

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
export class AuthorsComponent extends BaseGridComponent<AuthorViewModel> implements OnInit {

  @ViewChild('optionsTmpl') optionsTmpl: TemplateRef<any>;
  @ViewChild('idTmpl') idTmpl: TemplateRef<any>;

  constructor(
    private _authorService: AuthorService,
    overlay: Overlay, vcRef: ViewContainerRef, public modal: Modal,
  ) {

    super();

    overlay.defaultViewContainer = vcRef;
  }

  ngOnInit() {
    super.ngOnInit();

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

    this.rowsOnPage = '10';

    this.updateGrid();
  }

  updateGrid() {
    super.updateGrid();

    this._authorService.list(this.dtParameters)
      .then(Authors => {

        this.ngxDatatableParams.setData(Authors.data);
        this.ngxDatatableParams.count = Authors.recordsTotal;

        if (this.rowsOnPage == 'All') {
          this.ngxDatatableParams.limit = Authors.recordsTotal;
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
      .body('Do you really want to delete this Author?')
      .open()
      .then((resultPromise) => {
        resultPromise.result.then((result) => {

          this._authorService.delete(id)
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
            });
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
