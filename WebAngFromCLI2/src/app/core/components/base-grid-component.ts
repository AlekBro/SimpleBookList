
import { DTResult } from '../models/DTResult';
import { DTParameters } from '../models/DTParameters';

export class BaseGridComponent<T> {

    selectedEntityId: any;
    errorMessage: string;

    dtResult: DTResult<T>;
    dtParameters: DTParameters;

    dtColumns: any;

    filter: any;

    pageSelector = [10, 20, 50, 100, 150, 200, 'All'];

    constructor(

    ) {
        this.dtResult = new DTResult<T>();

    }

    selectEntityId(id) {
        this.selectedEntityId = id;
    }

    clearEntityId() {
        this.selectedEntityId = undefined;
        this.updateDataInGrid();
    }

    // Be sure to override This method in a child class!
    updateDataInGrid() {
        console.log('Be sure to override This method in a child class!');
    }

    updateFilter() {
        this.updateDataInGrid();
    }



 


}