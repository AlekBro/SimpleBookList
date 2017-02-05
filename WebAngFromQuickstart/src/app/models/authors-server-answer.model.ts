
import {BaseServerAnswerModel} from './base-server-answer.model';

import{AuthorModel} from './author.model';

export class AuthorsServerAnswerModel extends BaseServerAnswerModel {
    data: AuthorModel[];
}