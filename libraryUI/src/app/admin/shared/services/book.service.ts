import { Injectable } from '@angular/core';
import {HttpClient, HttpEvent, HttpEventType} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {Book, BookAdd, BookForm, ResponseObject} from "../interfaces/interfaces";
import {Observable} from "rxjs";
import { map } from 'rxjs/operators';

@Injectable({providedIn: 'root'})

export class BookService {

  private url = `${environment.apiUrl}/book`;

  constructor(private http: HttpClient) {}

  getBooks(): Observable<BookForm[]> {
     return this.http.get<BookForm[]>(this.url + '/gets')
      .pipe(map((response:{[key: string]:any})=>{
        return Object.keys(response).map(key=>({
         ...response[key],
          bookId:response[key].bookId,
          bookName:response[key].bookName,
          bookFileAddress:response[key].bookFileAddress,
          authorName:response[key].authorName,
           authorId:response[key].authorId,
          yearOfPublishing:response[key].yearOfPublishing,
           publisherName:response[key].publisherName,
           publisherId:response[key].publisherId
        }))
     }));
       }

  getBookLight(id: number): Observable<Book> {
    return this.http.get<Book>(this.url + '/get/lightForm/' + id)
      .pipe(map((response:any)=>{
        return {
          ...response,
          bookId:response.bookId,
          bookName:response.bookName,
          bookText:response.bookText
        }
      }));
  }



  uploadBook(data: FormData){
   return this.http.post<any>(this.url+'/upload/post', data,
     {reportProgress: true, observe:'events'}).pipe(map(event => {
     switch (event.type) {
       case HttpEventType.UploadProgress:
          break;
       case HttpEventType.Response:
         return event;
     }
   }));
  }

  getBook(id: number): Observable<BookAdd> {
    return this.http.get(this.url + '/get/form/' + id)
      .pipe(map((response:any)=>{
           return {
        ...response,
        bookId:id,
        bookName:response.bookName,
        authorName:response.authorName,
        yearOfPublishing:response.yearOfPublishing,
        publisherName:response.publisherName
      }
    }));
  }

  create(book: BookAdd): Observable<BookAdd> {
    return this.http.post<BookAdd>(this.url + '/post', book)
  }

  updateBook(book: BookAdd): Observable<void> {
    console.log(book.bookId)
    return this.http.put<void>(this.url + '/put/'+ book.bookId, {book}).pipe(map(res=>{
      console.log(res)
      return res
    }));
  }

  deleteBook(id: number):Observable<void> {
    return this.http.delete<void>(this.url + '/delete/' + id);
  }
}
