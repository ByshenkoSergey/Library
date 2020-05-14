import {Component, OnDestroy, OnInit} from '@angular/core';
import {AuthService} from "../shared/services/auth.service";
import { PublisherService } from '../shared/services/publisher.service';
import {Publisher} from "../shared/interfaces/interfaces";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-publishers-page',
  templateUrl: './publishers-page.component.html',
  styleUrls: ['./publishers-page.component.scss']
})
export class PublishersPageComponent implements OnInit, OnDestroy {

  publishers: Publisher[]
  pSub: Subscription
  dSub: Subscription
  config: any
  searchStr = ''
  userRole: string

  constructor(private service: PublisherService,
              private auth: AuthService) { }

  ngOnInit() {

    this.userRole = this.auth.userRole;
    this.pSub = this.service.getPublishers().subscribe((data: Publisher[]) => {
      this.publishers = data

      this.config = {
        itemsPerPage: 5,
        currentPage: 1,
        totalItems: data.length
      }
    });

  }

  ngOnDestroy() {
    if (this.pSub) {
      this.pSub.unsubscribe()
    }
    if (this.dSub) {
      this.dSub.unsubscribe()
    }
  }

  pageChanged(event) {
    this.config.currentPage = event;
  }

  remove(id: number) {
    this.dSub = this.service.deletePublisher(id).subscribe(() => {
      this.publishers = this.publishers.filter(publisher => publisher.publisherId !== id)
    })
  }

}
