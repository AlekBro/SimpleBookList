import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgxDatatableModule } from '@swimlane/ngx-datatable';

import { BooksComponent } from './components/books/books.component';
import { BookViewComponent } from './components/book-view/book-view.component';

import { BooksService } from './services/books.service';
import { BookAddEditComponent } from './components/book-add-edit/book-add-edit.component';

import { NKDatetimeModule } from 'ng2-datetime/ng2-datetime';

import { MultiselectDropdownModule } from 'angular-2-dropdown-multiselect';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule,
    NKDatetimeModule,
    MultiselectDropdownModule
  ],
  declarations: [
    BooksComponent,
    BookViewComponent,
    BookAddEditComponent
  ],
  providers: [
    BooksService
  ]

})
export class BooksModule { }
