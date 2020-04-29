import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {User} from '../_models/user';
import {UserLogin} from '../_models/user_login';

@Injectable()
// tslint:disable-next-line:class-name
export class User_service {

  private url = `${environment.apiUrl}/account/user`;

  constructor(private http: HttpClient) {
  }

  getUsers() {
    return this.http.get(this.url + '/gets');
  }

  getUser(id: number) {

    return this.http.get(this.url + '/get' + id);
  }

  createUser(user: User) {
    return this.http.post(this.url + '/post', {user}, {observe: 'response'});
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
