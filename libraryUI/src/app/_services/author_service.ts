import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {Author} from '../_models/author';

@Injectable()
// tslint:disable-next-line:class-name
export class Author_service {

  private url = `${environment.apiUrl}/author`;

  constructor(private http: HttpClient) {
  }

  getAuthors() {
    return this.http.get(this.url + '/gets');
  }

  getAuthor(id: number) {

    return this.http.get(this.url + '/get' + id);
  }

  createAuthor(author: Author) {
    return this.http.post(this.url + '/post', {author}, {observe: 'response'});
  }
  updateAuthor(id: number, author: Author) {

    return this.http.put(this.url + '/put' + id, {author});
  }
  deleteAuthor(id: number) {
    return this.http.delete(this.url + '/delete' + id);
  }
}
