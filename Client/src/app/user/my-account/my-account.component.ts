import { HttpErrorResponse } from '@angular/common/http';
import {
  Component,
  ElementRef,
  OnChanges,
  OnInit,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { pipe } from 'rxjs';
import { ISystemUser } from 'src/app/Models/isystem-user';
import { RegistrationService } from 'src/app/Services/registration.service';
import {
  FormGroup,
  NgModel,
  ValidationErrors,
  ValidatorFn,
} from '@angular/forms';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrls: ['./my-account.component.scss'],
})
//-----class---------------------------------------------------
export class MyAccountComponent implements OnInit, OnChanges {
  //-variables------------------------------------------------------
  hide1 = true;
  hide2 = true;
  hide3 = true;
  hide4 = true;
  notregisterEmail = false;
  @ViewChild('fileInput') fileInput!: ElementRef;
  fileAttr = 'Driver Licence';
  fileAttr2 = 'Identity Doc';
  UsarLogine!: ISystemUser;
  userLoginNID: any;

  confirmPassword: string = '';
  NewPassword: string = '';

  NewEmail: string = '';
  CurrentPass: string = '';

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
//-----------------construct--------------------------------------------------
  constructor(
    private userRegister: RegistrationService,
    private _snackBar: MatSnackBar,
    private router: Router
  ) {
    // setInterval(() => this.ngOnInitCloseModal(), 5000);
  }
  ngOnInitCloseModal(){

  }
  ///---methods--------------------------------------------------------------------------------
  ngOnChanges(): void {

  }

