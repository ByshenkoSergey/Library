import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError} from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from 'src/app/admin/shared/services/auth.service';
import {Router} from "@angular/router";
import {AlertService} from 'src/app/admin/shared/services/alertService';



@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(
    private authService: AuthService,
    private router:Router,
    private alert:AlertService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {
      if (err.status === 401) {  // not auth
        this.authService.logout();
        this.alert.warning('')
        this.router.navigate(['/','login'],{
          queryParams:{
            authFailed: true
          }
        })
      }

      //if (err.status===201)//create
    //  {
     //   console.log(563737373)
    //    this.alert.success(`Is added`)
     //   return  next.handle(request.body)
    //  }

      if(err.status === 200)//ok
      {
        this.alert.success(`Operation completed`)
        next.handle(request)
      }

      if (err.status === 400)//bad request
      {
         this.alert.danger(`${err.message}`)
      }

      if(err.status === 404)//not found
      {
         this.alert.warning(`${err.message}`)
      }

      //Unknown error
      const error = err.error.message || err.statusText;
      return next.handle(request);
    }))
  }
}
