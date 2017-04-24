
import { OnInit } from '@angular/core';

import { DTResult } from 'app/core/models/DTResult';
import { DTParameters } from 'app/core/models/DTParameters';
import { DTColumn } from 'app/core/models/DTColumn';
import { DTOrder } from 'app/core/models/DTOrder';
import { DTOrderDir } from 'app/core/models/DTOrderDir';

import { NgxDatatableParams } from 'app/core/models/NgxDatatableParams';

export class BaseGridComponent<T> implements OnInit {

    rowsOnPage: string;

    pageSelector = [10, 20, 50, 100, 150, 200, 'All'];

    selectedEntityId: any;
    showedEntityId: any;
    errorMessage: string = null;

    ngxDatatableParams: NgxDatatableParams<T>;

    dtResult: DTResult<T>;
    dtParameters: DTParameters;

    loading = false;

    constructor(
    ) {

    }

    ngOnInit() {
        this.dtParameters = new DTParameters();
        this.ngxDatatableParams = new NgxDatatableParams<T>();
    }

    // Change page number:
    onPage(event) {
        this.dtParameters.Draw = event.offset + 1;
        this.dtParameters.Length = event.pageSize;
        this.dtParameters.Start = event.pageSize * event.offset;

        this.ngxDatatableParams.offset = event.offset;
        this.ngxDatatableParams.rowsOffset = this.ngxDatatableParams.offset * this.ngxDatatableParams.limit;

        this.updateGrid();
    }

    onSort(event) {
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

        this.dtParameters.Draw = 1;
        this.dtParameters.Start = 0;
        this.ngxDatatableParams.offset = 0;
        this.ngxDatatableParams.rowsOffset = 0;

        this.updateGrid();
    }

    updateGrid() {
        this.errorMessage = null;
        this.loading = true;
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
            this.errorMessage = 'Error while sending your request!';
        }

        return Promise.resolve();
    }

    showEntity(id) {
        this.errorMessage = null;

        this.showedEntityId = id;
    }

}