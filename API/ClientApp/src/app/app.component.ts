import { Component, OnInit } from '@angular/core';
import { BookFormService } from './bookapp/bookservice';
import { BookForm } from './bookapp/book_form';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [BookFormService]
})
export class AppComponent implements OnInit {

    book: BookForm = new BookForm();   // изменяемый товар
    books: BookForm[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: BookFormService) { }

    ngOnInit() {
        this.loadBookForm();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadBookForm() {
        this.dataService.getBooks()
            .subscribe((data: BookForm[]) => this.books = data);
    }
    // сохранение данных
    save() {
        if (this.book.BookId == null) {
            this.dataService.createProduct(this.book)
                .subscribe((data: BookForm) => this.books.push(data));
        } else {
            this.dataService.updateProduct(this.book)
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
        this.dataService.deleteProduct(p.BookId)
            .subscribe(data => this.loadBookForm());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}