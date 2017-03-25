import {DTSearch} from './DTSearch';

export interface DTColumn{
    Data: string;
    Name: string;
    Searchable: boolean;
    Orderable: boolean;
    Search: DTSearch;
}