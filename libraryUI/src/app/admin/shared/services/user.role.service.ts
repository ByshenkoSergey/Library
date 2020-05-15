import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserRole } from '../interfaces/interfaces';
import {Observable} from "rxjs";

@Injectable({providedIn: 'root'})

export class UserRoleService {

  private url = `${environment.apiUrl}/userrole`;

  constructor(private http: HttpClient) {
  }

  getUserRoles():Observable<UserRole[]> {
    return this.http.get<UserRole[]>(this.url + '/gets');
  }


}
