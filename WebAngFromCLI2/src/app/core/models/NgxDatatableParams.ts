export class NgxDatatableParams<T> {

    private _rows: T[];
    public get rows(): T[] {
        return [... this._rows]
    }
    
    columns: any[];
    count: number;
    offset: number; // Page offset
    limit: number;

    public rowsOffset: number;

    public sortProperty: string;
    public sortDir: string;

    constructor(limit: number = 10) {
        this._rows = [];
        this.count = 0;
        this.offset = 0;
        this.limit = limit;

        this.sortProperty = null;
        this.sortDir = null;

        this.rowsOffset = 0;
    };

    setData(data) {
        let start = this.rowsOffset;

        let rows = [];
        for (let i = 0; i < this.count; i++) {
            rows[i] = { $$index: i };
        }

        data.forEach((e, i) => {
            e.$$index = start + i;
            rows[start + i] = e;
        });
        
        this._rows = rows;
    }
}