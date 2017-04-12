
import { AuthorViewModel } from '../../../app/authors/models/AuthorViewModel';

export class BookViewModel {
    Id: number;
    Name: string;
    ReleaseDate: Date;
    FormattedReleaseDate: string;
    Pages: number;
    Rating: number;
    Publisher: string;
    ISBN: string;
    Authors: AuthorViewModel[];
    AuthorsIds: number[];
    AuthorsNames: string;
    IsUserHasRightForEdit: boolean;

    constructor() {
        this.Id = -1;
        this.Name = null;

        this.Authors = new Array<AuthorViewModel>();
    }
}