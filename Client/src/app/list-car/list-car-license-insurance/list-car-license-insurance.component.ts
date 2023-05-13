import { Component, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import { MatStepper } from '@angular/material/stepper';

@Component({
  selector: 'list-car-license-insurance',
  templateUrl: './list-car-license-insurance.component.html',
  styleUrls: ['./list-car-license-insurance.component.css']
})
export class ListCarLicenseInsuranceComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  goBack(stepper: MatStepper){stepper.previous();}
  goForward(stepper: MatStepper){stepper.next();}
  leavePage(){}

  countryControl = new FormControl('', Validators.required);
  cityControl = new FormControl('', Validators.required);
  plateNoControl = new FormControl('', Validators.required);
  dateControl = new FormControl('', Validators.required);
  insuranceYearlyCostControl = new FormControl('', Validators.required);
  insuranceExcessValueControl = new FormControl('', Validators.required);

  governorateControl = new FormControl('', Validators.required);
  Countries: string[] = ['Egypt', 'Saudi Arabia', 'United States','UAE'];
  Governorates: string[] = [
    'Alexandria','Aswan','Asyut','Beheira','Beni Suef','Cairo','Dakahlia','Damietta','Faiyum','Gharbia','Giza','Ismailia',
    'Kafr ElSheikh','Luxor','Matruh','Minya','Monufia','New Valley','North Sinai','PortSaid','Qalyubia','Qena','RedSea',
    'Sharqia','Sohag','South Sinai','Suez'
  ];
    States: string[] = ['Alabama','Alaska','Arizona','Arkansas','California','Colorado','Connecticut','Delaware',
    'Florida','Georgia','Hawaii','Idaho','Illinois','Indiana','Iowa'];
}
