import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { CommonModule } from '@angular/common';

import { NotFoundPageComponent } from './components/not-found-page/not-found-page.component';
import { MenuComponent } from './components/menu/menu.component';

import { RouterModule } from '@angular/router';
import { AboutPageComponent } from './components/about-page/about-page.component';
import { ContactPageComponent } from './components/contact-page/contact-page.component';

@NgModule({
    declarations: [
        NotFoundPageComponent,
        MenuComponent,
        AboutPageComponent,
        ContactPageComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        RouterModule,
        CommonModule,
    ],
    providers: [

    ],
    exports: [
        MenuComponent
    ],
})
export class CoreModule { }
