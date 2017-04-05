import { DTOrderDir } from './DTOrderDir';

export class DTOrder {
    Column: number;
    Dir: DTOrderDir;

    constructor(column = 0) {
        this.Column = column;
        this.Dir = DTOrderDir.ASC;
    }
}