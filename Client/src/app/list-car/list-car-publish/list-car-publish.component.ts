import { Component, OnInit } from '@angular/core';
import { MatStepper } from '@angular/material/stepper';

@Component({
  selector: 'list-car-publish',
  templateUrl: './list-car-publish.component.html',
  styleUrls: ['./list-car-publish.component.css']
})
export class ListCarPublishComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  goBack(stepper: MatStepper){stepper.previous();}
  goForward(stepper: MatStepper){stepper.next();}
  leavePage(){}
}
