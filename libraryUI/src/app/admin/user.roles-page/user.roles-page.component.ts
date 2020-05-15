import {Component, OnDestroy, OnInit} from '@angular/core';
import {UserRole} from "../shared/interfaces/interfaces";
import {Subscription} from "rxjs";
import {AuthService} from "../shared/services/auth.service";
import {UserRoleService} from "../shared/services/user.role.service";

@Component({
  selector: 'app-user.roles-page',
  templateUrl: './user.roles-page.component.html',
  styleUrls: ['./user.roles-page.component.scss']
})
export class UserRolesPageComponent implements OnInit, OnDestroy  {

  userRoles: UserRole[]
  pSub: Subscription
  dSub: Subscription
  config: any
  userRole: string

  constructor(
    private service: UserRoleService,
    private auth: AuthService
  ) { }

  ngOnInit() {
    this.userRole = this.auth.userRole;
    this.pSub = this.service.getUserRoles().subscribe((data: UserRole[]) => {
      this.userRoles = data
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


}
