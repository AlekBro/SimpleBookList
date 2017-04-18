import { DTColumn } from './DTColumn';
import { DTOrder } from './DTOrder';
import { DTSearch } from './DTSearch';

export class DTParameters {
    Draw: number;
    Columns: DTColumn[];
    Order: DTOrder[];
    Start: number;
    Length: number;
    Search: DTSearch;
    SortOrder: string;

    constructor(length = 10, sortOrder = 'Id') {
        this.Draw = 1;

        this.Columns = new Array<DTColumn>();
        this.Order = new Array<DTOrder>();

        this.Start = 0;
        this.Length = length;

        this.Search = new DTSearch();

        this.SortOrder = sortOrder;
    }
}