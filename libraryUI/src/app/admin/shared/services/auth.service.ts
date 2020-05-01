import {Injectable} from '@angular/core';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import {Observable, Observer, Subject, throwError} from 'rxjs';
import { environment } from 'src/environments/environment';
import {catchError, tap} from 'rxjs/operators';
import { DbAuthResponse, UserLogin } from '../interfaces/interfaces';


@Injectable({providedIn: 'root'})
export class AuthService{

  public error$: Subject<string>=new Subject<string>()

constructor(private http: HttpClient){}

get token(): string{
  const  expDate = new Date(localStorage.getItem('expDate'))
  if(new Date()>expDate){
    this.logout();
    return null;
  }
  return localStorage.getItem('token');
}

login(user: UserLogin): Observable<any> {
 return this.http.post(`${environment.apiUrl}/account/token`, user)
   .pipe(
     tap(this.setToken),
     catchError(this.handleError.bind(this))
   );
}

logout(){
this.setToken(null)
}

isAuthenticate(): boolean {
 return !!this.token;
}

private handleError(error: HttpErrorResponse){
  const message: string = error.error

  switch (message) {
    case 'User_not_foud':
      this.error$.next('Пользователь не обнаружен')
      break
    case 'Invalid_password':
      this.error$.next('Неверный пароль')
      break
  }
  return throwError(message)

}

private setToken(response: DbAuthResponse|null) {
  if(response) {
    const expDate = new Date(new Date().getTime() + +response.tokenExpiration*60000);
    localStorage.setItem('token', response.access_token);
    localStorage.setItem('expDate', expDate.toString());
  } else {
    localStorage.clear();
  }
}
}
