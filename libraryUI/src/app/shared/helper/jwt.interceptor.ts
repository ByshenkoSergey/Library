import { Injectable } from '@angular/core';
import {HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import { AuthService } from 'src/app/admin/shared/services/auth.service';
import {Router} from "@angular/router";
import {catchError} from "rxjs/operators";


@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private Authorization: AuthService, private router: Router) { }

  intercept(request: HttpRequest<any>, next: HttpHandler):
    Observable<HttpEvent<any>> {

    if(this.Authorization.isAuthenticate())
    {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${this.Authorization.token}`
        }
      })
    }

    return next.handle(request)
      .pipe(
        catchError((error: HttpErrorResponse)=>{
          if(error.status===401){
            this.Authorization.logout()
            this.router.navigate(['/admin','login'],{
              queryParams:{
                authFailed: true
              }
            })
          }
         return throwError(error)
        })
      )
  }
}
