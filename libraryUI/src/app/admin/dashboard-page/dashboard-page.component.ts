import {Component, OnDestroy, OnInit} from '@angular/core';
import {BookService} from "../shared/services/book.service";
import {BookForm} from "../shared/interfaces/interfaces";
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss']
})
export class DashboardPageComponent implements OnInit, OnDestroy {

  books: BookForm[]
  pSub: Subscription
  dSub: Subscription
  searchStr = ''
  constructor(private service: BookService) { }

  ngOnInit() {
    this.pSub = this.service.getBooks().subscribe((data: BookForm[]) => this.books = data);
    }

ngOnDestroy(){
    if(this.pSub){
      this.pSub.unsubscribe()
    }
    if(this.dSub){
      this.dSub.unsubscribe()
    }
}

  remove(id: number) {
this.dSub = this.service.deleteBook(id).subscribe(()=>{
  this.books = this.books.filter(book=>book.bookId!==id)
})
  }
}
