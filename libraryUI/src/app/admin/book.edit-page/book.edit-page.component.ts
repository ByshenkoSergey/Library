import {Component, OnDestroy, OnInit} from '@angular/core';
import {BookService} from "../shared/services/book.service";
import {ActivatedRoute, Params, Router} from "@angular/router";
import {switchMap} from "rxjs/operators";
import {BookAdd} from '../shared/interfaces/interfaces';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-book.edit-page',
  templateUrl: './book.edit-page.component.html',
  styleUrls: ['./book.edit-page.component.scss']
})
export class BookEditPageComponent implements OnInit, OnDestroy {

  form: FormGroup
  book: BookAdd
  submitted = false
  uSub: Subscription

  constructor(
    private service: BookService,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.route.params.pipe(
      switchMap((params: Params) => {
        return this.service.getBook(params['id'])
      })
    ).subscribe((book: any) => {
      this.book = book
      this.form = new FormGroup({
        bookName: new FormControl(book.bookName, Validators.required),
        authorName: new FormControl(book.authorName, Validators.required),
        yearOfPublishing: new FormControl(book.yearOfPublishing, Validators.required),
        publisherName: new FormControl(book.publisherName, Validators.required),
      })
    })
  }

  submit() {
    if (this.form.invalid) {
      return
    }
    this.submitted = true
    const book: BookAdd = {
      bookId: this.book.bookId,
      bookName: this.form.value.bookName,
      filePath: this.book.filePath,
      authorName: this.form.value.authorName,
      yearOfPublishing: this.form.value.yearOfPublishing,
      publisherName: this.form.value.publisherName,
      fileType: this.book.fileType

    }
    this.uSub = this.service.updateBook(book).subscribe(() => {
      this.submitted = false
      this.router.navigate(['/admin', 'dashboard']);
    })
  }

  ngOnDestroy() {
    if (this.uSub) {
      this.uSub.unsubscribe()
    }
  }
}
