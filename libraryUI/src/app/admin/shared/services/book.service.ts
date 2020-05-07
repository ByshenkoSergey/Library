import { Injectable } from '@angular/core';
import {HttpClient, HttpEventType} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {Book, BookAdd, BookForm} from "../interfaces/interfaces";
import {Observable} from "rxjs";
import { map } from 'rxjs/operators';

@Injectable({providedIn: 'root'})

export class BookService {

  private url = `${environment.apiUrl}/book`;

  constructor(private http: HttpClient) {}

  getBooks(): Observable<BookForm[]> {
     return this.http.get(this.url + '/gets')
      .pipe(map((response:{[key: string]:any})=>{
       let list:{[key: string]:any} = response["value"]
         return Object.keys(list).map(key=>({
         ...list[key],
          bookId:list[key].bookId,
          bookName:list[key].bookName,
          bookFileAddress:list[key].bookFileAddress,
          authorName:list[key].authorName,
           authorId:list[key].authorId,
          yearOfPublishing:list[key].yearOfPublishing,
           publisherName:list[key].publisherName,
           publisherId:list[key].publisherId
        }))
     }));
       }

  getBookFile(id: number): Observable<any> {
    return this.http.get<any>(this.url + '/get/' + id)
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
                const book = response["value"]
            return {
        ...book,
        bookId:id,
        bookName:book.bookName,
        authorName:book.authorName,
        yearOfPublishing:book.yearOfPublishing,
        publisherName:book.publisherName
      }
    }));
  }

  create(book: BookAdd): Observable<BookAdd> {
    return this.http.post<BookAdd>(this.url + '/post', book)
  }

  updateBook(book: BookAdd): Observable<BookAdd> {
    return this.http.put<BookAdd>(this.url + '/put/'+ book.bookId, book);
  }

  deleteBook(id: number):Observable<void> {
    return this.http.delete<void>(this.url + '/delete/' + id);
  }
}
