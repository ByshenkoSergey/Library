import { Component, OnInit } from '@angular/core';
import { BookService } from '../admin/shared/services/book.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
  providers: [BookService]
})
export class HomePageComponent implements OnInit {


  constructor() {
  }

  ngOnInit() {


  }
}
