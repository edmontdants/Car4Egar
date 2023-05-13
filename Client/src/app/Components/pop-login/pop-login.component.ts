import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ISystemUser } from 'src/app/Models/isystem-user';
import { RegistrationService } from 'src/app/Services/registration.service';

@Component({
  selector: 'app-pop-login',
  templateUrl: './pop-login.component.html',
  styleUrls: ['./pop-login.component.scss'],
})
export class PopLoginComponent {
  hide1 = true;
  inviledpass=false;
  useremail: string = '';
  userpass: string = '';
  userlogined?: ISystemUser;
  constructor(
    public dialogRef: MatDialogRef<PopLoginComponent>,
    private userRegister: RegistrationService,
    private router: Router,
    private _snackBar: MatSnackBar
  ) {}

  NID = String(sessionStorage.getItem('userNID'));
  Role = String(sessionStorage.getItem('role'));

  onSubmit(): void {
    //-----------------
    const observer = {
      next: (userlogin: ISystemUser) => {
        this.userlogined = userlogin;
        if (this.userpass===this.userlogined?.password) {
            this.dialogRef.close();
            sessionStorage.setItem('userNID', this.userlogined.nid);
            sessionStorage.setItem('role', this.userlogined.role);
            this.userRegister.login();
            this.router.navigateByUrl('/');

        }
        else this.inviledpass=true;
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
    this.userRegister.getuserByEmail(this.useremail).subscribe(observer);
  }
}
