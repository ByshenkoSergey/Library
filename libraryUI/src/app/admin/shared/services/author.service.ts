import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {Author} from "../interfaces/interfaces";
import {Observable} from "rxjs";
import {map} from "rxjs/operators";


@Injectable({providedIn: 'root'})
export class AuthorService {

  private url = `${environment.apiUrl}/author`;

  constructor(private http: HttpClient) {
  }

  getAuthors() {
    return this.http.get(this.url + '/gets');
  }

  getAuthor(id: number): Observable<Author> {
       return this.http.get<Author>(this.url + '/get/' + id)
      .pipe(map((response:any)=>{
                      return {
        ...response,
        authorId:response.authorId,
        authorName:response.authorName,
        authorBiography:response.authorBiography,
       }
    }));
  }

  updateAuthor(author: Author): Observable<any> {
    return this.http.put<any>(this.url + '/put/' + author.authorId, author);
  }

  deleteAuthor(id: number) {
    return this.http.delete(this.url + '/delete/' + id);
  }
}
