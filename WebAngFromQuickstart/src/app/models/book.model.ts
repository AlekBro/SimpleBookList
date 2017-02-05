
import {AuthorModel} from './author.model';

export class BookModel {
    Id: number;
    Name: string;
    ReleaseDate: string;
    FormattedReleaseDate: Date;
    Pages: number;
    Rating: number;
    Publisher: string;
    ISBN: string;
    Authors: AuthorModel[];
    AuthorsIds: string;
    AuthorsNames: string;
    IsUserHasRightForEdit: boolean;
}