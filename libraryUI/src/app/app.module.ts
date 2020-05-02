import { BrowserModule } from '@angular/platform-browser';
import {NgModule, Provider} from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainLayoutComponent } from './shared/components/main-layout/main-layout.component';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {AdminModule} from './admin/admin.module';
import {SharedModule} from './shared/shared.module';
import {JwtInterceptor} from "./shared/helper/jwt.interceptor";
import {HomePageComponent} from "./home-page/home-page.component";
import { RegisterPageComponent } from './register-page/register-page.component';


const INTERCEPTOR_PROVIDER: Provider = {
  provide: HTTP_INTERCEPTORS,
  multi: true,
  useClass: JwtInterceptor
 }

@NgModule({
  declarations: [
    AppComponent,
    MainLayoutComponent,
    HomePageComponent,
    RegisterPageComponent

      ],
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        AppRoutingModule,
        FormsModule,
      HttpClientModule,
      AdminModule,
      SharedModule
    ],
  providers: [INTERCEPTOR_PROVIDER],
  bootstrap: [AppComponent]
})
export class AppModule { }
