import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {User, UserLogin} from '../interfaces/interfaces';
import {Observable} from "rxjs";


@Injectable({providedIn: 'root'})
export class UserService {

  private url = `${environment.apiUrl}/account/user`;

  constructor(private http: HttpClient) {
  }

  getUsers() {
    return this.http.get(this.url + '/gets');
  }

  getUser(id: number) {

    return this.http.get(this.url + '/get' + id);
  }

  createUser(user: User): Observable<User> {
    console.log(user)
    return this.http.post<User>(this.url + '/post', user);
  }

  updateUser(id: number, user: User) {

    return this.http.put(this.url + '/put' + id, {user});
  }

  deleteUser(id: number) {
    return this.http.delete(this.url + '/delete' + id);
  }

  GetToken(userLogin: UserLogin) {
    return this.http.post(this.url + '/token', {userLogin}, {observe: 'response'});
  }
}
