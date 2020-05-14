import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import {AdminLayoutComponent} from './shared/components/admin-layout/admin-layout.component';
import {LoginPageComponent} from '../login-page/login-page.component';
import {PublisherPageComponent} from './publisher-page/publisher-page.component';
import {AuthorPageComponent} from './author-page/author-page.component';
import {BookAddPageComponent} from './book.add-page/book.add-page.component';
import {DashboardPageComponent} from './dashboard-page/dashboard-page.component';
import {SharedModule} from '../shared/shared.module';
import {AuthGuard} from "./shared/services/auth.guard";
import {SearchPipe} from "./shared/Pipe/search.pipe";
import {BookEditPageComponent} from './book.edit-page/book.edit-page.component';
import {BookOpenPageComponent} from './book.open-page/book.open-page.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import {NgxPaginationModule} from "ngx-pagination";
import { PublishersPageComponent } from './publishers-page/publishers-page.component';
import { AuthorsPageComponent } from './authors-page/authors-page.component';
import { UsersPageComponent } from './users-page/users-page.component';
import {UserRolesPageComponent} from "./user.roles-page/user.roles-page.component";



@NgModule({
  declarations: [
    AdminLayoutComponent,
    LoginPageComponent,
    DashboardPageComponent,
    PublisherPageComponent,
    AuthorPageComponent,
    BookAddPageComponent,
    SearchPipe,
    BookEditPageComponent,
    BookOpenPageComponent,
    ProfilePageComponent,
    PublishersPageComponent,
    AuthorsPageComponent,
    UsersPageComponent,
    UserRolesPageComponent

  ],
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    RouterModule.forChild([
      {
        path: '', component: AdminLayoutComponent, children: [
          {path: '', redirectTo: 'src/app/login', pathMatch: 'full'},

          {path: 'dashboard', component: DashboardPageComponent, canActivate:[AuthGuard]},
          {path: 'book/:id', component: BookOpenPageComponent, canActivate:[AuthGuard] },
          {path: 'publishing/:id', component: PublisherPageComponent, canActivate:[AuthGuard]},
          {path: 'author/:id', component: AuthorPageComponent, canActivate:[AuthGuard] },
          {path: 'book', component: BookAddPageComponent, canActivate:[AuthGuard] },
          {path: 'book/edit/:id', component: BookEditPageComponent, canActivate:[AuthGuard]},
          {path: 'user/edit/:id', component:ProfilePageComponent, canActivate:[AuthGuard]},
          {path: 'authors', component:AuthorsPageComponent, canActivate:[AuthGuard]},
          {path: 'publishers', component:PublishersPageComponent, canActivate:[AuthGuard]},
          {path: 'users', component:UsersPageComponent, canActivate:[AuthGuard]},
          {path: 'userroles', component:UserRolesPageComponent, canActivate:[AuthGuard]},

        ]
      }
    ])
  ],
  exports: [RouterModule],
  providers: [AuthGuard]
  })
export class AdminModule {
}
