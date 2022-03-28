import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from 'src/app/shared/models/Login';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/shared/models/User';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  private isLoggedInSubject = new BehaviorSubject<boolean>(false);
  public isLoggedIn = this.isLoggedInSubject.asObservable();

  private currentUserSubject = new BehaviorSubject<User>({} as User);
  public currentUser = this.currentUserSubject.asObservable();

  private jwtHelper = new JwtHelperService();



  login(userLogin: Login): Observable<boolean>{
   return this.http.post(`${environment.apiBaseUrl}account/login`, userLogin)
    .pipe(
      map((response: any) => {
        if (response) {
          // email/pw is correct
          // store the token in local storage and return true
          localStorage.setItem('token', response.token);
          this.populateUserInfo();
          return true;
        }
        return false;
      })
    )
  }
//logout
  logout(){
    //delete token from the local storage
    localStorage.removeItem('token');
  }

  populateUserInfo() {
    // get the token from local storage
    // decode the token to the typescript object 
    // push the auth true/false to the subject
    // push the user info also to another subjects

    var token = localStorage.getItem('token');

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      // decode the token
      const decodedToken = this.jwtHelper.decodeToken(token);

      this.currentUserSubject.next(decodedToken);
      this.isLoggedInSubject.next(true);
    }

  }

}

