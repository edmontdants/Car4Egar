import { Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  Validators,
  FormGroupDirective,
  NgForm,
} from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { CarService } from 'src/app/Services/car.service';
import { UserServicesService } from '../Services/user-services.service';
import { ICar } from 'src/app/Models/ICar';


@Component({
  selector: 'app-car-register',
  templateUrl: './car-register.component.html',
  styleUrls: ['./car-register.component.scss'],
})
export class CarRegisterComponent implements OnInit {
  constructor(private service:UserServicesService,private router: Router) {

  }

  ngOnInit(): void {
    var element = document.getElementsByClassName("modal-backdrop")[0];
    element.remove();
  }
  NID = String(sessionStorage.getItem('userNID'));

  years = Array.from({length: 15}, (_, i) => 2010 + i);
  PricePerDayAvailableValues = Array.from({length: 30}, (_, i) => 100 + (i*100));
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
ownerId:this.NID,
ownerPic:'',
ownerName:'',
ownerPhone:''
  }
  SubmitNewCar(){

    this.service.RegisterCar(this.car).subscribe({
      next: () => this.router.navigate(['/UserDashBoard']),
      error: (err) => console.log("err")
    });
    document.getElementById("ModalClose")?.click();
  }
}



  // constructor(
  //   private carService: CarService,
  //   private router: Router,
  //   public datepipe: DatePipe,
  //   private _snackBar: MatSnackBar
  // ) {
  //   for (let year = this.currentYear + 1; year >= 2013; year--)
  //     this.Years.push(year);
  //   const current = new Date();
  //   this.minDate = new Date(current.getFullYear(), current.getMonth() - 1, 1);
  //   this.maxDate = new Date(current.getFullYear() + 5, 11, 31);
  // }

  // cars: ImCar[] = [];
  // ngOnInit() {
  //   this.carService.getAllCars().subscribe({
  //     next: (cars) => {
  //       this.cars = cars;
  //       console.log(cars);
  //     },
  //     error: (err) => console.log(err),
  //   });

  //   this.filteredGovernorates = this.cityControl.valueChanges.pipe(
  //     startWith(''),
  //     map((value) => this._filter(value || ''))
  //   );
  // }

  // private current = new Date();
  // minDate: Date = new Date();
  // maxDate: Date = new Date();
  // filteredGovernorates: Observable<string[]> = new Observable<string[]>();
  // // pad(num: number) { return('00'+num).slice(-2) }
  // // date: Date = new Date();
  // // this.date = this.date.getUTCFullYear() +'-'+ pad(date.getUTCMonth() + 1)+ '-' +pad(date.getUTCDate()) +' '+ pad(date.getUTCHours()) +':' + pad(date.getUTCMinutes()) +':'+ pad(date.getUTCSeconds());

  // newCar: ImCar = {
  //   nid: '12345678912345',
  //   vin: '2',
  //   color: 'Maroon',
  //   licenseNumber: '2233',
  //   seats: 5,
  //   mileage: 20000,
  //   carType: 'Sedan',
  //   licenseEXDate: new Date(),
  //   year: 2024,
  //   availableForRent: true,
  //   modelName: '650S',
  //   brandName: 'McLaren',
  //   locationOfRent: 'Minya',
  //   costPerDay: 1200,
  //   image: 'car.jpg',
  //   insurance: true,
  //   gearBoxType: 'Automatic',
  //   ownerId: "12345678998760",
  //   ownerName: "string",
  //   ownerPhoto: "string",
  //   ownerPhone: "string",
  //   // FuelType: 'Diesel',
  // };

  // registerCar() {
  //   // this.newCar.LicenseEXDate = this.datepipe.transform(this.newCar.LicenseEXDate, 'yyyy-MM-dd');
  //   this.carService.addCar(this.newCar).subscribe({
  //     next: (newCar) => console.log(newCar, 'success'),
  //     error: (err) => console.log(this.newCar, err),
  //   });
  // }

  // RegistrationMCar() {
  //   // this.newCar.LicenseEXDate = this.datepipe.transform(this.newCar.LicenseEXDate, 'yyyy-MM-dd');
  //   // this.carService.addCar(this.newCar).subscribe({
  //   //   next: (newCar) => console.log(newCar, 'success'),
  //   //   error: (err) => console.log(this.newCar, err)
  //   // });
  //   const observer = {
  //     next: () => {
  //       this.router.navigateByUrl('userDashBoard');
  //       this._snackBar.open('Cant Connect To The Server', 'Dismiss', {
  //         duration: 3000,
  //         panelClass: ['my-snackbar'],
  //       });
  //     },

  //     error: (error: HttpErrorResponse) => {
  //       if (error.error == 'Not Registered User') {
  //         this._snackBar.open(`${error.error}`, 'Dismiss', {
  //           duration: 3000,
  //           panelClass: ['my-snackbar'],
  //         });
  //       } else if (error.error == 'Not Active User') {
  //         this._snackBar.open(`${error.error}`, 'Dismiss', {
  //           duration: 3000,
  //           panelClass: ['my-snackbar'],
  //         });
  //       } else {
  //         this._snackBar.open('Cant Connect To The Server', 'Dismiss', {
  //           duration: 3000,
  //           panelClass: ['my-snackbar'],
  //         });
  //       }
  //     },
  //   };
  //   this.carService.RegistrationMCar(this.newCar).subscribe(observer);
  // }

  // private _filter(value: string): string[] {
  //   const filterValue = value.toLowerCase();
  //   return this.Governorates.filter((option) =>
  //     option.toLowerCase().includes(filterValue)
  //   );
  // }

  // licenseSelectedFile: any = null;
  // insurancePolicySelectedFile: any = null;
  // identitySelectedFile: any = null;
  // onUploadLicenseSelected(event: any): void {
  //   this.licenseSelectedFile = event.target.files[0] ?? null;
  // }
  // onUploadInsurancePolicySelected(event: any): void {
  //   this.insurancePolicySelectedFile = event.target.files[0] ?? null;
  // }
  // onUploadIdentitySelected(event: any): void {
  //   this.identitySelectedFile = event.target.files[0] ?? null;
  // }

  // myControl = new FormControl();
  // makeControl = new FormControl<Car | null>(null, Validators.required);
  // modelControl = new FormControl('', Validators.required);
  // yearControl = new FormControl('', Validators.required);
  // titleControl = new FormControl('', Validators.required);
  // seatsControl = new FormControl('', Validators.required);
  // doorsControl = new FormControl('', Validators.required);
  // fuelControl = new FormControl('', Validators.required);
  // gearboxControl = new FormControl('', Validators.required);
  // mileageControl = new FormControl('', Validators.required);
  // colorControl = new FormControl('', Validators.required);
  // typeControl = new FormControl('', Validators.required);

  // requiredControl = new FormControl('', Validators.required);
  // countryControl = new FormControl('', Validators.required);
  // cityControl = new FormControl('', Validators.required);
  // plateControl = new FormControl('', Validators.required);
  // // platePatternControl = new FormControl(Validators.pattern('(?<=\s|^)\d+(?=\s|$)'));
  // dateControl = new FormControl('', Validators.required);
  // dateInvalidControl = new FormControl(
  //   Validators.min(this.minDate.getFullYear())
  // );
  // datePatternControl = new FormControl(
  //   Validators.pattern(
  //     '/^(0?[1-9]|[12][0-9]|3[01])[/-](0?[1-9]|1[012])[/-]d{4}$/'
  //   )
  // );
  // insuranceYearlyCostControl = new FormControl('', Validators.required);
  // insuranceExcessValueControl = new FormControl('', Validators.required);
  // uploadLicenseControl = new FormControl('', Validators.required);
  // uploadInsurancePolicyControl = new FormControl('', Validators.required);
  // uploadIdentityControl = new FormControl('', Validators.required);
  // governorateControl = new FormControl('', Validators.required);
  // phoneControl = new FormControl('', Validators.required);
  // phoneValidationControl = new FormControl(
  //   Validators.pattern('/^01[0125][0-9]{8}$/')
  // );

  // currentYear = new Date().getFullYear();
  // Years: number[] = [];
  // SeatsNo: number[] = [2, 3, 4, 5, 6, 7, 8, 9];
  // DoorsNo: number[] = [2, 3, 4, 5];
  // Fuel: string[] = ['Gas', 'Electric', 'Hybrid', 'Diesel'];
  // Gearbox = ['Manual', 'Automatic', 'Semi-Automatic'];
  // Type = ['SUV', 'Sedan', 'Hatchback', 'Coupe', 'Cabriolet', 'Pickup', 'Van'];
  // Color: string[] = [
  //   'White',
  //   'Black',
  //   'Silver',
  //   'Blue',
  //   'Red',
  //   'Brown',
  //   'Maroon',
  //   'Olive',
  //   'Green',
  //   'Purple',
  //   'Orange',
  //   'Gold',
  //   'Yellow',
  //   'Other',
  // ];
  // Mileage: string[] = [
  //   '0 - 15000 KM',
  //   '15000 - 30000 KM',
  //   '30000 - 50000 KM',
  //   '50000 - 75000 KM',
  //   '75000 - 100000 KM',
  //   '100000 - 150000 KM',
  //   '150000 - 200000 KM',
  //   '+200000 KM',
  //   '+300000 KM',
  //   '+400000 KM',
  //   '+500000 KM',
  // ];
  // MileageNum: number[] = [
  //   15000, 30000, 50000, 75000, 100000, 150000, 200000, 300000, 400000, 500000,
  // ];
  // CarMakeModels: Car[] = [
  //   { make: 'Abarth', models: ['500'] },
  //   {
  //     make: 'Alfa Romeo',
  //     models: ['4C', 'Alfa 159', 'Brera', 'Giulietta', 'Spider'],
  //   },
  //   { make: 'Alvis', models: ['Venden Plas', 'Shangan'] },
  //   { make: 'Ashok Leyland', models: ['Falcon'] },
  //   {
  //     make: 'Aston Martin',
  //     models: [
  //       'DB6',
  //       'DB9',
  //       'DBS',
  //       'Rapide',
  //       'V12 Vantage',
  //       'V8',
  //       'V8 Vantage',
  //       'Vanquish',
  //     ],
  //   },
  //   {
  //     make: 'Audi',
  //     models: [
  //       'A1',
  //       'A3',
  //       'A4',
  //       'A5',
  //       'A6',
  //       'A7',
  //       'A8',
  //       'Cabriolet',
  //       'Q3',
  //       'Q5',
  //       'Q7',
  //       'R8',
  //       'RS4',
  //       'RS5',
  //       'RS6',
  //       'RS7',
  //       'S3',
  //       'S5',
  //       'S6',
  //       'S7',
  //       'S8',
  //       'TT',
  //       'TT RS',
  //       'TTS',
  //     ],
  //   },
  //   { make: 'Austin Healey', models: ['3000'] },
  //   { make: 'BAIC', models: ['A1', 'A5'] },
  //   {
  //     make: 'Bentley',
  //     models: [
  //       'Arnage',
  //       'Azure',
  //       'Bentayga',
  //       'Brooklands',
  //       'Continental',
  //       'Continental Flying Spur',
  //       'Continental GT',
  //       'Continental GTC',
  //       'Continental Supersports',
  //       'Flying Spur',
  //       'Mulsanne',
  //       'Turbo R',
  //       'Turbo S',
  //     ],
  //   },
  //   {
  //     make: 'BMW',
  //     models: [
  //       '116',
  //       '118',
  //       '120',
  //       '125',
  //       '135',
  //       '2002',
  //       '225',
  //       '228',
  //       '235',
  //       'M2',
  //       'M235',
  //       '316',
  //       '318',
  //       '320',
  //       '323',
  //       '325',
  //       '328',
  //       '328 Gran Turismo',
  //       '330',
  //       '335',
  //       'M3',
  //       '420',
  //       '428',
  //       '435',
  //       'M4',
  //       '520',
  //       '523',
  //       '525',
  //       '528',
  //       '530',
  //       '535',
  //       '535 Gran Turismo',
  //       '540',
  //       '545',
  //       '550',
  //       'M5',
  //       '630',
  //       '640',
  //       '645',
  //       '650',
  //       'M6',
  //       '730',
  //       '735',
  //       '740',
  //       '745',
  //       '750',
  //       '760',
  //       'ActiveHybrid 7',
  //       'B3',
  //       'B7',
  //       'i8',
  //       'Z1',
  //       'Z3 M',
  //       'Z4',
  //       '1M',
  //       'X1',
  //       'X3',
  //       'X4',
  //       'X5',
  //       'X5 M',
  //       'X6',
  //       'X6 M',
  //     ],
  //   },
  //   { make: 'Bugatti', models: ['Veyron'] },
  //   { make: 'Buick' },
  //   { make: 'Cadillac' },
  //   { make: 'Caterham' },
  //   { make: 'Chevrolet' },
  //   { make: 'Chrysler' },
  //   { make: 'Daewoo' },
  //   { make: 'Daihatsu' },
  //   { make: 'Datsun' },
  //   { make: 'Dodge' },
  //   { make: 'Ferrari' },
  //   { make: 'Fiat' },
  //   { make: 'Fisker' },
  //   { make: 'Ford' },
  //   { make: 'GMC' },
  //   { make: 'Harley-Davidson' },
  //   { make: 'Hino' },
  //   { make: 'Holden' },
  //   { make: 'Honda' },
  //   { make: 'Hummer' },
  //   { make: 'Hyundai' },
  //   { make: 'Infiniti' },
  //   { make: 'Isuzu' },
  //   { make: 'Jaguar' },
  //   { make: 'Jeep' },
  //   { make: 'Kawei Auto' },
  //   { make: 'Kia' },
  //   { make: 'King long' },
  //   { make: 'Koenigsegg' },
  //   { make: 'KTM' },
  //   { make: 'Lada' },
  //   { make: 'Lamborghini' },
  //   { make: 'Lancia' },
  //   { make: 'Land Rover' },
  //   { make: 'Lexus' },
  //   { make: 'Lincoln' },
  //   { make: 'Lotus' },
  //   { make: 'Luxgen' },
  //   { make: 'Maserati' },
  //   { make: 'Maybach' },
  //   { make: 'Mazda' },
  //   { make: 'McLaren' },
  //   { make: 'Mercedes-Benz' },
  //   { make: 'Mercury' },
  //   { make: 'MG' },
  //   { make: 'Mini' },
  //   { make: 'Mitsubishi' },
  //   { make: 'Morgan' },
  //   { make: 'Nissan' },
  //   { make: 'Oldsmobile' },
  //   { make: 'Opel' },
  //   { make: 'Panoz' },
  //   { make: 'Peugeot' },
  //   { make: 'Plymouth' },
  //   { make: 'Pontiac' },
  //   { make: 'Porsche' },
  //   { make: 'Renault' },
  //   { make: 'Rolls-Royce' },
  //   { make: 'Saab' },
  //   { make: 'Scion' },
  //   { make: 'Seat' },
  //   { make: 'Shelby' },
  //   { make: 'Skoda' },
  //   { make: 'Smart' },
  //   { make: 'Ssangyong' },
  //   { make: 'Subaru' },
  //   { make: 'Suzuki' },
  //   { make: 'Tesla' },
  //   { make: 'Toyota' },
  //   { make: 'UAZ' },
  //   { make: 'Volkswagen' },
  //   { make: 'Volvo' },
  //   { make: 'W Motors' },
  //   { make: 'Chery' },
  //   { make: 'Geely' },
  //   { make: 'BYD' },
  //   { make: 'JAC' },
  //   { make: 'Speranza' },
  //   { make: 'DFSK' },
  //   { make: 'Citroen' },
  //   { make: 'Proton' },
  //   { make: 'Chery Arrizo' },
  // ];

  // Countries: string[] = ['Egypt', 'Saudi Arabia', 'United States', 'UAE'];
  // Governorates: string[] = [
  //   'Alexandria',
  //   'Aswan',
  //   'Asyut',
  //   'Beheira',
  //   'Beni Suef',
  //   'Cairo',
  //   'Dakahlia',
  //   'Damietta',
  //   'Faiyum',
  //   'Gharbia',
  //   'Giza',
  //   'Ismailia',
  //   'Kafr ElSheikh',
  //   'Luxor',
  //   'Matruh',
  //   'Minya',
  //   'Monufia',
  //   'New Valley',
  //   'North Sinai',
  //   'PortSaid',
  //   'Qalyubia',
  //   'Qena',
  //   'RedSea',
  //   'Sharqia',
  //   'Sohag',
  //   'South Sinai',
  //   'Suez',
  // ];
  // States: string[] = [
  //   'Alabama',
  //   'Alaska',
  //   'Arizona',
  //   'Arkansas',
  //   'California',
  //   'Colorado',
  //   'Connecticut',
  //   'Delaware',
  //   'Florida',
  //   'Georgia',
  //   'Hawaii',
  //   'Idaho',
  //   'Illinois',
  //   'Indiana',
  //   'Iowa',
  // ];
// }
