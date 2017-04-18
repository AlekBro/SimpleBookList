import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthorsComponent } from './components/authors/authors.component';
import { AuthorViewComponent } from './components/author-view/author-view.component';
import { AuthorAddEditComponent } from './components/author-add-edit/author-add-edit.component';

import { AuthorService } from './services/authors.service';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgxDatatableModule
  ],
  declarations: [
    AuthorsComponent,
    AuthorViewComponent,
    AuthorAddEditComponent,
  ],
  providers: [
    AuthorService
  ]
})
export class AuthorsModule {

  constructor() {
  }

}
