import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BookForm } from './book_form';

@Injectable()
export class BookFormService {

    private url = "api/book";

    constructor(private http: HttpClient) {
    }

    getBooks() {
        return this.http.get(this.url);
    }

    getBook(id: number) {

        return this.http.get(this.url + '/' + id);
    }

    createProduct(book: BookForm) {
        return this.http.post(this.url, book);
    }
    updateProduct(book: BookForm) {

        return this.http.put(this.url, book);
    }
    deleteProduct(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}