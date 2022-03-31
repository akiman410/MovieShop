import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieCard } from 'src/app/shared/models/moviecard';
import { environment } from 'src/environments/environment';
import { MovieDetails } from 'src/app/shared/models/movieDetails'


@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }
  getTopGrossingMovies(): Observable<MovieCard[]>{
   return this.http.get<MovieCard[]>(`${environment.apiBaseUrl}Movies/top-grossing`)
    //call the API to get array of movies
    //Make GET HTTP call
    //XMLHTTP Request
    // Angular uses HTTPClient Class to make XMLHTTP behind the scenes
    // Uses HttpClient we have to import HttpClient module
    //Observable as better version of promises
    //RxJS
  }

    getMovieDetails(id: number): Observable<MovieDetails> {
    //  return this.http.get<MovieDetails>(`${environment.apiBaseUrl}`);
    return this.http.get<MovieDetails>(`${environment.apiBaseUrl}movies/${id}`);
    }
}
