import {Component, OnDestroy, OnInit} from '@angular/core';
import {User} from "../shared/interfaces/interfaces";
import {Subscription} from "rxjs";
import {AuthService} from "../shared/services/auth.service";
import {UserService} from "../shared/services/user.service";

@Component({
  selector: 'app-users-page',
  templateUrl: './users-page.component.html',
  styleUrls: ['./users-page.component.scss']
})
export class UsersPageComponent implements OnInit, OnDestroy {

  users: User[]
  pSub: Subscription
  dSub: Subscription
  config: any
  searchStr = ''
  userRole: string

  constructor(
    private service: UserService,
    private auth: AuthService
  ) { }

  ngOnInit() {
    this.userRole = this.auth.userRole;
    this.pSub = this.service.getUsers().subscribe((data: User[]) => {
      this.users = data

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
    this.dSub = this.service.deleteUser(id).subscribe(() => {
      this.users = this.users.filter(user => user.userId!==id)
    })
  }


}
