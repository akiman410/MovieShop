import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/shared/models/Login';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  invalidLogin : boolean =false;
  userLogin : Login = {
    email: '', password:''
  }
  constructor(private authService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
    console.log(this.userLogin);
  }

  submit(){    console.log('submit button clicked');
  console.log(this.userLogin);
  // send the data to Authentication service login method
  this.authService.login(this.userLogin).subscribe(
    // if success 
    x => {
      this.router.navigateByUrl('/');
      this.invalidLogin = false;
      // this means the login was successful 200, 201
    },
    (err: HttpErrorResponse) => {
      // this means there was an error 401, 403, 400
      this.invalidLogin = true;
      console.log(err);
    }
    // redirect to home page
    // if error => show the message
  );
  }
}
