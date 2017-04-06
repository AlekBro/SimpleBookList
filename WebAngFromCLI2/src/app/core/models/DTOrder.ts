import { DTOrderDir } from './DTOrderDir';

export class DTOrder {
    Column: number;
    Dir: DTOrderDir;

    constructor(column = 0, orderDir = DTOrderDir.ASC) {
        this.Column = column;
        this.Dir = orderDir;
    }
}