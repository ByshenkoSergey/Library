import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {ActivatedRoute, Params} from "@angular/router";
import {switchMap} from "rxjs/internal/operators/switchMap";
import {BookService} from "../shared/services/book.service";
import {Book} from "../shared/interfaces/interfaces";
import {DomSanitizer} from "@angular/platform-browser";
import {AuthService} from "../shared/services/auth.service";

@Component({
  selector: 'app-book.open-page',
  templateUrl: './book.open-page.component.html',
  styleUrls: ['./book.open-page.component.scss']
})
export class BookOpenPageComponent implements OnInit {

  book$: Observable<Book>
  bookText: string
  bookName: string
  userRole: string
  fileUrl: any


  constructor(
    private service: BookService,
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer,
    private auth:AuthService
  ) { }

  ngOnInit() {
    this.userRole = this.auth.userRole
    this.book$ = this.route.params
      .pipe(switchMap((params: Params) => {
        return this.service.getBookLight(params['id'])
      }))

       this.book$.subscribe(res=>{
      this.bookText = res.bookText
        this.bookName = res.bookName
           const blob = new Blob([ this.bookText ], {type:'application/octet-stream'});
            this.fileUrl = this.sanitizer.bypassSecurityTrustResourceUrl(window.URL.createObjectURL(blob));
    })
  }
  }
