import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/models/User';
import { AuthenticationService } from '../../services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isLoggedIn: boolean =false;
  user!: User;


  constructor(private authService: AuthenticationService, private router: Router) { 
    this.authService.isLoggedIn.subscribe( resp => this.isLoggedIn=resp);
    this.authService.currentUser.subscribe( resp => this.user=resp);
  }

  ngOnInit(): void {
  }

  logout() {
    console.log('logout');
    this.authService.logout();
    this.router.navigateByUrl('/account/login');
  }
}
