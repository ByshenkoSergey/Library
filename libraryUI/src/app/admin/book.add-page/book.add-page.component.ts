import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";

import {BookService} from "../shared/services/book.service";
import {BookAdd, Response} from '../shared/interfaces/interfaces';
import {AlertService} from "../shared/services/alertService";



@Component({
  selector: 'app-book.add-page',
  templateUrl: './book.add-page.component.html',
  styleUrls: ['./book.add-page.component.scss']
})
export class BookAddPageComponent implements OnInit {

  form: FormGroup;
  file: any;
  fileName: string;
  fileAddress: string;
  fileExtension: string;
  submitted = true;




   constructor(
    private service: BookService,
    private router: Router,
    private alert: AlertService) { }

  ngOnInit() {
     console.log('init')
    this.form=new FormGroup({
      bookName: new FormControl(null,Validators.required),
      authorName: new FormControl(null,Validators.required),
      yearOfPublishing: new FormControl(null,Validators.required),
      publisherName: new FormControl(null,Validators.required)
            })
  }

submit(){

     if(this.form.invalid){
       return
    }
  console.log('submit')
  console.log(this.file)

  const formData = new FormData();
     formData.append('file', this.file);
  console.log("formData")
  console.log(formData)
    return this.service.uploadBook(formData).subscribe((res) => {
             this.fileAddress = res;
        console.log(this.fileAddress)

    const book: BookAdd={
     bookName: this.form.value.bookName,
      bookFileAddress: this.fileAddress,
      authorName: this.form.value.authorName,
      yearOfPublishing: this.form.value.yearOfPublishing,
      publisherName: this.form.value.publisherName,
    }
     console.log(book)

    this.service.create(book).subscribe( () =>{
      this.form.reset()
      this.router.navigate(['/admin','dashboard'])
      this.alert.success(`book is added`)
    })

    });
}

  onFileSelected(event) {
    this.file = event.target.files[0];
    this.fileName = this.file.name;
    this.fileExtension = this.fileName.substring(this.fileName.length,this.fileName.length-4)
    this.submitted=true;
    if(this.fileExtension=='.txt')
    {
      this.submitted=false;
    }
   }

}
