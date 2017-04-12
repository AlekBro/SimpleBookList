import { DTResult } from 'app/core/models/DTResult';

export interface IRepository<T> {
    list(params);
    create(entity: T);
    delete(entityId: number);
    update(entityId: number, entity: T);
    findById(entityId: number);
}