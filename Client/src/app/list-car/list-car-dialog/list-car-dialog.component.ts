import { Component, OnInit, Output } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import { Inject } from '@angular/core';

interface CarDialog {
  make?: string;
  model?: string[];
  year?: string;
}

@Component({
  selector: 'list-car-dialog',
  templateUrl: './list-car-dialog.component.html',
  styleUrls: ['./list-car-dialog.component.css']
})
export class ListCarDialogComponent implements OnInit {
  
  constructor() {
    for(let year = this.currentYear+1;year>=2013;year--) {
    this.Years.push(year)
    }
  }

  ngOnInit() { }
  @Output() carDialogObj: CarDialog = {model: [""]};

  makeControl = new FormControl<CarDialog | null>(null, Validators.required);
  modelControl = new FormControl('', Validators.required);
  yearControl = new FormControl('', Validators.required);
  currentYear = new Date().getFullYear();
  Years: number[] = []
  CarMakeModels: CarDialog[] = [
  {make: 'Abarth', model: ['500']},
  {make: 'Alfa Romeo', model: ['4C','Alfa 159','Brera','Giulietta','Spider']},
  {make: 'Alvis', model:['Venden Plas','Shangan']},
  {make: 'Ashok Leyland', model: ['Falcon']},
  {make: 'Aston Martin', model: ['DB6','DB9','DBS','Rapide','V12 Vantage','V8','V8 Vantage','Vanquish']},
  {make: 'Audi', model: ['A1','A3','A4','A5','A6','A7','A8','Cabriolet','Q3','Q5','Q7',
  'R8','RS4','RS5','RS6','RS7','S3','S5','S6','S7','S8','TT','TT RS','TTS']},
  {make: 'Austin Healey', model:['3000']},
  {make: 'BAIC', model:['A1','A5']},
  {make: 'Bentley', model: ['Arnage','Azure','Bentayga','Brooklands','Continental','Continental Flying Spur','Continental GT',
  'Continental GTC','Continental Supersports','Flying Spur','Mulsanne','Turbo R','Turbo S',]},
  {make: 'BMW', model: ['116','118','120','125','135','2002','225','228','235','M2','M235','316','318','320',
  '323','325','328','328 Gran Turismo','330','335','M3','420','428','435','M4','520','523','525','528','530',
  '535','535 Gran Turismo','540','545','550','M5','630','640','645','650','M6','730','735','740','745','750'
  ,'760','ActiveHybrid 7','B3','B7','i8','Z1','Z3 M','Z4','1M','X1','X3','X4','X5','X5 M','X6','X6 M']},
  {make: 'Bugatti', model:['Veyron']},
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