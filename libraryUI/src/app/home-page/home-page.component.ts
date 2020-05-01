import { Component, OnInit } from '@angular/core';
import { BookService } from '../admin/shared/services/book.service';
import { BookForm } from '../admin/shared/interfaces/interfaces';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
  providers: [BookService]
})
export class HomePageComponent implements OnInit {

  book: BookForm;
  books: BookForm[];

  constructor(private dataService: BookService) { }

  ngOnInit() {
    this.loadBook();
  }

    loadBook() {
    this.dataService.getBooks()
      .subscribe((data: BookForm[]) => this.books = data);
  }

  delete(p: BookForm) {
    this.dataService.deleteBook(p.bookId)
      .subscribe(data => this.loadBook());
  }

}
