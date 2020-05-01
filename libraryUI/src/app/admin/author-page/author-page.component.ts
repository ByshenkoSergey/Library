import {Component, OnDestroy, OnInit} from '@angular/core';
import {AuthorService} from "../shared/services/author.service";
import {Author} from "../shared/interfaces/interfaces";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-author-page',
  templateUrl: './author-page.component.html',
  styleUrls: ['./author-page.component.scss']
})
export class AuthorPageComponent implements OnInit, OnDestroy {

   author:Author
   aSub:Subscription

  constructor(private service: AuthorService) { }

  ngOnInit(){
  this.aSub=this.service.getAuthors(id).subscribe(author=>{
    this.author=author
    })
   }


ngOnDestroy(){
  if(this.aSub)
  {
    this.aSub.unsubscribe()
  }
}
}
