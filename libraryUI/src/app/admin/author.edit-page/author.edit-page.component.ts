import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import { Author} from "../shared/interfaces/interfaces";
import {Subscription} from "rxjs";
import {ActivatedRoute, Params, Router} from "@angular/router";
import { AuthorService } from '../shared/services/author.service';
import {switchMap} from "rxjs/operators";

@Component({
  selector: 'app-author.edit-page',
  templateUrl: './author.edit-page.component.html',
  styleUrls: ['./author.edit-page.component.scss']
})
export class AuthorEditPageComponent implements OnInit, OnDestroy {

  form: FormGroup
  author: Author
  submitted = false
  uSub: Subscription

  constructor(
    private service: AuthorService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.route.params.pipe(
      switchMap((params: Params) => {
        return this.service.getAuthor(params['id'])
      })
    ).subscribe((author: Author) => {
      this.author = author
      this.form = new FormGroup({
        authorName: new FormControl(author.authorName, Validators.required),
        authorBiography: new FormControl(author.authorBiography, Validators.required),
      })
    })
  }

  submit() {
    if (this.form.invalid) {
      return
    }
    this.submitted = true
    const author: Author = {
      authorId: this.author.authorId,
      authorName: this.form.value.authorName,
      authorBiography: this.form.value.authorBiography
     }
    this.uSub = this.service.updateAuthor(author).subscribe(() => {
      this.submitted = false
      this.router.navigate(['/admin', 'authors']);
    })
  }

  ngOnDestroy() {
    if (this.uSub) {
      this.uSub.unsubscribe()
    }
  }

}
