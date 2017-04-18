export class AuthorViewModel {
    Id: number;
    FirstName: string;
    LastName: string;
    BooksNumber: number;
    Name: string;
    IsUserHasRightForEdit: boolean;

    constructor() {
        this.Id = -1;
        this.FirstName = null;
        this.LastName = null;
        this.Name = null;
    }
}