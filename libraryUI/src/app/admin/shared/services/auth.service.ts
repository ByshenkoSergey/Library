import {Injectable} from '@angular/core';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import {Observable, Subject, throwError} from 'rxjs';
import { environment } from 'src/environments/environment';
import {catchError, map} from 'rxjs/operators';
import {DbAuthResponse, ResponseObject, UserLogin} from '../interfaces/interfaces';
import {AlertService} from "./alertService";


@Injectable({providedIn: 'root'})
export class AuthService{

  public error$: Subject<string>=new Subject<string>()

constructor(
  private http: HttpClient,
  private alert: AlertService
  ){}

get token(): string{
  const  expDate = new Date(localStorage.getItem('expDate'))
  if(new Date()>expDate){
    this.logout();
    return null;
  }
  return localStorage.getItem('token');
}

get userRole(): string {
  const expDate = new Date(localStorage.getItem('expDate'))
  if (new Date() > expDate) {
    this.logout();
    return null;
  }
  return localStorage.getItem('role');
}

login(user: UserLogin): Observable<DbAuthResponse> {
 return this.http.post<DbAuthResponse>(`${environment.apiUrl}/user/token`, user)
   .pipe( map ( (response:any)=>{
       const modResponse = JSON.parse(response)
       console.log('parser')
       console.log(modResponse)
     this.setToken(modResponse);
   }),
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
    case 'User not found':
      this.error$.next('Пользователь не обнаружен')
      break
    case 'Invalid password':
      this.error$.next('Неверный пароль')
      break
  }
  return throwError(message)

}

private setToken(response: DbAuthResponse|null) {
    if(response) {
    const expDate = new Date(new Date().getTime() + +response.tokenExpiration*30000);
    localStorage.setItem('token', response.access_token);
    localStorage.setItem('expDate', expDate.toString());
    localStorage.setItem('role', response.userRole);
  } else {
    localStorage.clear();
  }
}
}
