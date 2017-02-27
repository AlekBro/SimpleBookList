import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthorsComponent } from './components/authors/authors.component';

import { AuthorService } from './services/authors.service';
import { AuthorViewComponent } from './components/author-view/author-view.component';


@NgModule({
  imports: [
    CommonModule,
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

  constructor(){

  }

}
