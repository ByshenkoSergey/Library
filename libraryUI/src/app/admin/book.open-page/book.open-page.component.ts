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

  book$: Observable<any>
  bookName: string

  url='https://localhost:44397/BookLibrary/test.docx';
  viewer = 'google';



  constructor(
    private service: BookService,
    private route: ActivatedRoute,

  ) {
  }

  ngOnInit() {
    this.book$ = this.route.params
      .pipe(switchMap((params: Params) => {
        return this.service.getBookFile(params['id'])
      }))

       this.book$.subscribe(res=>{
      //this.bookName = res.
      //this.url= res.bookFilePath

    })
  }
  }
