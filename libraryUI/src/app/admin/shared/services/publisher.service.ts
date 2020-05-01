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

  createPublisher(publisher: Publisher) {
    return this.http.post(this.url + '/post', publisher, {observe: 'response'});
  }
  updatePublisher(publisher: Publisher) {

    return this.http.put(this.url + '/put', publisher);
  }
  deletePublisher(id: number) {
    return this.http.delete(this.url + '/delete' + id);
  }
}
