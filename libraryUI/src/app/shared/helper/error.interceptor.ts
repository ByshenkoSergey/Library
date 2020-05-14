import {Injectable} from '@angular/core';
import {HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpResponse, HttpEventType} from '@angular/common/http';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {AuthService} from 'src/app/admin/shared/services/auth.service';
import {Router} from "@angular/router";
import {AlertService} from 'src/app/admin/shared/services/alertService';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {


  modEvent: any

  constructor(
    private authService: AuthService,
    private router: Router,
    private alert: AlertService) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(map(event => {

      if (event instanceof HttpResponse) {
        console.log('event')
        console.log(event)
        const responseMessage = event.body['message']
        console.log('message')
        console.log(responseMessage)
        this.alert.success(responseMessage)
        const responseObject = event.body['responseObject']
        console.log('object')
        console.log(responseObject)
        if (responseObject != null) {
          console.log('if')
          this.modEvent = event.clone({body: responseObject});
          console.log(this.modEvent)
          console.log("next")
          return this.modEvent;
        } else if(responseMessage!=null) {
          console.log('null')
          this.modEvent = event.clone({body: 'ok'});
          return this.modEvent;
        } else {
          return event
        }
      } else {
        return event
      }
    }), catchError(err => {

      if (err.status === 401) {
        this.authService.logout();
        this.alert.warning('')
        this.router.navigate(['/', 'login'], {
          queryParams: {
            authFailed: true
          }
        })
      }

      if (err.status === 400) {

        this.alert.danger(`${err.message}`)
      }

      if (err.status === 404)//not found
      {
        this.alert.warning(`${err.message}`)
      }
      console.log('error')
      const error = err.error.message || err.statusText;
      return next.handle(request);
    }))
  }
}
