import { Component, OnInit } from '@angular/core';
import {BookService} from "../../services/book.service";
import {ActivatedRoute, Params, Route} from "@angular/router";
import {switchMap} from "rxjs/internal/operators/switchMap";

@Component({
  selector: 'app-doc.viewer',
  templateUrl: './doc.viewer.component.html',
  styleUrls: ['./doc.viewer.component.scss']
})
export class DocViewerComponent implements OnInit {

  constructor(
    private service: BookService,
    private route:ActivatedRoute
  ) { }

  url:any

  ngOnInit() {
    this.url = this.route.params
      .pipe(switchMap((params: Params) => {
        return this.service.getBook(params['id']) }
      ))}
}
