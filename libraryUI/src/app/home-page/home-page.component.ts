import { Component, OnInit } from '@angular/core';
import { BookService } from '../admin/shared/services/book.service';
import {Router} from "@angular/router";

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
  providers: [BookService]
})
export class HomePageComponent implements OnInit {


  constructor(private router: Router) {
  }

  routeLogin(){
    this.router.navigate(['/','login'])
  }

  routeRegister(){
    this.router.navigate(['/','register'])
  }

  ngOnInit() {


  }
}
