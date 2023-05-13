import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CarCardsComponent } from './car-cards/car-cards.component';
import { CarProfileComponent } from './car-profile/car-profile.component';
import { StarComponent } from './star/star.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatBadgeModule} from '@angular/material/badge';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatNativeDateModule, MatRippleModule } from '@angular/material/core';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatSliderModule} from '@angular/material/slider';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatPaginatorModule} from '@angular/material/paginator';
import { HttpClientModule } from '@angular/common/http';
import {MatDialogModule} from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import { CarService } from './Services/car.service';


@NgModule({
  declarations: [
    CarCardsComponent,
    CarProfileComponent,
    StarComponent
  ],
  imports: [
    CommonModule,
    MatSlideToggleModule,
    MatBadgeModule,
    MatFormFieldModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    BrowserAnimationsModule,
    MatCheckboxModule,
    MatSliderModule,
    MatExpansionModule,
    MatPaginatorModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatDialogModule,
    MatInputModule

  ],
  exports:[
    CarCardsComponent,
    CarProfileComponent,
    StarComponent
  ]
})

export class CarModule {

 }
