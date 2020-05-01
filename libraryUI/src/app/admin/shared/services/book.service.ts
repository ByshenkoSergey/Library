import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
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
          yearOfPublishing:list[key].yearOfPublishing,
          publishingHouseName:list[key].publishingHouseName
        }))
     }));
       }

  getBookLight(id: number): Observable<Book> {
   return this.http.get<Book>(this.url + '/get/lightform/' + id);
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
        publishingHouseName:book.publishingHouseName
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
