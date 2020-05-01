import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {MainLayoutComponent} from './shared/componets/main-layout/main-layout.component';

const routes: Routes = [
{
  path: '', component: MainLayoutComponent, children: [
    {path: '', redirectTo: '/', pathMatch: 'full'},
    //{path: '', component: HomePageComponent},
   ]
},
  {
    path: 'admin', loadChildren: './admin/admin.module#AdminModule'
      }
   ];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
