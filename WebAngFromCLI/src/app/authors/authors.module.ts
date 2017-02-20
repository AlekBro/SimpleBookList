import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthorsComponent } from './components/authors/authors.component';

import { AuthorService } from './services/authors.service';


@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [
    AuthorsComponent
    ],
    providers: [
    AuthorService
  ]
})
export class AuthorsModule { 

  constructor(){

  }

}
