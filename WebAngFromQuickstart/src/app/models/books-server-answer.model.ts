
import {BaseServerAnswerModel} from './base-server-answer.model';

import{BookModel} from './book.model';

export class BoosServerAnswerModel extends BaseServerAnswerModel {
    data: BookModel[];
}