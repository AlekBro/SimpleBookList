import { DTSearch } from './DTSearch';

export class DTColumn {
    Data: string;
    Name: string;
    Searchable: boolean;
    Orderable: boolean;
    Search: DTSearch;

    constructor(columnName = null) {
        this.Data = columnName;

        this.Searchable = true;
        this.Orderable = true;
        this.Search = new DTSearch();
    }
}