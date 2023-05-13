import { Component, OnInit } from '@angular/core';
import { LandingPageComponent } from './home/landing-page/landing-page.component';
import { LayoutModule } from '@angular/cdk/layout';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { PopLoginComponent } from './Components/pop-login/pop-login.component';
import { MatDialog } from '@angular/material/dialog';
import { PopRegisterComponent } from './Components/pop-register/pop-register.component';
import { RegistrationService } from './Services/registration.service';
import { Router } from '@angular/router';
import { CarRegisterComponent } from './user/car-register/car-register.component';
import { CarModelDialogComponent } from './user/car-model-dialog/car-model-dialog.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  constructor(
    private breakpointObserver: BreakpointObserver,
    public dialog: MatDialog,
    private serves: RegistrationService,
    private router: Router,
    private dialogListCar: MatDialog
  ) {}
  title = 'Car4Egar';
  hidden = false;

  NID = String(sessionStorage.getItem('userNID'));
  Role = String(sessionStorage.getItem('role'));
  toggleBadgeVisibility() {
    this.hidden = !this.hidden;
  }

  isLoggedIn = this.serves.isUserLogged;

  onLoginClick() {
    // Handle the login process
    //this.isLoggedIn = true;
  }

  onLogoutClick() {
    this.serves.logout();
    this.router.navigate(['']);
  }

  openLoginDialog(): void {
    const dialogRef = this.dialog.open(PopLoginComponent, {
      width: '550px',
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        console.log(result); // This is where you would handle the login data
      }
    });
  }

  openRegistrationDialog(): void {
    const dialogRef = this.dialog.open(PopRegisterComponent, {
      width: '550px',
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        console.log(result); // This is where you would handle the registration data
      }
    });
  }

  ngOnInit(): void {
    // this.isUserLogged=this.authService.isUserLogged;
    this.serves.getloggedStatus().subscribe((status) => {
      this.isLoggedIn = status;
      console.log(`${this.isLoggedIn} this loged status`);

    });

  }
  openDialogListCar() {
    this.dialogListCar.open(CarModelDialogComponent)
  }
}
