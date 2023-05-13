import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ISystemUser } from 'src/app/Models/isystem-user';
import { RegistrationService } from 'src/app/Services/registration.service';
//import {render} from 'creditcardpayments/creditCardPayments';
//import { configure, payment } from 'paypal-rest-sdk';

@Component({
  selector: 'app-my-payments',
  templateUrl: './my-payments.component.html',
  styleUrls: ['./my-payments.component.scss'],
})
export class MyPaymentsComponent implements OnInit {
  //variables------------------------------------
  UsarLogine!: ISystemUser;
  userLoginNID: any;
  UserSend: ISystemUser = {
    nid: '',
    userName: '',
    email: '',
    password: '',
    role: 'User',
    isActivated: true,
    address: '',
    phoneNumber: '',
    gender: '',
    birthDate: '',
    photo: '',
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



  //-------------------
  //constructor-------------------------------
  constructor(
    private userRegister: RegistrationService,
    private _snackBar: MatSnackBar,
    private router: Router
  ) {}
  //---------------------------------------------
  //methods--------------------------------
  ngOnInit(): void {
    this.userLoginNID = sessionStorage.getItem('userNID');

    const observer = {
      next: (userlogin: ISystemUser) => {
        this.UsarLogine = userlogin;
        console.log(`${userlogin.email}`);
      },
      error: (error: HttpErrorResponse) => {
        if (error.error == 'Not Register User') {
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
    this.userRegister.getuserByNID(this.userLoginNID).subscribe(observer);

    console.log(this.userLoginNID);
  }
  EditInfo() {
    const observer = {
      next: () => {
        this._snackBar.open('Changes Done', 'Dismiss', {
          duration: 3000,
          panelClass: ['my-snackbar'],
        });
      },
      error: (error: HttpErrorResponse) => {
        if (error.error == 'This User Is Not Exist') {
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
    this.UserSend.nid = this.UsarLogine.nid;
    this.UserSend.userName = this.UsarLogine.userName;
    this.UserSend.email = this.UsarLogine.email;
    this.UserSend.password = this.UsarLogine.password;
    this.UserSend.role = this.UsarLogine.role;
    this.UserSend.isActivated = this.UsarLogine.isActivated;
    this.UserSend.address = this.UsarLogine.address;
    this.UserSend.phoneNumber = this.UsarLogine.phoneNumber;
    this.UserSend.gender = this.UsarLogine.gender;
    this.UserSend.birthDate = this.UsarLogine.birthDate;
    this.UserSend.photo = this.UsarLogine.photo;
    this.UserSend.identityPhoto = this.UsarLogine.identityPhoto;
    this.UserSend.driverLicenceNumber = this.UsarLogine.driverLicenceNumber;
    this.UserSend.driverLicencePhoto = this.UsarLogine.driverLicencePhoto;
    this.UserSend.driverLicenceEXDate = this.UsarLogine.driverLicenceEXDate;
    this.UserSend.bank_AccountNumber = this.UsarLogine.bank_AccountNumber;
    this.UserSend.bank_NID = this.UsarLogine.bank_NID;
    this.UserSend.bank_Name = this.UsarLogine.bank_Name;
    this.UserSend.bank_Branch = this.UsarLogine.bank_Branch;
    this.UserSend.card_EXDate = this.UsarLogine.card_EXDate;
    this.UserSend.card_Number = this.UsarLogine.card_Number;
    this.UserSend.card_CVC = this.UsarLogine.card_CVC;
    this.UserSend.card_HolderName = this.UsarLogine.card_HolderName;
    this.UserSend.balance = this.UsarLogine.balance;
    this.UserSend.fine = this.UsarLogine.fine;
    this.UserSend.rate = this.UsarLogine.rate;
    this.UserSend.ratedPeople = this.UsarLogine.ratedPeople;

    this.userRegister.EditUser(this.UserSend).subscribe(observer);


  }

  //---------------------------------------------
}
