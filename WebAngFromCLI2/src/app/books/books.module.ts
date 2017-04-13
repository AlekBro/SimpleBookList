import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgxDatatableModule } from '@swimlane/ngx-datatable';

import { BooksComponent } from './components/books/books.component';
import { BookViewComponent } from './components/book-view/book-view.component';

import { BooksService } from './services/books.service';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
  ],
  declarations: [
    BooksComponent,
    BookViewComponent
  ],
  providers: [
    BooksService
  ]

})
export class BooksModule { }
