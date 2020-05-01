import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";

import {BookService} from "../shared/services/book.service";
import { BookAdd } from '../shared/interfaces/interfaces';


@Component({
  selector: 'app-book.add-page',
  templateUrl: './book.add-page.component.html',
  styleUrls: ['./book.add-page.component.scss']
})
export class BookAddPageComponent implements OnInit {

  form: FormGroup;

  constructor(
    private service: BookService,
    private router: Router) { }

  ngOnInit() {
    this.form=new FormGroup({
      bookName: new FormControl(null,Validators.required),
      bookFileAddress: new FormControl(null, Validators.required),
      authorName: new FormControl(null,Validators.required),
      yearOfPublishing: new FormControl(null,Validators.required),
      publisherName: new FormControl(null,Validators.required)

    })
  }
submit(){
    if(this.form.invalid){
      return
    }

    const book: BookAdd={
     bookName: this.form.value.bookName,
      bookFileAddress: this.form.value.bookFileAddress,
     authorName: this.form.value.authorName,
     yearOfPublishing: this.form.value.yearOfPublishing,
      publisherName: this.form.value.publisherName
    }
    this.service.create(book).subscribe( () =>{
      this.form.reset()
      this.router.navigate(['/admin','dashboard'])

    })

}

}
