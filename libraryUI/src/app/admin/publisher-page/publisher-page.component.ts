import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {Publisher} from "../shared/interfaces/interfaces";
import {ActivatedRoute, Params} from "@angular/router";
import {switchMap} from "rxjs/internal/operators/switchMap";
import {PublisherService} from "../shared/services/publisher.service";

@Component({
  selector: 'app-publisher-page',
  templateUrl: './publisher-page.component.html',
  styleUrls: ['./publisher-page.component.scss']
})
export class PublisherPageComponent implements OnInit {

  publisher$: Observable<Publisher>

  constructor(
    private service: PublisherService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.publisher$ = this.route.params
      .pipe(switchMap((params: Params) => {
        return this.service.getPublisher(params['id'])
      }))

  }
}
