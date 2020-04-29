import { Component, OnInit } from '@angular/core';
import {Book_service} from '../_services/book_service';
import { BookForm } from '../_models/book_form';
import {HttpResponse} from '@angular/common/http';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
  providers: [Book_service]
})
export class HomePageComponent implements OnInit {

  book: BookForm = new BookForm();
  books: BookForm[];
  tableMode = true;
  constructor(private dataService: Book_service) { }

  ngOnInit(): void {
    this.loadBookForm();
  }
  loadBookForm() {
    this.dataService.getBooks()
      .subscribe((data: BookForm[]) => this.books = data);
  }

  save() {
    if (this.book.BookId == null) {
      this.dataService.createBook(this.book)
        .subscribe((data: HttpResponse<BookForm>) => this.books.push(data.body));
    } else {
      this.dataService.updateBook(this.book)
        .subscribe(data => this.loadBookForm());
    }
    this.cancel();
  }

  editBook(p: BookForm) {
    this.book = p;
  }

  cancel() {
    this.book = new BookForm();
    this.tableMode = true;
  }

  delete(p: BookForm) {
    this.dataService.deleteBook(p.BookId)
      .subscribe(data => this.loadBookForm());
  }

  add() {
    this.cancel();
    this.tableMode = false;
  }
}
