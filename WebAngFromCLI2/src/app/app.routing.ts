import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthorsComponent } from './authors/components/authors/authors.component';
import { BooksComponent } from './books/components/books/books.component';
//import {AboutComponent} from './components/about/about.component';

import { AuthorViewComponent } from './authors/components/author-view/author-view.component';

import { NotFoundPageComponent } from './core/components/not-found-page/not-found-page.component';

const appRoutes: Routes = [

    {
        path: '',
        component: BooksComponent
    },
    {
        path: 'books',
        component: BooksComponent
    },
    {
        path: 'authors',
        component: AuthorsComponent
    },
    /*
    {
        path: 'book/:id',
        component:BookComponent
    },
    */
    {
        path: 'author/:authorId',
        component: AuthorViewComponent
    },
    /*
    {
        path: 'authors/add',
        component: AuthorAddComponent
    },
    /*
    {
        path: 'authors/edit/:id',
        component: AuthorEditComponent
    },
    */
    {
        path: '404',
        component: NotFoundPageComponent
    },
    {
        path: '**',
        redirectTo: '/404',
        pathMatch: 'full'
    },
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);