import { Component,OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PopLoginComponent } from 'src/app/Components/pop-login/pop-login.component';
import { PopRegisterComponent } from 'src/app/Components/pop-register/pop-register.component';
import { LayoutModule } from '@angular/cdk/layout';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Routes } from '@angular/router';
import { UserDashBoardComponent } from 'src/app/user/user-dash-board/user-dash-board.component';
import { CarCardsComponent } from 'src/app/car/car-cards/car-cards.component';
//import {render} from 'creditcardpayments/creditCardPayments';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.scss']
})
export class LandingPageComponent {


  constructor(public dialog: MatDialog, private breakpointObserver: BreakpointObserver) {}


  openRegistrationDialog(): void {
    const dialogRef = this.dialog.open(PopRegisterComponent, {
      width: '550px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log(result); // This is where you would handle the registration data
      }
    });
  }
  openLoginDialog(): void {
    const dialogRef = this.dialog.open(PopLoginComponent, {
      width: '550px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log(result); // This is where you would handle the login data
      }
    });
  }

}
