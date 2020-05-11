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

  form:FormGroup
  user:User
  role:string
  submitted = false
  uSub: Subscription
  id:number

  constructor(
    private service:UserService,
    private auth:AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.route.params.pipe(
      switchMap((params: Params) => {
        this.id = params['id']
        return this.service.getUser(this.id)
      })
    ).subscribe((user:User)=>{
      this.user=user
      console.log(user)
      this.form = new FormGroup({
        userLogin: new FormControl(user.userLogin, [Validators.required,Validators.minLength(5)]),
        userPassword: new FormControl(user.userPassword, [Validators.required, Validators.minLength(5)] ),
        email: new FormControl(user.email, [Validators.required,Validators.email]),
        userFirstName: new FormControl(user.userFirstName, Validators.maxLength(50)),
        userLastName: new FormControl(user.userLastName, Validators.maxLength(50)),
        userYearsOld: new FormControl(user.userYearsOld, [Validators.maxLength(3)]),
        phoneNumber: new FormControl(user.phoneNumber )
      })
      this.role = this.auth.userRole
    })
  }

  ngOnDestroy() {
    if(this.uSub){
      this.uSub.unsubscribe()
    }
  }

  submit() {
    if(this.form.invalid){
      return
    }
    this.submitted = true
    const user:User = {
      userId: this.id,
      userLogin: this.form.value.userLogin,
      userPassword: this.form.value.userPassword,
      email: this.form.value.email,
      userFirstName: this.form.value.userFirstName,
      userLastName: this.form.value.userLastName,
      userYearsOld:this.form.value.userYearsOld,
      phoneNumber:this.form.value.phoneNumber,
      userRole:this.role

    }
    console.log(user)
    this.uSub=this.service.updateUser(this.id,user).subscribe(()=>{
      this.submitted = false
      this.router.navigate(['/admin', 'dashboard']);
    })
  }
}






