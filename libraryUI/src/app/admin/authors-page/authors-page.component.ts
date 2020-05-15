import {Component, OnDestroy, OnInit} from '@angular/core';
import {Author} from "../shared/interfaces/interfaces";
import {Subscription} from "rxjs";
import {AuthService} from "../shared/services/auth.service";
import {AuthorService} from "../shared/services/author.service";

@Component({
  selector: 'app-authors-page',
  templateUrl: './authors-page.component.html',
  styleUrls: ['./authors-page.component.scss']
})
export class AuthorsPageComponent implements OnInit, OnDestroy {

  authors: Author[]
  pSub: Subscription
  dSub: Subscription
  config: any
  searchStr = ''
  userRole: string

  constructor(
    private service: AuthorService,
    private auth: AuthService
  ) { }

  ngOnInit() {

    this.userRole = this.auth.userRole;
    this.pSub = this.service.getAuthors().subscribe((data: Author[]) => {
      this.authors = data

      this.config = {
        itemsPerPage: 5,
        currentPage: 1,
        totalItems: data.length
      }
    });

  }

  ngOnDestroy() {
    if (this.pSub) {
      this.pSub.unsubscribe()
    }
    if (this.dSub) {
      this.dSub.unsubscribe()
    }
  }

  pageChanged(event) {
    this.config.currentPage = event;
  }

  remove(id: number) {
    this.dSub = this.service.deleteAuthor(id).subscribe(() => {
      this.authors = this.authors.filter(author => author.authorId!==id)
    })
  }

}
