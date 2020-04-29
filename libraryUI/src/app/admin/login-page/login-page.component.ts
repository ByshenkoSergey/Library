import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import { UserLogin } from 'src/app/_models/user_login';
import {AuthService} from '../shared/services/auth.service';
import {Route, Router} from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  form: FormGroup;

  constructor(
    private auth: AuthService,
    private router: Router
  ) {

  }

  ngOnInit() {
  this.form = new FormGroup( {
    email: new FormControl(null, [
      Validators.required, Validators.email
    ]),
    password: new FormControl(null, [
      Validators.required, Validators.minLength(6)
    ])

  });
}

  submit() {
    if (this.form.invalid){
      return;
    }
    const  user: UserLogin = {
      Login: this.form.value.email,
      Password: this.form.value.password
         };
    this.auth.login(user).subscribe(() => {
     this.form.reset();
     this.router.navigate(['/admin', 'dashboard']);
    });
  }
}
