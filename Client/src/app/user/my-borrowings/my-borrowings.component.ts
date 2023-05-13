import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { AfterViewInit, Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IRentRequest } from 'src/app/Models/IRentRequest';
import { UserServicesService } from '../Services/user-services.service';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'app-my-borrowings',
  templateUrl: './my-borrowings.component.html',
  styleUrls: ['./my-borrowings.component.scss']
})
export class MyBorrowingsComponent implements AfterViewInit {
  NID = String(sessionStorage.getItem('userNID'));
  aftervin:any;
  /**
   *
   */
  constructor(private service:UserServicesService,private _snackBar: MatSnackBar,private http : HttpClient) {}


  baseApiUrl: string = 'https://localhost:7136'
  value:number=5;

  public async CarRating(value: number, carVin: string, borrowerNid: string){
    const url = `${this.baseApiUrl}/Borrower/RateCar`;
    const headers = new HttpHeaders({
      // 'value': $("input[type='radio'][name='value']:checked").val(),
      'value':(String)(value),
      'carVin': carVin,
      'borrowerNid': borrowerNid
    });

    const response = await this.http.post(url,null ,{ headers }).toPromise();
    return response;

  }

  stripeAPIKey: any = 'pk_test_51MxpbiGrFuhrPlyrDhgxHm4JMskNCS9Xqqk2lg4niIEFiGoNndiScowyR83RrrTNNJ8E06faO52ybZAC3FemEIxk005hz8Ns0m';
  handler:any = null;


  pay(vin:any,amount: any) {

    var handler = (<any>window).StripeCheckout.configure({
      key: 'pk_test_51MxpbiGrFuhrPlyrDhgxHm4JMskNCS9Xqqk2lg4niIEFiGoNndiScowyR83RrrTNNJ8E06faO52ybZAC3FemEIxk005hz8Ns0m',
      locale: 'auto',
      token: function (token: any) {
        token.id = String(sessionStorage.getItem('userNID'));
        // Get the token ID to your server-side code for use.
        console.log(token)

        alert('Payment Success !!');
        this.service.DeleteCarRequest(vin).subscribe();
      }

    });


    handler.open({
      name: 'Car 4 Egar Payment Card',
      description: 'all field are required',
      amount: amount
    });

  }

  loadStripe() {

    if(!window.document.getElementById('stripe-script')) {
      var s = window.document.createElement("script");
      s.id = "stripe-script";
      s.type = "text/javascript";
      s.src = "https://checkout.stripe.com/checkout.js";
      s.onload = () => {
        this.handler = (<any>window).StripeCheckout.configure({
          key: 'pk_test_51MxpbiGrFuhrPlyrDhgxHm4JMskNCS9Xqqk2lg4niIEFiGoNndiScowyR83RrrTNNJ8E06faO52ybZAC3FemEIxk005hz8Ns0m',
          locale: 'auto',
          token: function (token: any) {
            // You can access the token ID with `token.id`.
            // Get the token ID to your server-side code for use.
            console.log(token)
            alert('Payment Success!!');

          }
        });
      }

      window.document.body.appendChild(s);
    }
  }



  ngAfterViewInit(): void {
    throw new Error('Method not implemented.');
  }
  BorrowerRequests:IRentRequest[]=[];
  BorrowerRequestsConfirmed:IRentRequest[]=[];
  choosenCarVin:string =''
  ngOnInit(): void {
    this.service.getAllRentalRequests()
    .subscribe({
      next : (Requests) => {
        this.BorrowerRequests = Requests.filter(r => r.borrowerId==this.NID && r.requestAcceptance==false);
        this.BorrowerRequestsConfirmed = Requests.filter(r => r.borrowerId==this.NID && r.requestAcceptance==true);
        console.log("Iam Here! in this Car Service");
      },
      error : (response)=> {console.log(response)}
    });
    this.loadStripe();
  }

  Acceptedreq(vin:any,acc :number){


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

    this.service.CancelCarRequest(vin).subscribe(observer)
  }

  // pay(amount: any) {

  //   var handler = (<any>window).StripeCheckout.configure({
  //     key: 'pk_test_51MxpbiGrFuhrPlyrDhgxHm4JMskNCS9Xqqk2lg4niIEFiGoNndiScowyR83RrrTNNJ8E06faO52ybZAC3FemEIxk005hz8Ns0m',
  //     locale: 'auto',
  //     token: function (token: any) {
  //       // You can access the token ID with `token.id`.
  //       // Get the token ID to your server-side code for use.
  //       console.log(token)
  //       alert('Payment Success !!');
  //     }
  //   });

  //   handler.open({
  //     name: 'Car 4 Egar Payment Card',
  //     description: 'all field are required',
  //     amount: amount
  //   });

  // }

  // loadStripe() {

  //   if(!window.document.getElementById('stripe-script')) {
  //     var s = window.document.createElement("script");
  //     s.id = "stripe-script";
  //     s.type = "text/javascript";
  //     s.src = "https://checkout.stripe.com/checkout.js";
  //     s.onload = () => {
  //       this.handler = (<any>window).StripeCheckout.configure({
  //         key: 'pk_test_51MxpbiGrFuhrPlyrDhgxHm4JMskNCS9Xqqk2lg4niIEFiGoNndiScowyR83RrrTNNJ8E06faO52ybZAC3FemEIxk005hz8Ns0m',
  //         locale: 'auto',
  //         token: function (token: any) {
  //           // You can access the token ID with `token.id`.
  //           // Get the token ID to your server-side code for use.
  //           console.log(token)
  //           alert('Payment Success!!');
  //         }
  //       });
  //     }

  //     window.document.body.appendChild(s);
  //   }

}
