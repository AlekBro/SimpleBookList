import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { CommonModule } from '@angular/common';

import { NotFoundPageComponent } from './components/not-found-page/not-found-page.component';

@NgModule({
    declarations: [
        NotFoundPageComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        CommonModule,

    ],
    providers: [

    ],
    exports: [

    ],
})
export class CoreModule { }
