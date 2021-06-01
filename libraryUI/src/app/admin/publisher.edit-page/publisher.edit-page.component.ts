import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Publisher} from "../shared/interfaces/interfaces";
import {Subscription} from "rxjs";
import {ActivatedRoute, Params, Router} from "@angular/router";
import {PublisherService} from "../shared/services/publisher.service";
import {switchMap} from "rxjs/operators";

@Component({
  selector: 'app-publisher.edit-page',
  templateUrl: './publisher.edit-page.component.html',
  styleUrls: ['./publisher.edit-page.component.scss']
})
export class PublisherEditPageComponent implements OnInit, OnDestroy {

  form: FormGroup
  publisher: Publisher
  submitted = false
  uSub: Subscription

  constructor(
    private service: PublisherService,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.route.params.pipe(
      switchMap((params: Params) => {
        return this.service.getPublisher(params['id'])
      })
    ).subscribe((publisher: Publisher) => {
      this.publisher = publisher
      this.form = new FormGroup({
        publisherName: new FormControl(publisher.publisherName, Validators.required),
        publisherPhone: new FormControl(publisher.publisherTellNumber, Validators.required),
        publisherEmail: new FormControl(publisher.publisherEmail, Validators.required),
        publisherInfo: new FormControl(publisher.publisherInfo, Validators.required),

      })
    })
  }

  submit() {
    if (this.form.invalid) {
      return
    }
    this.submitted = true
    const publisher: Publisher = {
      publisherId: this.publisher.publisherId,
      publisherName: this.form.value.publisherName,
      publisherTellNumber: this.form.value.publisherPhone,
      publisherEmail: this.form.value.publisherEmail,
      publisherInfo: this.form.value.publisherInfo,
    }
    this.uSub = this.service.updatePublisher(publisher).subscribe(() => {
      this.submitted = false
      this.router.navigate(['/admin', 'publishers']);
    })
  }

  ngOnDestroy() {
    if (this.uSub) {
      this.uSub.unsubscribe()
    }
  }
}
