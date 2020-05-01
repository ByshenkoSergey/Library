import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {BookService} from "../shared/services/book.service";
import { BookAdd } from '../shared/interfaces/interfaces';
import {Router} from "@angular/router";

@Component({
  selector: 'app-bookadd-page',
  templateUrl: './bookadd-page.component.html',
  styleUrls: ['./bookadd-page.component.scss']
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
      publishingHouseName: new FormControl(null,Validators.required)

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
     publishingHouseName: this.form.value.publishingHouseName
    }
    this.service.create(book).subscribe( () =>{
      this.form.reset()
      this.router.navigate(['/admin','dashboard'])

    })

}

}
