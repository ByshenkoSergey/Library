import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {User, UserLogin} from '../interfaces/interfaces';
import {Observable} from "rxjs";
import {catchError, map} from 'rxjs/operators';
import {error} from "@angular/compiler/src/util";
import {ok} from "assert";


@Injectable({providedIn: 'root'})
export class UserService {

  private url = `${environment.apiUrl}/user`;

  constructor(private http: HttpClient) {
  }

  getUsers() {
    return this.http.get(this.url + '/gets');
  }

  getUser(id: number) {

    return this.http.get(this.url + '/get/' + id);
  }

  createUser(user: User): Observable<User> {
        return this.http.post<User>(this.url + '/post', user).pipe(catchError(err=>{
         if(err.status==201)
          {
            throw err.status=ok('ok')
         }
         console.log('no')
          throw err
        } ))
  }

  updateUser(id: number, user: User) {

    return this.http.put(this.url + '/put/' + id, user);
  }

  deleteUser(id: number) {
    return this.http.delete(this.url + '/delete' + id);
  }


}
