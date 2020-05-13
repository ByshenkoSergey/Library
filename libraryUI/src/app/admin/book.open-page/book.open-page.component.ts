import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {BookService} from "../shared/services/book.service";
import {BookFile} from "../shared/interfaces/interfaces";
import {DomSanitizer} from "@angular/platform-browser";
import {AuthService} from "../shared/services/auth.service";


@Component({
  selector: 'app-book.open-page',
  templateUrl: './book.open-page.component.html',
  styleUrls: ['./book.open-page.component.scss']
})
export class BookOpenPageComponent implements OnInit {

  book: any
  bookFile: BookFile
  params: any
  userRole: string
  id: any

  constructor(
    private service: BookService,
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer,
    private auth: AuthService
  ) {
  }

  ngOnInit() {
    this.userRole = this.auth.userRole
    this.params = this.route.params
    this.id = this.params['value'].id
    this.service.getF('https://localhost:44397/Square World.txt').subscribe(res=>{
      console.log('res')
      console.log(res)
    })

    this.service.getBookFile(this.id).subscribe(res => {
      //this.bookFile = res

    //console.log('this.bookFile');
   // console.log(res);

    const blob = new File([this.bookFile.file], this.bookFile.fileName,{type: 'text/plain'});

    let fileReader = new FileReader();

      fileReader.onload = (e) => {
       // console.log(fileReader.result);
      }
      fileReader.readAsDataURL(blob)

    })


  }
}
