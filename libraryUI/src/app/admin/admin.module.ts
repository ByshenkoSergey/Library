import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import {AdminLayoutComponent} from './shared/components/admin-layout/admin-layout.component';
import {LoginPageComponent} from './login-page/login-page.component';
import {BookopenPageComponent} from './bookopen-page/bookopen-page.component';
import {PublishinghousePageComponent} from './publishinghouse-page/publishinghouse-page.component';
import {AuthorPageComponent} from './author-page/author-page.component';
import {BookaddPageComponent} from './bookadd-page/bookadd-page.component';
import { DashboardPageComponent } from './dashboard-page/dashboard-page.component';
import { AuthService } from './shared/services/auth.service';
import {SharedModule} from '../shared/shared.module';


@NgModule({
  declarations: [
    AdminLayoutComponent,
    LoginPageComponent,
    DashboardPageComponent,
    BookopenPageComponent,
    PublishinghousePageComponent,
    AuthorPageComponent,
    BookaddPageComponent
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
          {path: 'dashboard', component: DashboardPageComponent},
          {path: 'book/:id', component: BookopenPageComponent },
          {path: 'publishing/:id', component: PublishinghousePageComponent},
          {path: 'author/:id', component: AuthorPageComponent },
          {path: 'book', component: BookaddPageComponent }
        ]
      }
    ])
  ],
  exports: [RouterModule],
  providers: [AuthService]
  })
export class AdminModule {
}
