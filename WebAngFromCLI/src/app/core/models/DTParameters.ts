import {DTColumn} from './DTColumn';
import {DTOrder} from './DTOrder';
import {DTSearch} from './DTSearch';

export interface DTParameters{
    Draw: number;
    Columns: DTColumn[];
    Order: DTOrder[];
    Start: number;
    Length: number;
    Search: DTSearch;
    SortOrder: string;
}