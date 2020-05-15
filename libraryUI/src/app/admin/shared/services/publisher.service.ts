import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {Publisher} from "../interfaces/interfaces";
import {map} from "rxjs/operators";
import {Observable} from "rxjs";

@Injectable({providedIn: 'root'})

export class PublisherService {

  private url = `${environment.apiUrl}/publisher`;

  constructor(private http: HttpClient) {
  }

  getPublishers() {
    return this.http.get(this.url + '/gets');
  }

  getPublisher(id: number): Observable<Publisher> {
    return this.http.get<Publisher>(this.url + '/get/' + id)
      .pipe(map((response:any)=>{
        return {
          ...response,
          publisherId:response.publisherId,
          publisherName:response.publisherName,
          publisherEmail:response.publisherEmail,
          publisherTellNumber:response.publisherTellNumber,
          publisherInfo:response.publisherInfo,
        }
      }));
  }

  updatePublisher(publisher: Publisher):Observable<void> {
    return this.http.put<void>(this.url + '/put/' + publisher.publisherId, publisher);
  }
  deletePublisher(id: number):Observable<void> {
    return this.http.delete<void>(this.url + '/delete/' + id);
  }
}
