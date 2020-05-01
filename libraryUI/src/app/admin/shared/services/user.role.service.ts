import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserRole } from '../interfaces/interfaces';

@Injectable()

export class UserRoleService {

  private url = `${environment.apiUrl}/account/userrole`;

  constructor(private http: HttpClient) {
  }

  getUserRoles() {
    return this.http.get(this.url + '/gets');
  }

  getUserRole(id: number) {

    return this.http.get(this.url + '/get' + id);
  }

  createUserRole(role: UserRole) {
    return this.http.post(this.url + '/post', {role}, {observe: 'response'});
  }
  updateUserRole(role: UserRole) {

    return this.http.put(this.url + '/put', {role});
  }
  deleteUserRole(id: number) {
    return this.http.delete(this.url + '/delete' + id);
  }
}
