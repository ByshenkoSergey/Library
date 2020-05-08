import { Injectable } from '@angular/core';
import {HttpRequest, HttpHandler, HttpEvent, HttpInterceptor} from '@angular/common/http';
import {Router} from "@angular/router";
import {Observable} from 'rxjs';
import { AuthService } from 'src/app/admin/shared/services/auth.service';



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
  }
}
