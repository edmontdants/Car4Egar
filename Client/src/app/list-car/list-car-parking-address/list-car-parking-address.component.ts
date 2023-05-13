import { Component, OnInit } from '@angular/core';
import { MatStepper } from '@angular/material/stepper';

@Component({
  selector: 'list-car-parking-address',
  templateUrl: './list-car-parking-address.component.html',
  styleUrls: ['./list-car-parking-address.component.css']
})
export class ListCarParkingAddressComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  goBack(stepper: MatStepper){stepper.previous();}
  goForward(stepper: MatStepper){stepper.next();}
  leavePage(){}

}
