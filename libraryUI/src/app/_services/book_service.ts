import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BookForm } from '../_models/book_form';
import { environment } from 'src/environments/environment';
import {BookAdd} from '../_models/book_add';

@Injectable()
// tslint:disable-next-line:class-name
export class Book_service {

  private url = `${environment.apiUrl}/book`;

  constructor(private http: HttpClient) {
  }

  getBooks() {
    return this.http.get(this.url + '/gets');
  }

  getBook(id: number) {
    return this.http.get(this.url + '/get' + id);
  }

  createBook(book: BookAdd) {
    return this.http.post(this.url + '/post', {book}, {observe: 'response'});
  }
  updateBook(book: BookForm) {

    return this.http.put(this.url + '/put', {book});
  }
  deleteBook(id: number) {
    return this.http.delete(this.url + '/delete' + id);
  }
}
