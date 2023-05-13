import { Component, ElementRef, OnChanges, OnInit } from '@angular/core';
import { MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { ISystemUser } from 'src/app/Models/isystem-user';
import { RegistrationService } from 'src/app/Services/registration.service';
import { Router } from '@angular/router';
import {
  FormGroup,
  NgModel,
  ValidationErrors,
  ValidatorFn,
} from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-pop-register',
  templateUrl: './pop-register.component.html',
  styleUrls: ['./pop-register.component.scss'],
})
export class PopRegisterComponent {
  hide1: boolean = true;
  hide2: boolean = true;
  confirmPassword?: string;
  newUser: ISystemUser = {
    nid: '',
    userName: '',
    email: '',
    password: '',
    role: 'User',
    isActivated: true,
    address: 's',
    phoneNumber: '01123559988',
    gender: 'male',
    birthDate: '1212',
    photo: '123',
    identityPhoto: '',
    driverLicenceNumber: '',
    driverLicencePhoto: '',
    driverLicenceEXDate: '',
    bank_AccountNumber: '',
    bank_NID: '',
    bank_Name: '',
    bank_Branch: '',
    card_EXDate: '',
    card_Number: '',
    card_CVC: '',
    card_HolderName: '',
    balance: 0,
    fine: 0,
    rate: 0,
    ratedPeople: 0,
  };

  constructor(
    public dialogRef: MatDialogRef<PopRegisterComponent>,
    private userRegister: RegistrationService,
    private router: Router,
    private _snackBar: MatSnackBar
  ) {}
  //methodes------------------------------------------------------
  addnewuser() {
    const observer = {
      next: () => {
        this.dialogRef.close();
        this.router.navigateByUrl('/UserDashBoard');
        sessionStorage.setItem('userNID', this.newUser.nid);
        sessionStorage.setItem('role', this.newUser.role);
        this.userRegister.login();
        this.router.navigate(['UserDashBoard']);
      },
      error: (error: HttpErrorResponse) => {
        if (error.error == 'This User Already Exist') {
          this._snackBar.open(`${error.error}`, 'Dismiss', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          });
        } else {
          this._snackBar.open('Cant Connect To The Server', 'Dismiss', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          });
        }
      },
    };
    this.userRegister.RegistrationNewUser(this.newUser).subscribe(observer);
  }
  ///----------------------------------------------------------------------------------
}
