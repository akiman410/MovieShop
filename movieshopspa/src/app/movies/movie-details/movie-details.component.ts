import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from '../../core/services/movie.service';
import { MovieDetails } from '../../shared/models/movieDetails'

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute, private movieService: MovieService) { }

  movieId: number = 0;
  movie!: MovieDetails;
  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(
      p => {
        this.movieId = Number(p.get('id'));
        // console.log('movieId from URL is: ' + this.movieId);
        // call the movie service and get the movie details model

        this.movieService.getMovieDetails(this.movieId).subscribe(
          m => {
            this.movie = m;
            // console.log(this.movie);
          }
        );

      }
    );
  }
//create movieservice, get details method, 
//get movie id from the URL/route using Activated Route to read the routing information

}