  ngOnInit(): void {
    var element = document.getElementsByClassName("modal-backdrop")[0];
    element?.remove();
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

   // console.log(this.userLoginNID);

  }
  saveinfo() {
    const observer = {
      next: () => {
        this._snackBar.open('Changed Saved', 'Dismiss', {
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
    this.UserSend.address = this.UsarLogine.address;
    this.UserSend.phoneNumber = this.UsarLogine.phoneNumber;
    this.UserSend.gender = this.UsarLogine.gender;
    this.UserSend.birthDate = this.UsarLogine.birthDate;
    this.UserSend.photo = this.UsarLogine.photo;

    this.userRegister.EditUser(this.UserSend).subscribe(observer);
  }

  VeryfiBorrower() {
    const observer = {
      next: () => {
        this._snackBar.open('Verify Is Done', 'Dismiss', {
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
    this.UserSend.address = this.UsarLogine.address;
    this.UserSend.phoneNumber = this.UsarLogine.phoneNumber;
    this.UserSend.gender = this.UsarLogine.gender;
    this.UserSend.birthDate = this.UsarLogine.birthDate;
    this.UserSend.driverLicenceNumber = this.UsarLogine.driverLicenceNumber;
    this.UserSend.driverLicenceEXDate = this.UsarLogine.driverLicenceEXDate;
    this.UserSend.photo = this.UsarLogine.photo;
    this.userRegister.EditUser(this.UserSend).subscribe(observer);
  }
  AccountSetting1() {
    const observer = {
      next: (userlogin: ISystemUser) => {
        this.notregisterEmail = false;
        this._snackBar.open('This Email Existing', 'Dismiss', {
          duration: 3000,
          panelClass: ['my-snackbar'],
        });
      },
      error: (error: HttpErrorResponse) => {
        if (error.error == 'Not Register User') {
          this.notregisterEmail = true;
        } else {
          this._snackBar.open('Cant Connect To The Server', 'Dismiss', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          });
        }
      },
    };
    this.userRegister.getuserByEmail(this.NewEmail).subscribe(observer);

    if (this.notregisterEmail == true) {
      if (this.UsarLogine.password == this.CurrentPass) {
        const observer = {
          next: () => {
            this.userRegister.logout();
            this.router.navigate(['']);
            this._snackBar.open('Changed Saved Please Login Again', 'Dismiss', {
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
        this.UserSend.email = this.NewEmail;
        this.UserSend.password = this.UsarLogine.password;
        this.UserSend.role = this.UsarLogine.role;
        this.UserSend.address = this.UsarLogine.address;
        this.UserSend.phoneNumber = this.UsarLogine.phoneNumber;
        this.UserSend.gender = this.UsarLogine.gender;
        this.UserSend.birthDate = this.UsarLogine.birthDate;
        this.UserSend.driverLicenceNumber = this.UsarLogine.driverLicenceNumber;
        this.UserSend.driverLicenceEXDate = this.UsarLogine.driverLicenceEXDate;
        this.UserSend.photo = this.UsarLogine.photo;
        this.userRegister.EditUser(this.UserSend).subscribe(observer);
      } else {
        this._snackBar.open('This Is Not Your Login Password', 'Dismiss', {
          duration: 3000,
          panelClass: ['my-snackbar'],
        });
      }
    }
  }
  //----------------------------------

  AccountSettingPass() {
    if (this.UsarLogine.password == this.CurrentPass) {
      const observer = {
        next: () => {
          this.userRegister.logout();
          this.router.navigate(['']);
          this._snackBar.open('Changed Saved Please Login Again', 'Dismiss', {
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
      this.UserSend.password = this.NewPassword;
      this.UserSend.role = this.UsarLogine.role;
      this.UserSend.address = this.UsarLogine.address;
      this.UserSend.phoneNumber = this.UsarLogine.phoneNumber;
      this.UserSend.gender = this.UsarLogine.gender;
      this.UserSend.birthDate = this.UsarLogine.birthDate;
      this.UserSend.driverLicenceNumber = this.UsarLogine.driverLicenceNumber;
      this.UserSend.driverLicenceEXDate = this.UsarLogine.driverLicenceEXDate;
      this.UserSend.photo = this.UsarLogine.photo;
      this.userRegister.EditUser(this.UserSend).subscribe(observer);
    } else {
      this._snackBar.open('This Is Not Your Login Password', 'Dismiss', {
        duration: 3000,
        panelClass: ['my-snackbar'],
      });
    }
  }

  //---------------------------------PhotoUpload
  uploadFileEvt(imgFile: any) {
    if (imgFile.target.files && imgFile.target.files[0]) {
      this.fileAttr = '';
      Array.from(imgFile.target.files).forEach((file: any) => {
        this.fileAttr += file.name + ' - ';
      });
      // HTML5 FileReader API
      let reader = new FileReader();
      reader.onload = (e: any) => {
        let image = new Image();
        image.src = e.target.result;
        image.onload = (rs) => {
          let imgBase64Path = e.target.result;
        };
      };
      reader.readAsDataURL(imgFile.target.files[0]);
      // Reset if duplicate image uploaded again
      this.fileInput.nativeElement.value = '';
    } else {
      this.fileAttr = 'Driver Licence';
    }
  }
  @ViewChild('fileInput2') fileInput2!: ElementRef;

  uploadFileEvt2(imgFile: any) {
    if (imgFile.target.files && imgFile.target.files[0]) {
      this.fileAttr2 = '';
      Array.from(imgFile.target.files).forEach((file: any) => {
        this.fileAttr2 += file.name + ' - ';
      });
      // HTML5 FileReader API
      let reader = new FileReader();
      reader.onload = (e: any) => {
        let image = new Image();
        image.src = e.target.result;
        image.onload = (rs) => {
          let imgBase64Path = e.target.result;
        };
      };
      reader.readAsDataURL(imgFile.target.files[0]);
      // Reset if duplicate image uploaded again
      this.fileInput2.nativeElement.value = '';
    } else {
      this.fileAttr2 = 'Identity Doc';
    }
  }
}
//------------------
// this.UserSend.nid = this.UsarLogine.nid;
//     this.UserSend.userName = this.UsarLogine.userName;
//     this.UserSend.email = this.UsarLogine.email;
//     this.UserSend.password = this.UsarLogine.password;
//     this.UserSend.role = this.UsarLogine.role;
//     this.UserSend.isActivated = this.UsarLogine.isActivated;
//     this.UserSend.address = this.UsarLogine.address;
//     this.UserSend.phoneNumber = this.UsarLogine.phoneNumber;
//     this.UserSend.gender = this.UsarLogine.gender;
//     this.UserSend.birthDate = this.UsarLogine.birthDate;
//     this.UserSend.photo = this.UsarLogine.photo;
//     this.UserSend.identityPhoto = this.UsarLogine.identityPhoto;
//     this.UserSend.driverLicenceNumber = this.UsarLogine.driverLicenceNumber;
//     this.UserSend.driverLicencePhoto = this.UsarLogine.driverLicencePhoto;
//     this.UserSend.driverLicenceEXDate = this.UsarLogine.driverLicenceEXDate;
//     this.UserSend.bank_AccountNumber = this.UsarLogine.bank_AccountNumber;
//     this.UserSend.bank_NID = this.UsarLogine.bank_NID;
//     this.UserSend.bank_Name = this.UsarLogine.bank_Name;
//     this.UserSend.bank_Branch = this.UsarLogine.bank_Branch;
//     this.UserSend.card_EXDate = this.UsarLogine.card_EXDate;
//     this.UserSend.card_Number = this.UsarLogine.card_Number;
//     this.UserSend.card_CVC = this.UsarLogine.card_CVC;
//     this.UserSend.card_HolderName = this.UsarLogine.card_HolderName;
//     this.UserSend.balance = this.UsarLogine.balance;
//     this.UserSend.fine = this.UsarLogine.fine;
//     this.UserSend.rate = this.UsarLogine.rate;
//     this.UserSend.ratedPeople = this.UsarLogine.ratedPeople;
