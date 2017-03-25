import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthorsComponent } from './components/authors/authors.component';
import { AuthorViewComponent } from './components/author-view/author-view.component';


import { AuthorService } from './services/authors.service';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  declarations: [
    AuthorsComponent,
    AuthorViewComponent
    
    
  ],
  providers: [
    AuthorService
  ]
})
export class AuthorsModule {

  constructor() {

  }

}
