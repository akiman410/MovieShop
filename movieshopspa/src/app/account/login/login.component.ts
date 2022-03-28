import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../core/services/authentication.service';
import { Login } from '../../shared/models/Login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  invalidLogin: boolean = false;
  userLogin: Login = {
    email: '', password: ''
  }

  constructor(private authService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
    console.log(this.userLogin);
  }
  submit() {
    console.log('submit button clicked');
    console.log(this.userLogin);
    // send the data to Authentication service login method
    this.authService.login(this.userLogin).subscribe(
      // if success 
      x => {
        this.router.navigateByUrl('/');
        this.invalidLogin = false;
        // 200, 201
      },
      (err: HttpErrorResponse) => {
        // 401, 403, 400
        this.invalidLogin = true;
        console.log(err);
      }
      // redirect to home page
      // if error
      // show the message
    );
  }

}