import {Component, OnInit} from '@angular/core';
import {AuthorService} from "../shared/services/author.service";
import {Author} from "../shared/interfaces/interfaces";
import {switchMap} from 'rxjs/internal/operators/switchMap';
import {ActivatedRoute, Params} from '@angular/router';
import {Observable} from "rxjs";

@Component({
  selector: 'app-author-page',
  templateUrl: './author-page.component.html',
  styleUrls: ['./author-page.component.scss']
})
export class AuthorPageComponent implements OnInit {

  author$: Observable<Author>

  constructor(
    private service: AuthorService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.author$ = this.route.params
      .pipe(switchMap((params: Params) => {
        return this.service.getAuthor(params['id'])
      }))

  }

}
