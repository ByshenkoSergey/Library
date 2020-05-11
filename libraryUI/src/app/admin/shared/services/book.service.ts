import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {BookAdd, BookFile, BookForm} from "../interfaces/interfaces";
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

  getBookFile(id: number): Observable<BookFile> {
    return this.http.get<BookFile>(this.url + '/get/file/' + id)
      .pipe(map((response:BookFile)=>{
        console.log("response")
        console.log(response)
        return {
          ...response,
          fileName:response.fileName,
          filePath:response.filePath,
          file:response.file
        }
      }));
  }



  uploadBook(data: FormData):Observable<any>{
   return this.http.post<FormData>(this.url+'/upload/post', data);
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

  create(book: BookAdd): Observable<any> {
    return this.http.post<any>(this.url + '/post', book)
  }

  updateBook(book: BookAdd): Observable<void> {
    console.log(book.bookId)
    return this.http.put<void>(this.url + '/put/'+ book.bookId, book);
  }

  deleteBook(id: number):Observable<void> {
    return this.http.delete<void>(this.url + '/delete/' + id);
  }
}
