import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {PublishingHouse} from "../interfaces/interfaces";

@Injectable()

export class PublishingHouseService {

  private url = `${environment.apiUrl}/publishinghouse`;

  constructor(private http: HttpClient) {
  }

  getPublishingHouses() {
    return this.http.get(this.url + '/gets');
  }

  getPublishingHouse(id: number) {

    return this.http.get(this.url + '/get' + id);
  }

  createPublishingHouse(pHouse: PublishingHouse) {
    return this.http.post(this.url + '/post', {pHouse}, {observe: 'response'});
  }
  updatePublishingHouse(pHouse: PublishingHouse) {

    return this.http.put(this.url + '/put', {pHouse});
  }
  deletePublishingHouse(id: number) {
    return this.http.delete(this.url + '/delete' + id);
  }
}
