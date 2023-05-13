import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { CarModule } from '../car/car.module';
import { BrowserModule } from '@angular/platform-browser'


@NgModule({
  declarations: [
    AdminDashboardComponent
  ],
  imports: [
    CommonModule,
    CarModule,
    BrowserModule
  ],
  exports:[
    AdminDashboardComponent,
    CarModule
  ]
})
export class AdminModule { }
