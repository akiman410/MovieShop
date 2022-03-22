import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  //get to 30 movies from API and send the data to the View
  //call the API https://localhost:7051/api/Movies/top-grossing 


}
