import {Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserLogin } from 'src/app/_models/user_login';
import {Observable, Observer} from 'rxjs';
import { environment } from 'src/environments/environment';
import {tap} from 'rxjs/operators';

@Injectable()
export class AuthService{
constructor(private http: HttpClient){}

get token(): string{
  return'';
}

login(user: UserLogin): Observable<any> {
 return this.http.post(`${environment.apiUrl}/account/token`, user)
   .pipe(
     tap(this.setToken)
   );
}

logout(){

}

isAuthenticate(): boolean {
 return !!this.token;
}

private setToken(response) {
console.log(response);
}
}
