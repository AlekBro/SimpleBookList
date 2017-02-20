import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BooksComponent } from './components/books/books.component';

import { BooksService } from './services/books.service';

@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [
    BooksComponent
  ],
  providers: [
    BooksService
  ]

})
export class BooksModule { }
