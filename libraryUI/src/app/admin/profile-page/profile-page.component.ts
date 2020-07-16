import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {User} from "../shared/interfaces/interfaces";
import {Subscription} from "rxjs";
import {UserService} from "../shared/services/user.service";
import {AuthService} from "../shared/services/auth.service";
import {ActivatedRoute, Params, Router} from "@angular/router";
import {switchMap} from "rxjs/operators";

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.scss']
})
export class ProfilePageComponent implements OnInit, OnDestroy {

  form: FormGroup
  user: User
  role: string
  submitted = false
  uSub: Subscription
  id: number

  constructor(
    private service: UserService,
    private auth: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.route.params.pipe(
      switchMap((params: Params) => {
        this.id = params['id']
        return this.service.getUser(this.id)
      })
    ).subscribe((user: User) => {
      this.user = user
      this.form = new FormGroup({
        userLogin: new FormControl(user.userLogin, [Validators.required, Validators.pattern(/\D{4,}/)]),
        userPassword: new FormControl(user.userPassword, [Validators.required, Validators.pattern(/\D{4,}/)]),
        email: new FormControl(user.email, [Validators.required, Validators.email]),
        userFirstName: new FormControl(user.userFirstName),
        userLastName: new FormControl(user.userLastName),
        userYearsOld: new FormControl(user.userYearsOld, Validators.pattern(/^[0-9]*$/)),
        phoneNumber: new FormControl(user.phoneNumber, [Validators.required, Validators.pattern(/^[+][3][8][(][0]\d{2}[)][ ]\d{3}[-]\d{2}[-]\d{2}/)])
      })
      this.role = this.auth.userRole
    })
  }

  ngOnDestroy() {
    if (this.uSub) {
      this.uSub.unsubscribe()
    }
  }

  submit() {
    if (this.form.invalid) {
      return
    }
    this.submitted = true
    const user: User = {
      userId: this.id,
      userLogin: this.form.value.userLogin,
      userPassword: this.form.value.userPassword,
      email: this.form.value.email,
      userFirstName: this.form.value.userFirstName,
      userLastName: this.form.value.userLastName,
      userYearsOld: this.form.value.userYearsOld,
      phoneNumber: this.form.value.phoneNumber,
      userRole: this.role

    }
    console.log(user)
    this.uSub = this.service.updateUser(user).subscribe(() => {
      this.submitted = false
      this.router.navigate(['/admin', 'dashboard']);
    })
  }
}






