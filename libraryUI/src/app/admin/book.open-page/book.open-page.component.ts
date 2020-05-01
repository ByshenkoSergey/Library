import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {ActivatedRoute, Params} from "@angular/router";
import {switchMap} from "rxjs/internal/operators/switchMap";
import {BookService} from "../shared/services/book.service";
import {Book} from "../shared/interfaces/interfaces";

@Component({
  selector: 'app-book.open-page',
  templateUrl: './book.open-page.component.html',
  styleUrls: ['./book.open-page.component.scss']
})
export class BookOpenPageComponent implements OnInit {

  book$: Observable<Book>

  constructor(
    private service: BookService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.book$ = this.route.params
      .pipe(switchMap((params: Params) => {
        return this.service.getBookLight(params['id'])
      }))


  }
}
