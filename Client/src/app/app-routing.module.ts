import { NgModule } from '@angular/core';
import { ActivatedRoute, RouterModule, Routes } from '@angular/router';
import { UserDashBoardComponent } from './user/user-dash-board/user-dash-board.component';
import { MyAccountComponent } from './user/my-account/my-account.component';
import { MyCarsComponent } from './user/my-cars/my-cars.component';
import { MyPaymentsComponent } from './user/my-payments/my-payments.component';
import { MyBorrowingsComponent } from './user/my-borrowings/my-borrowings.component';
import { CarCardsComponent } from './car/car-cards/car-cards.component';
import { LandingPageComponent } from './home/landing-page/landing-page.component';
import { PopLoginComponent } from './Components/pop-login/pop-login.component';
import { AuthGuard } from './auth.guard';
import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';
import { CarRegisterComponent } from './user/car-register/car-register.component';


// const routes: Routes = [
//   {path: '', redirectTo: '/home', pathMatch:'full'},
//   {path : 'home', component: HomeComponent, title: 'Home'},
//   {path: 'products', component: ProductListComponent,  canActivate: [UserAuthGuard]},
//   {path: 'products/:id', component: ProductDetailComponent, canActivate: [UserAuthGuard, ProductDetailGuard]},
//   {path: 'user', loadChildren: () => import('src/app/user/user.module').then((m)=> m.UserModule)},
//   {path:"**", component:NotFoundComponent}
// ];


const routes: Routes = [

  {path: '', component:LandingPageComponent},
  {path: 'LandingPage', component:LandingPageComponent,title: 'LandingPage'},
  {path: 'SearchACar', component:CarCardsComponent,canActivate:[AuthGuard]},
  {path: 'UserDashBoard', component:UserDashBoardComponent,canActivate:[AuthGuard]},
  {path: 'CarRegister', component:CarRegisterComponent,canActivate:[AuthGuard],title: 'CarRegister'},
  {path: 'Admin', component:AdminDashboardComponent,title: 'Admin',canActivate:[AuthGuard]},


  //,children:[
  //   {path: 'MyAccount', component:MyAccountComponent},
  //   {path: 'MyCars', component:MyCarsComponent},
  //   {path: 'MyRequests', component:MyPaymentsComponent},
  //   {path: 'MyBorrowings', component:MyBorrowingsComponent},
  //   {path: 'MyPayments', component:MyBorrowingsComponent},
  //   ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
