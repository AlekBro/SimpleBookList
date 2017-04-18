import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthorsComponent } from './authors/components/authors/authors.component';
import { BooksComponent } from './books/components/books/books.component';
import { MenuComponent } from 'app/core/components/menu/menu.component';

import { AuthorViewComponent } from './authors/components/author-view/author-view.component';
import { AuthorAddEditComponent } from './authors/components/author-add-edit/author-add-edit.component';

import { NotFoundPageComponent } from './core/components/not-found-page/not-found-page.component';
import { AboutPageComponent } from './core/components/about-page/about-page.component';
import { ContactPageComponent } from './core/components/contact-page/contact-page.component';

const appRoutes: Routes = [
    {
        path: '',
        component: MenuComponent,

        children: [
            { path: '', component: BooksComponent },
            { path: 'books', component: BooksComponent },
            { path: 'authors', component: AuthorsComponent },
        ]
    },
    {
        path: 'books',
        component: BooksComponent
    },
    {
        path: 'authors',
        component: AuthorsComponent
    },
    {
        path: 'About',
        component: AboutPageComponent
    },
    {
        path: 'Contact',
        component: ContactPageComponent
    },
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