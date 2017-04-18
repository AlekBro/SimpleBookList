import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AuthorsModule } from './authors/authors.module'
import { BooksModule } from './books/books.module';
import { CoreModule } from './core/core.module'

import { AppComponent } from './app.component';

import { routing } from './app.routing';

import { ModalModule } from 'angular2-modal';
import { BootstrapModalModule } from 'angular2-modal/plugins/bootstrap';

import * as $ from 'jquery';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ModalModule.forRoot(),
    BootstrapModalModule,
    routing,
    AuthorsModule,
    BooksModule,
    CoreModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
