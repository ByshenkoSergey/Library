import {Injectable} from '@angular/core';
import {HttpClient, HttpEvent, HttpRequest} from '@angular/common/http';
import {environment} from 'src/environments/environment';
import {BookAdd, BookForm} from "../interfaces/interfaces";
import {Observable} from "rxjs";
import {map} from 'rxjs/operators';

@Injectable({providedIn: 'root'})

export class BookService {

  private url = `${environment.apiUrl}/book`;

  constructor(private http: HttpClient) {
  }

  getBooks(): Observable<BookForm[]> {
    return this.http.get<BookForm[]>(this.url + '/gets')
      .pipe(map((response: { [key: string]: any }) => {
        return Object.keys(response).map(key => ({
          ...response[key],
          bookId: response[key].bookId,
          bookName: response[key].bookName,
          authorName: response[key].authorName,
          authorId: response[key].authorId,
          yearOfPublishing: response[key].yearOfPublishing,
          publisherName: response[key].publisherName,
          publisherId: response[key].publisherId
        }))
      }));
  }

  getBookFile(id: number): Observable<HttpEvent<Blob>> {
    return this.http.request(new HttpRequest(
      'GET',
      this.url + '/get/file/' + id,
      null,
      {
        reportProgress: true,
        responseType: 'blob'
      }
    ));
  }


  uploadBook(data: FormData): Observable<any> {
    return this.http.post<FormData>(this.url + '/upload/post', data);
  }

  getBook(id: number): Observable<BookAdd> {
    return this.http.get(this.url + '/get/form/' + id)
      .pipe(map((response: any) => {
        return {
          ...response,
          bookId: id,
          bookName: response.bookName,
          authorName: response.authorName,
          yearOfPublishing: response.yearOfPublishing,
          publisherName: response.publisherName
        }
      }));
  }

  create(book: BookAdd): Observable<any> {
    return this.http.post<any>(this.url + '/post', book)
  }

  updateBook(book: BookAdd): Observable<void> {
    return this.http.put<void>(this.url + '/put/' + book.bookId, book);
  }

  deleteBook(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/delete/' + id);
  }
}
