import { Component, OnInit } from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';
import { MAT_RIPPLE_GLOBAL_OPTIONS } from '@angular/material/core';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';

@Component({
  selector: 'list-car-side-stepper',
  templateUrl: './list-car-side-stepper.component.html',
  styleUrls: ['./list-car-side-stepper.component.css'],
})
export class ListCarSideStepperComponent implements OnInit {
  index = 0;
  
  firstFormGroup = this._formBuilder.group({firstCtrl: ['', Validators.required],});
  secondFormGroup = this._formBuilder.group({secondCtrl: ['', Validators.required],});

  constructor(private _formBuilder: FormBuilder) { }

  ngOnInit() {
  }

}