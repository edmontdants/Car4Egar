import { AfterViewInit, Component } from '@angular/core';
import { UserServicesService } from '../Services/user-services.service';
import { IRentRequest } from 'src/app/Models/IRentRequest';
import { HttpErrorResponse } from '@angular/common/http';
import { CarService } from 'src/app/Services/car.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-my-requests',
  templateUrl: './my-requests.component.html',
  styleUrls: ['./my-requests.component.scss']
})
export class MyRequestsComponent implements AfterViewInit {
  NID = String(sessionStorage.getItem('userNID'));
  aftervin:any;
  /**
   *
   */
  constructor(private service:UserServicesService,private _snackBar: MatSnackBar) {}
  ngAfterViewInit(): void {
    throw new Error('Method not implemented.');
  }
  OnwerRequests:IRentRequest[]=[];
  ConfirmedRequests:IRentRequest[]=[];
  choosenCarVin:string =''
  ngOnInit(): void {
    this.service.getAllRentalRequests()
    .subscribe({
      next : (Requests) => {
        this.OnwerRequests = Requests.filter(r => r.ownerId==this.NID && r.requestAcceptance==false);
        this.ConfirmedRequests = Requests.filter(r => r.ownerId==this.NID && r.requestAcceptance==true);
        console.log("Iam Here! in this Car Service");
      },
      error : (response)=> {console.log(response)}
    });

  }

  Acceptedreq(vin:any,acc :number){

    const observer = {
      next: () => {
        alert('Request Accepted Successfully!'); location.reload();
      },
      error: (error: HttpErrorResponse) => {
        if (error.error == 'Request Not Exist') {
          this._snackBar.open(`${error.error}`, 'Dismiss', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          });
        } else {
          this._snackBar.open('Done', 'Dismiss', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          });
          this.ngOnInit()
        }
      },
    };

    this.service.SetRentRequestStatus(vin,acc).subscribe(observer)
  }

  deletereq(vin:any){


    const observer = {
      next: () => {

      },
      error: (error: HttpErrorResponse) => {
        if (error.error == 'Request Not Exist') {
          this._snackBar.open(`${error.error}`, 'Dismiss', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          });
        } else {
          this._snackBar.open('Done', 'Dismiss', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          });
          this.ngOnInit()
        }
      },
    };

    this.service.DeleteCarRequest(vin).subscribe(observer)
  }


  Cancelreq(vin:any){
    const observer = {
      next: () => {

      },
      error: (error: HttpErrorResponse) => {
        if (error.error == 'Request Not Exist') {
          this._snackBar.open(`${error.error}`, 'Dismiss', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          });
        } else {
          this._snackBar.open('Done', 'Dismiss', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          });
          this.ngOnInit()
        }
      },
    };

    this.service.DeleteCarRequest(vin).subscribe(observer)
  }

}

