import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import {AdminLayoutComponent} from './shared/components/admin-layout/admin-layout.component';
import {LoginPageComponent} from './login-page/login-page.component';
import {BookopenPageComponent} from './bookopen-page/bookopen-page.component';
import {PublishinghousePageComponent} from './publishinghouse-page/publishinghouse-page.component';
import {AuthorPageComponent} from './author-page/author-page.component';
import {BookAddPageComponent} from './bookadd-page/bookadd-page.component';
import { DashboardPageComponent } from './dashboard-page/dashboard-page.component';
import {SharedModule} from '../shared/shared.module';
import {AuthGuard} from "./shared/services/auth.guard";
import {SearchPipe} from "./shared/Pipe/search.pipe";
import { BookEditPageComponent } from './bookedit-page/bookedit-page.component';


@NgModule({
  declarations: [
    AdminLayoutComponent,
    LoginPageComponent,
    DashboardPageComponent,
    BookopenPageComponent,
    PublishinghousePageComponent,
    AuthorPageComponent,
    BookAddPageComponent,
    SearchPipe,
    BookEditPageComponent

  ],
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      {
        path: '', component: AdminLayoutComponent, children: [
          {path: '', redirectTo: '/admin/login', pathMatch: 'full'},
          {path: 'login', component: LoginPageComponent},
          {path: 'dashboard', component: DashboardPageComponent, canActivate:[AuthGuard]},
          {path: 'book/:id', component: BookopenPageComponent, canActivate:[AuthGuard] },
          {path: 'publishing/:id', component: PublishinghousePageComponent, canActivate:[AuthGuard]},
          {path: 'author/:id', component: AuthorPageComponent, canActivate:[AuthGuard] },
          {path: 'book', component: BookAddPageComponent, canActivate:[AuthGuard] },
          {path: 'book/edit/:id', component: BookEditPageComponent, canActivate:[AuthGuard]}
        ]
      }
    ])
  ],
  exports: [RouterModule],
  providers: [AuthGuard]
  })
export class AdminModule {
}
