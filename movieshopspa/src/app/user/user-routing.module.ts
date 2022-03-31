import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FavoritesComponent } from './favorites/favorites.component';
import { PurchasesComponent } from './purchases/purchases.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { UserComponent} from './user.component';

const routes: Routes = [
  {
    path: '', component: UserComponent,
    children: [
      {path:'purchases',component: PurchasesComponent},
      {path:'favorites', component: FavoritesComponent},
      {path:'reviews', component: ReviewsComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
