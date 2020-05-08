import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../admin/shared/services/auth.service';
import {ActivatedRoute, Router} from '@angular/router';
import {UserLogin} from "../admin/shared/interfaces/interfaces";

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  form: FormGroup;
  submitted = false;
  message: string

  constructor(
    public auth: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) {

  }

  ngOnInit() {
this.route.queryParams.subscribe( (params)=>{
  if(params['loginAgain']){
    this.message = 'Пожалуйста авторизируйтесь'
  }else if(params['authFailed']){
    this.message='Сесия истекла, пожалуйста авторизируйтесь'
  }
})

  this.form = new FormGroup( {
    login: new FormControl(null, [
      Validators.required, Validators.minLength(4)
    ]),
    password: new FormControl(null, [
      Validators.required, Validators.minLength(4)
    ])

  });
}

  submit() {
    if (this.form.invalid){
      return;
    }
    this.submitted = true;
    const  user: UserLogin = {
      login: this.form.value.login,
      password: this.form.value.password
    }
     this.auth.login(user).subscribe(() => {
     this.form.reset()
     this.router.navigate(['/admin', 'dashboard'])
      this.submitted=false
    }, () =>{
      this.submitted=false
    })
  }
}
