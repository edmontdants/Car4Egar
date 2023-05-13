import { Component, OnInit } from '@angular/core';
import {FormControl, Validators, FormGroupDirective, NgForm,} from '@angular/forms';
import { MatStepper } from '@angular/material/stepper';
import {ErrorStateMatcher} from '@angular/material/core';

interface Car {
  make: string;
  models?: string[];
}

@Component({
  selector: 'list-car-info',
  templateUrl: './list-car-info.component.html',
  styleUrls: ['./list-car-info.component.css']
})
export class ListCarInfoComponent implements OnInit {

  constructor() {
    for(let year = this.currentYear+1;year>=2013;year--) this.Years.push(year)
  }

  ngOnInit() {
  }

  goBack(stepper: MatStepper){stepper.previous();}
  goForward(stepper: MatStepper){stepper.next();}
  leavePage(){}

  makeControl = new FormControl<Car | null>(null, Validators.required);
  modelControl = new FormControl('', Validators.required);
  yearControl = new FormControl('', Validators.required);
  titleControl = new FormControl('', Validators.required);
  seatsControl = new FormControl('', Validators.required);
  doorsControl = new FormControl('', Validators.required);
  fuelControl = new FormControl('', Validators.required);
  gearboxControl = new FormControl('', Validators.required);
  mileageControl = new FormControl('', Validators.required);
  colorControl = new FormControl('', Validators.required);
  typeControl = new FormControl('', Validators.required);
  currentYear = new Date().getFullYear();
  Years: number[] = []
  SeatsNo: number[] = [2, 3, 4, 5, 6, 7, 8, 9]
  DoorsNo: number[] = [2, 3, 4, 5]
  Fuel: string[] = ['Gas','Electric','Hybrid','Diesel']
  Gearbox = ['Manual','Automatic','Semi-Automatic'];
  Type = ['SUV','Sedan','Hatchback','Coupe','Cabriolet','Pickup','Van']
  Color: string[] = ['White','Black','Silver','Blue','Red','Brown','Maroon','Olive','Green','Purple','Orange','Gold','Yellow','Other'];
  Mileage: string[] = ['0 - 15000 KM','15000 - 30000 KM','30000 - 50000 KM','50000 - 75000 KM','75000 - 100000 KM','100000 - 150000 KM','150000 - 200000 KM','+200000 KM','+300000 KM','+400000 KM','+500000 KM']
  CarMakeModels :Car[] = [
  {make: 'Abarth', models: ['500']},
  {make: 'Alfa Romeo', models: ['4C','Alfa 159','Brera','Giulietta','Spider']},
  {make: 'Alvis', models:['Venden Plas','Shangan']},
  {make: 'Ashok Leyland', models: ['Falcon']},
  {make: 'Aston Martin', models: ['DB6','DB9','DBS','Rapide','V12 Vantage','V8','V8 Vantage','Vanquish']},
  {make: 'Audi', models: ['A1','A3','A4','A5','A6','A7','A8','Cabriolet','Q3','Q5','Q7',
  'R8','RS4','RS5','RS6','RS7','S3','S5','S6','S7','S8','TT','TT RS','TTS']},
  {make: 'Austin Healey', models:['3000']},
  {make: 'BAIC', models:['A1','A5']},
  {make: 'Bentley', models: ['Arnage','Azure','Bentayga','Brooklands','Continental','Continental Flying Spur','Continental GT',
  'Continental GTC','Continental Supersports','Flying Spur','Mulsanne','Turbo R','Turbo S',]},
  {make: 'BMW', models: ['116','118','120','125','135','2002','225','228','235','M2','M235','316','318','320',
  '323','325','328','328 Gran Turismo','330','335','M3','420','428','435','M4','520','523','525','528','530',
  '535','535 Gran Turismo','540','545','550','M5','630','640','645','650','M6','730','735','740','745','750'
  ,'760','ActiveHybrid 7','B3','B7','i8','Z1','Z3 M','Z4','1M','X1','X3','X4','X5','X5 M','X6','X6 M']},
  {make: 'Bugatti', models:['Veyron']},
  {make: 'Buick'},
  {make: 'Cadillac'},
  {make: 'Caterham'},
  {make: 'Chevrolet'},
  {make: 'Chrysler'},
  {make: 'Daewoo'},
  {make: 'Daihatsu'},
  {make: 'Datsun'},
  {make: 'Dodge'},
  {make: 'Ferrari'},
  {make: 'Fiat'},
  {make: 'Fisker'},
  {make: 'Ford'},
  {make: 'GMC'},
  {make: 'Harley-Davidson'},
  {make: 'Hino'},
  {make: 'Holden'},
  {make: 'Honda'},
  {make: 'Hummer'},
  {make: 'Hyundai'},
  {make: 'Infiniti'},
  {make: 'Isuzu'},
  {make: 'Jaguar'},
  {make: 'Jeep'},
  {make: 'Kawei Auto'},
  {make: 'Kia'},
  {make: 'King long'},
  {make: 'Koenigsegg'},
  {make: 'KTM'},
  {make: 'Lada'},
  {make: 'Lamborghini'},
  {make: 'Lancia'},
  {make: 'Land Rover'},
  {make: 'Lexus'},
  {make: 'Lincoln'},
  {make: 'Lotus'},
  {make: 'Luxgen'},
  {make: 'Maserati'},
  {make: 'Maybach'},
  {make: 'Mazda'},
  {make: 'McLaren'},
  {make: 'Mercedes-Benz'},
  {make: 'Mercury'},
  {make: 'MG'},
  {make: 'Mini'},
  {make: 'Mitsubishi'},
  {make: 'Morgan'},
  {make: 'Nissan'},
  {make: 'Oldsmobile'},
  {make: 'Opel'},
  {make: 'Panoz'},
  {make: 'Peugeot'},
  {make: 'Plymouth'},
  {make: 'Pontiac'},
  {make: 'Porsche'},
  {make: 'Renault'},
  {make: 'Rolls-Royce'},
  {make: 'Saab'},
  {make: 'Scion'},
  {make: 'Seat'},
  {make: 'Shelby'},
  {make: 'Skoda'},
  {make: 'Smart'},
  {make: 'Ssangyong'},
  {make: 'Subaru'},
  {make: 'Suzuki'},
  {make: 'Tesla'},
  {make: 'Toyota'},
  {make: 'UAZ'},
  {make: 'Volkswagen'},
  {make: 'Volvo'},
  {make: 'W Motors'},
  {make: 'Chery'},
  {make: 'Geely'},
  {make: 'BYD'},
  {make: 'JAC'},
  {make: 'Speranza'},
  {make: 'DFSK'},
  {make: 'Citroen'},
  {make: 'Proton'},
  {make: 'Chery Arrizo'},
  ]
}
