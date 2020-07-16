import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {User} from "../shared/interfaces/interfaces";
import {Subscription} from "rxjs";
import {ActivatedRoute, Params, Router} from "@angular/router";
import {switchMap} from "rxjs/operators";
import {UserService} from "../shared/services/user.service";
import {AuthService} from "../shared/services/auth.service";


@Component({
  selector: 'app-user.edit-page',
  templateUrl: './user.edit-page.component.html',
  styleUrls: ['./user.edit-page.component.scss']
})
export class UserEditPageComponent implements OnInit, OnDestroy {

  form: FormGroup
  user: User
  uSub: Subscription
  userRole: string

  constructor(
    private service: UserService,
    private route: ActivatedRoute,
    private router: Router,
    private auth: AuthService
  ) {
  }

  ngOnInit() {
    this.route.params.pipe(
      switchMap((params: Params) => {
        return this.service.getUser(params['id'])
      })
    ).subscribe((user: User) => {
      this.user = user
      this.form = new FormGroup({
        userRole: new FormControl(this.user.userRole, Validators.required)
      })

    })
  }

  submit() {
    const user: User = {
      userId: this.user.userId,
      userLogin: this.user.userLogin,
      userRole: this.form.value.userRole,
      userPassword: this.user.userPassword,
      email: this.user.email,
      phoneNumber: this.user.phoneNumber,
      userFirstName: this.user.userFirstName,
      userLastName: this.user.userLastName,
      userYearsOld: this.user.userYearsOld
    }

    this.uSub = this.service.updateUser(user).subscribe(() => {
      if (this.auth.userRole == this.user.userRole) {
        this.auth.logout()
      }
      this.router.navigate(['/admin', 'users']);
    })
  }

  ngOnDestroy() {
    if (this.uSub) {
      this.uSub.unsubscribe()
    }
  }

}
