import {Component, OnDestroy, OnInit} from '@angular/core';
import {BookService} from "../shared/services/book.service";
import {BookForm} from "../shared/interfaces/interfaces";
import {Subscription} from 'rxjs';
import {AuthService} from "../shared/services/auth.service";


@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss']
})
export class DashboardPageComponent implements OnInit, OnDestroy {

  books: BookForm[]
  pSub: Subscription
  dSub: Subscription
  config: any
  searchStr = ''
  userRole: string


  constructor(
    private service: BookService,
    private auth: AuthService) {

  }

  ngOnInit() {
    this.userRole = this.auth.userRole;
    this.pSub = this.service.getBooks().subscribe((data: BookForm[]) => {
      this.books = data

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

  remove(id: number) {
    this.dSub = this.service.deleteBook(id).subscribe(() => {
      this.books = this.books.filter(book => book.bookId !== id)
    })
  }

  pageChanged(event) {
    this.config.currentPage = event;
  }
}
