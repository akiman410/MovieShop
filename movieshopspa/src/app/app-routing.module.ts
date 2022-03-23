import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path:"",component: HomeComponent
  },
  {
    path: "admin", loadChildren: () => import("./admin/admin.module").then(mod => mod.AdminModule)
  },
  {
    path: "movies", loadChildren: () => import("./movies/movies.module").then(mod => mod.MoviesModule)
  },
  {
    path: "user", loadChildren: () => import("./user/user.module").then(mod => mod.UserModule)
  },
  {
    path: "account", loadChildren: () => import("./account/account.module").then(mod => mod.AccountModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
