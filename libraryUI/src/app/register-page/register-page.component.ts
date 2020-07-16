import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {User} from "../admin/shared/interfaces/interfaces";
import {UserService} from "../admin/shared/services/user.service";
import { AuthService } from '../admin/shared/services/auth.service';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent implements OnInit {


  form: FormGroup;

  constructor(
    private service: UserService,
    private router: Router,
    private auth: AuthService) { }

  ngOnInit() {
       this.form=new FormGroup({
      userLogin: new FormControl(null
        ,[Validators.required, Validators.minLength(4)]),
      userPassword: new FormControl(null,
        [Validators.required, Validators.minLength(4)]),
      email: new FormControl(null,
        [Validators.required,Validators.email]),
      userFirstName: new FormControl(null),
      userLastName: new FormControl(null),
      userYearsOld: new FormControl(null),
      phoneNumber: new FormControl(null)

    })
  }
  submit(){
       if(this.form.invalid){
      return
    }

    const user: User={
      userLogin: this.form.value.userLogin ,
      userPassword: this.form.value.userPassword ,
      email: this.form.value.email,
      userFirstName:this.form.value.userFirstName ,
      userLastName:this.form.value.userLastName ,
      userYearsOld:this.form.value.userYearsOld,
      phoneNumber:this.form.value.phoneNumber,
      userRole:this.auth.userRole

    }
    this.service.createUser(user).subscribe( () =>{
      this.form.reset()
      this.router.navigate(['/','login'])})
  }


}
