import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from 'src/environments/environment';
import {User} from '../interfaces/interfaces';
import {Observable} from "rxjs";
import {catchError} from 'rxjs/operators';
import {ok} from "assert";


@Injectable({providedIn: 'root'})
export class UserService {

  private url = `${environment.apiUrl}/user`;

  constructor(private http: HttpClient) {
  }

  getUsers() {
    return this.http.get(this.url + '/gets');
  }

  getUser(id: number): Observable<User> {

    return this.http.get<User>(this.url + '/get/' + id);
  }

  createUser(user: User): Observable<User> {
    return this.http.post<User>(this.url + '/post', user).pipe(catchError(err => {
      if (err.status == 201) {
        throw err.status = ok('ok')
      }
      throw err
    }))
  }

  updateUser(user: User): Observable<any> {
    return this.http.put<any>(this.url + '/put/' + user.userId, user);
  }

  deleteUser(id: number): Observable<any> {
    return this.http.delete<any>(this.url + '/delete/' + id);
  }


}
