import { Component } from '@angular/core';
import { UserServicesService } from '../Services/user-services.service';
import { ICar } from 'src/app/Models/ICar';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { CarRegisterComponent } from '../car-register/car-register.component';
import { CarService } from 'src/app/Services/car.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRentRequest } from 'src/app/Models/IRentRequest';

@Component({
  selector: 'app-my-cars',
  templateUrl: './my-cars.component.html',
  styleUrls: ['./my-cars.component.scss']
})
export class MyCarsComponent {
  constructor(private http: HttpClient,private service:UserServicesService,private router: Router,public dialog: MatDialog,private carService:CarService) {

  }
  NID = String(sessionStorage.getItem('userNID'));

  MyCars:ICar[]=[];
  baseApiUrl: string = 'https://localhost:7136'
  PricePerDayAvailableValues = Array.from({length: 30}, (_, i) => 100 + (i*100));
  years = Array.from({length: 15}, (_, i) => 2010 + i);

  ngOnInit(): void {

    this.carService.getAllCars()
    .subscribe({
      next : (cars) => {
        this.MyCars = cars.filter(c=> c.ownerId==this.NID);
        console.log("Iam Here! in this Car Service");
      },
      error : (response)=> {console.log(response)}
    });

  }



  onChangeFile(vin:string,event: any) {

    if(event.target.files.length > 0) {
      const file = event.target.files[0];
      this.uploadPicture(vin , event.target.files[0].name);
      if(file.type == 'image/png' || file.type == 'image/jpeg') {
        const formData = new FormData();
        formData.append('file',file);
        this.http.post('https://localhost:7136/Admin/UploadPictureAndSave',formData).subscribe((res: any)=> {
          alert('Car Logo Updated Successfully!'); location.reload();
        });

      } else {
        alert('Pease select only jpeg and png');
      }
    }
  }


  DeleteCar(vin:string){
    if(confirm("are you sure?")){
    this.carService.DeleteCar(vin).subscribe(
    response => {
      console.log(response);
      alert('Car Removed!'); location.reload();
    },
    error => {
      console.log(error);
      // Handle error response
    }
  );
    }
    else{

    }

  }

  private baseUrl3 = 'https://localhost:7136';
  public async uploadPicture(vin:string, filename:string) {
    const url = `${this.baseUrl3}/Admin/UploadPictureForCar`;
    // const body = {NID ,base64String, filename };
    const headers = new HttpHeaders({
      'vin': vin,
      'Filename': filename
    });
    const res = await this.http.put(url,null ,{ headers }).toPromise();
    console.log("Done!");
    return res;
  }


  car:ICar={
    vin:'',
color:'',
rate:0,
ratedPeople:0,
mailage:'0',
year:0,
available:true,
modelName:'',
locationOfRent:'',
costPerDay:0,
image:'',
insurance:true,
gearBoxType:'',
ownerId:'',
ownerPic:'',
ownerName:'',
ownerPhone:''
  }
  SubmitNewCar(){
    this.service.RegisterCar(this.car).subscribe({
      next: () => this.router.navigate(['/UserDashBoard']),
      error: (err) => console.log(err)
    });
  }
}
