import { Component, OnInit } from '@angular/core';
import { MovieService } from '../core/services/movie.service';
import { MovieCard } from '../shared/models/moviecard';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  movieCards!:MovieCard[];
  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    console.log('inside ngOn Init life cycle')
    this.movieService.getTopGrossingMovies().subscribe
    ( m=>{
      this.movieCards=m;
      console.log(this.movieCards)
    }
    );
  }
  //get to 30 movies from API and send the data to the View
  //call the API https://localhost:7051/api/Movies/top-grossing 


}
