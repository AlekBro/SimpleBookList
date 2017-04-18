import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { Http, Response } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import { ApiService } from '../../../app/core/services/api-service';

import { IRepository } from './repository.interface';

import { DTParameters } from 'app/core/models/DTParameters';
import { DTResult } from '../../../app/core/models/DTResult';

@Injectable()
export class Repository<T> extends ApiService implements IRepository<T> {

    public baseApiUlr = '';

    constructor(protected http: Http) {
        super(http);
    }

    list(params: DTParameters): Promise<DTResult<T>> {
        this.entityUrl = this.baseApiUlr;

        return this.callGet(params)
            .toPromise()
            .then(
            response => response.json() as DTResult<T>
            )
            .catch(this.handleError);
    }

    findById(entityId: number): Promise<T> {
        this.entityUrl = this.baseApiUlr + entityId.toString();

        return this.callGet({ id: entityId })
            .toPromise()
            .then(
            response => response.json() as Promise<T>
            )
            .catch(this.handleError);
    }

    create(entity: T): Promise<T> {

        this.entityUrl = this.baseApiUlr;

        return this.callPost(entity)
            .toPromise()
            .then(
            response => response.json() as Promise<T>
            )
            .catch(this.handleError);
    }

    update(entityId: number, entity: T): Promise<boolean> {
        this.entityUrl = this.baseApiUlr + entityId;

        return this.callPut(entity)
            .toPromise()
            .then(
            response => {
                if (response.status == 200) {
                    return true;
                }

                return false;
            })
            .catch(this.handleError);
    }

    delete(id: number): Promise<boolean> {
        this.entityUrl = this.baseApiUlr + id;

        return this.callDelete()
            .toPromise()
            .then(
            response => {
                if (response.status == 200) {
                    return true;
                }

                return false;
            })
            .catch(this.handleError);
    }
}