import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { CreateCastComponent } from './create-cast/create-cast.component';
import { CreateMovieComponent } from './create-movie/create-movie.component';

const routes: Routes = [
  // http://localhost:4200/admin/createmovie 
  {
    path: '', component: AdminComponent,
    children: [
      { path: "createmovie", component: CreateMovieComponent },
      { path: 'createcast', component: CreateCastComponent }
    ]
  }

  // http://localhost:4200/admin/createmovie
  // http://localhost:4200/admin/createcast
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
