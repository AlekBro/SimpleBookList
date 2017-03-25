import { Component, OnInit } from '@angular/core';

import { BooksService } from '../../services/books.service';

import { BookViewModel } from '../../models/BookViewModel';

import { DTResult } from '../../../../app/core/models/DTResult';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  constructor(private _booksService: BooksService) { }

  Books: DTResult<BookViewModel>;

  ngOnInit() {
    this._booksService.getBooks()
      .then(Books => {
        this.Books = Books;

        console.log(this.Books);
      })
      .catch((ex) => {
        this.handleError(ex);
      });;

  }

  handleError(error: any) {
    //this.isError = true;

    console.log(error);

    return Promise.resolve();
  }
}
