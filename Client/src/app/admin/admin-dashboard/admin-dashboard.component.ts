import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ICar } from 'src/app/Models/ICar';
import { ISystemUser } from 'src/app/Models/isystem-user';
import { CarService } from 'src/app/car/Services/car.service';
import { UserServicesService } from 'src/app/user/Services/user-services.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.scss']
})
export class AdminDashboardComponent {
  /**
   *
   */
  constructor(private carService: CarService, public dialog: MatDialog,private http: HttpClient,private service:UserServicesService) {}
  AllCars:ICar[]=[];

  NumberOfAvailableCarsOnly:number=0;
  Users:ISystemUser[]=[];
  ngOnInit(): void {
    this.carService.getAllCars()
    .subscribe({
      next : (cars) => {
        this.AllCars = cars;
        this.NumberOfAvailableCarsOnly = this.AllCars.filter(
          (car: ICar) => car.available == true
        ).length;
        console.log("Iam Here! in this Car Service Of Admin");
      },
      error : (response)=> {console.log(response)}
    });

      this.service.getAllUsers()
      .subscribe({
        next : (Users) => {
          this.Users = Users;
          console.log("Iam Here! in this Car Service");
        },
        error : (response)=> {console.log(response)}
      });

  }

  // DeleteCar(vin:string){
  //   this.DeleteCar2(vin).subscribe(
  //   response => {
  //     console.log(response);
  //     // Handle success response
  //   },
  //   error => {
  //     console.log(error);
  //     // Handle error response
  //   }
  // );
  // }
  baseApiUrl: string = 'https://localhost:7136'
  DeleteCar(vin:string) {
    return this.http.delete(this.baseApiUrl + `/Owner/RemoveACar/${vin}`).subscribe(
        response => {
          console.log(response);
          // Handle success response
        },
        error => {
          console.log(error);
          // Handle error response
        }
      );
  }


  DeleteUser(nid:string){

    return this.http.delete(this.baseApiUrl + `/Admin/RemoveUser/${nid}`).subscribe(
      response => {
        console.log(response);
        // Handle success response
      },
      error => {
        console.log(error);
        // Handle error response
      }
    );

  }
}
