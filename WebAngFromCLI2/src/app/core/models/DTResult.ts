export class DTResult<T> {
    draw: number;
    recordsTotal: number;
    recordsFiltered: number;
    data: T[];
}