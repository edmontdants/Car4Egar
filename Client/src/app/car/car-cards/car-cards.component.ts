import { Component, OnInit,Inject, ElementRef, OnChanges, SimpleChanges } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Icon } from '@fortawesome/fontawesome-svg-core';
import { ICar } from 'src/app/Models/ICar';
import { CarService } from '../Services/car.service';
import { MatDialog,MAT_DIALOG_DATA, } from '@angular/material/dialog';
import { CarProfileComponent } from '../car-profile/car-profile.component';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRentRequest } from 'src/app/Models/IRentRequest';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-car-cards',
  templateUrl: './car-cards.component.html',
  styleUrls: ['./car-cards.component.scss'],
})
export class CarCardsComponent implements OnInit,OnChanges {
  Cars: ICar[] =[];
  FilteredCars: ICar[] = [];
  NID = String(sessionStorage.getItem('userNID'));
  MyCars:ICar[]=[];
  constructor(private carService: CarService, public dialog: MatDialog,private router: Router)
  {this.FilteredCars = this.Cars.slice(0,6);}
  ngOnChanges(changes: SimpleChanges): void {

  }
  ngOnInit(): void {
    this.carService.getAllCars()
    .subscribe({
      next : (cars) => {
        this.Cars = cars;
        this.MyCars = cars.filter(c=> c.ownerId==this.NID);
        this.FilteredCars = cars.slice(0,6);
        this.NumberOfAvailableCarsOnly = this.Cars.filter(
          (car: ICar) => car.available == true
        ).length;
        console.log("Iam Here! in this Car Service");
      },
      error : (response)=> {console.log(response)}
    });

  }
  //*************//
  //***Lists ***//
  //***********//

  Brands: string[] = [
    'All',
    'Abarth',
    'Acura',
    'AlfaRomeo',
    'AstonMartin',
    'Audi',
    'Bentley',
    'BMW',
    'Buick',
    'Cadillac',
    'Chevrolet',
    'Chrtsler',
    'Citroen',
    'Dacia',
    'Dodge',
    'Ferrari',
    'Fiat',
    'Ford',
    'GMC',
    'Honda',
    'Hummer',
    'Hyundai',
    'Infiniti',
    'Isuzu',
    'Jaguar',
    'Jeep',
    'Kia',
    'Lamborghini',
    'Lancia',
    'LandRover',
    'Lexus',
    'Lincoln',
    'Lotus',
    'Maserati',
    'Mazda',
    'Mercedes',
    'Mercury',
    'Mini',
    'Mitsubishi',
    'Nissan',
    'Opel',
    'Peugeot',
    'Pontiac',
    'Porsche',
    'Ram',
    'Renault',
    'Saab',
    'Saturn',
    'Scion',
    'Seat',
    'Skoda',
    'Smart',
    'SsangYong',
    'Subaru',
    'Suzuki',
    'Tesla',
    'Toyota',
    'Volkswagen',
    'Volvo',
    'Wiesmann',
    'Other'
  ];

  Carscolors: string[] = [
    'All',
    'White',
    'Black',
    'Gray',
    'Silver',
    'Blue',
    'Red',
    'Brown',
    'Green',
    'Orange',
    'Beige',
    'Purple',
    'Gold	',
    'Yellow',
    'Other'
  ];

  Locations: string[] = [
    'All',
    'Alexandria',
    'Aswan',
    'Asyut',
    'Beheira',
    'Beni Suef',
    'Cairo',
    'Dakahlia',
    'Damietta',
    'Faiyum',
    'Gharbia',
    'Giza',
    'Ismailia',
    'Kafr ElSheikh',
    'Luxor',
    'Matruh',
    'Minya',
    'Monufia',
    'New Valley',
    'North Sinai',
    'Port Said',
    'Qalyubia',
    'Qena',
    'Red Sea',
    'Sharqia',
    'Sohag',
    'South Sinai',
    'Suez',
    'Any Government'
  ];

  // Cars: ICar[] = [
  //   {
  //     VIN: '1',
  //     color: 'Black',
  //     LicenseNumber: '1234',
  //     Seats: 4,
  //     rate: 4,
  //     ratedPeople: 7,
  //     Mailage: 50,
  //     carType: 'Kia',
  //     LicenseEXDate: new Date(),
  //     year: 2010,
  //     available: true,
  //     modelName: 'Model',
  //     brandName: 'Brand',
  //     locationOfRent: 'Asyut',
  //     costPerDay: 400,
  //     Image: 'car.jpg',
  //     RegistrationDate: new Date(),
  //     Insurance: true,
  //     gearBoxType: 'ManualGearbox',
  //     isActivated: true,
  //     ownerId: '12345678901234',
  //   },
  //   {
  //     VIN: '2',
  //     color: 'Blue',
  //     LicenseNumber: '12345',
  //     Seats: 4,
  //     rate: 3.5,
  //     ratedPeople: 7,
  //     Mailage: 50,
  //     carType: 'Kia',
  //     LicenseEXDate: new Date(),
  //     year: 2011,
  //     available: false,
  //     modelName: 'Model',
  //     brandName: 'Brand',
  //     locationOfRent: 'Minya',
  //     costPerDay: 600,
  //     Image: 'car2.png',
  //     RegistrationDate: new Date(),
  //     Insurance: true,
  //     gearBoxType: 'ManualGearbox',
  //     isActivated: true,
  //     ownerId: '12345678901234',
  //   },
  //   {
  //     VIN: '3',
  //     color: 'Red',
  //     LicenseNumber: '123455',
  //     Seats: 4,
  //     rate: 5,
  //     ratedPeople: 7,
  //     Mailage: 50,
  //     carType: 'Kia',
  //     LicenseEXDate: new Date(),
  //     year: 2020,
  //     available: true,
  //     modelName: 'Model',
  //     brandName: 'Brand',
  //     locationOfRent: 'Minya',
  //     costPerDay: 2100,
  //     Image: 'car3.jpg',
  //     RegistrationDate: new Date(),
  //     Insurance: true,
  //     gearBoxType: 'AutomaticGearbox',
  //     isActivated: true,
  //     ownerId: '12345678901234',
  //   },
  //   {
  //     VIN: '4',
  //     color: 'Red',
  //     LicenseNumber: '123455',
  //     Seats: 4,
  //     rate: 5,
  //     ratedPeople: 7,
  //     Mailage: 50,
  //     carType: 'Kia',
  //     LicenseEXDate: new Date(),
  //     year: 2020,
  //     available: true,
  //     modelName: 'Model',
  //     brandName: 'Brand1',
  //     locationOfRent: 'Cairo',
  //     costPerDay: 200,
  //     Image: 'car4.jpg',
  //     RegistrationDate: new Date(),
  //     Insurance: true,
  //     gearBoxType: 'AutomaticGearbox',
  //     isActivated: true,
  //     ownerId: '12345678901234',
  //   },

  //   {
  //     VIN: '4',
  //     color: 'Red',
  //     LicenseNumber: '123455',
  //     Seats: 4,
  //     rate: 5,
  //     ratedPeople: 7,
  //     Mailage: 50,
  //     carType: 'Kia',
  //     LicenseEXDate: new Date(),
  //     year: 2020,
  //     available: true,
  //     modelName: 'Model',
  //     brandName: 'Brand1',
  //     locationOfRent: 'Cairo',
  //     costPerDay: 200,
  //     Image: 'car4.jpg',
  //     RegistrationDate: new Date(),
  //     Insurance: true,
  //     gearBoxType: 'AutomaticGearbox',
  //     isActivated: true,
  //     ownerId: '12345678901234',
  //   },

  //   {
  //     VIN: '4',
  //     color: 'Red',
  //     LicenseNumber: '123455',
  //     Seats: 4,
  //     rate: 5,
  //     ratedPeople: 7,
  //     Mailage: 50,
  //     carType: 'Kia',
  //     LicenseEXDate: new Date(),
  //     year: 2020,
  //     available: true,
  //     modelName: 'Model',
  //     brandName: 'Brand1',
  //     locationOfRent: 'Cairo',
  //     costPerDay: 200,
  //     Image: 'car4.jpg',
  //     RegistrationDate: new Date(),
  //     Insurance: true,
  //     gearBoxType: 'AutomaticGearbox',
  //     isActivated: true,
  //     ownerId: '12345678901234',
  //   },

  //   {
  //     VIN: '4',
  //     color: 'Red',
  //     LicenseNumber: '123455',
  //     Seats: 4,
  //     rate: 5,
  //     ratedPeople: 7,
  //     Mailage: 50,
  //     carType: 'Kia',
  //     LicenseEXDate: new Date(),
  //     year: 2020,
  //     available: true,
  //     modelName: 'Model',
  //     brandName: 'Brand1',
  //     locationOfRent: 'Cairo',
  //     costPerDay: 200,
  //     Image: 'car4.jpg',
  //     RegistrationDate: new Date(),
  //     Insurance: true,
  //     gearBoxType: 'AutomaticGearbox',
  //     isActivated: true,
  //     ownerId: '12345678901234',
  //   }

  // ];



  //***************************************//
  //**** Filter By Car Owner Name Only ****//
  //***************************************//
  _SearchByCarOwner:string='';
  public get SearchByCarOwner(){
    return this._SearchByCarOwner;
  }
  public set SearchByCarOwner(value:string){
    this._SearchByCarOwner=value;
    this.FilteredCars = this.FilterSearchByCarOwner(value);
  }

  FilterSearchByCarOwner(val:string):ICar[]{
    this._filterByAvailableOnlyCheck = false;
    this._filterByTopratedOnlyCheck = false;
    this._filterByPricePerDaydOnlyValue = 0;
    this._SearchByBrand='All';
    this._MinModelyearValue=2010;
    this._MaxModelyearValue=2024;
    this._AutomaticGearboxCheck=false;
    this._ManualGearboxCheck=false;
    this._SearchByCarcolorValue='';
    this._SearchByLocationValue='';

    if(val==''){
      return this.Cars;
    }
    else{
      return this.Cars.filter(c => c.ownerName.includes(val))
    }
  }
  //***************************************//
  //**** Filter By Available Cars Only ****//
  //***************************************//
  NumberOfAvailableCarsOnly: number = 0;
  private _filterByAvailableOnlyCheck: boolean = false;
  filterByAvailableOnly(check: boolean): ICar[] {
    this._SearchByCarOwner='';
    this._filterByTopratedOnlyCheck = false;
    this._filterByPricePerDaydOnlyValue = 0;
    this._SearchByBrand='All';
    this._MinModelyearValue=2010;
    this._MaxModelyearValue=2024;
    this._AutomaticGearboxCheck=false;
    this._ManualGearboxCheck=false;
    this._SearchByCarcolorValue='';
    this._SearchByLocationValue='';

    if (check == true) {
      return this.Cars.filter((car: ICar) => car.available == true);
    } else {
      this.FilteredCars = this.Cars;
    }
    return this.FilteredCars;
  }

  public get filterByAvailableOnlyCheck(): boolean {
    return this._filterByAvailableOnlyCheck;
  }
  public set filterByAvailableOnlyCheck(value: boolean) {
    this._filterByAvailableOnlyCheck = !this._filterByAvailableOnlyCheck;
    this.FilteredCars = this.filterByAvailableOnly(
      this._filterByAvailableOnlyCheck
    );
  }
  //***************************************//
  //**** Filter By Top rated Cars Only ****//
  //***************************************//

  private _filterByTopratedOnlyCheck: boolean = false;
  filterByTopratedOnly(check: boolean): ICar[] {
    this._SearchByCarOwner='';
    this._filterByAvailableOnlyCheck = false;
    this._filterByPricePerDaydOnlyValue = 0;
    this._SearchByBrand='All';
    this._MinModelyearValue=2010;
    this._MaxModelyearValue=2024;
    this._AutomaticGearboxCheck=false;
    this._ManualGearboxCheck=false;
    this._SearchByCarcolorValue='';
    this._SearchByLocationValue='';

    if (check == true) {
      return this.Cars.filter((car: ICar) => car.rate == 5);
    } else {
      this.FilteredCars = this.Cars;
    }
    return this.FilteredCars;
  }

  public get filterByTopratedOnlyCheck(): boolean {
    return this._filterByTopratedOnlyCheck;
  }
  public set filterByTopratedOnlyCheck(value: boolean) {
    this._filterByTopratedOnlyCheck = !this._filterByTopratedOnlyCheck;
    this.FilteredCars = this.filterByTopratedOnly(
      this._filterByTopratedOnlyCheck
    );
  }
  //***************************************//
  //****** Filter By Price Per Day ********//
  //***************************************//
  private _filterByPricePerDaydOnlyValue: number = 0;
  public get filterByPricePerDaydOnlyValue(): number {
    return this._filterByPricePerDaydOnlyValue;
  }
  public set filterByPricePerDaydOnlyValue(value: number) {
    this._filterByPricePerDaydOnlyValue = value;
    this.FilteredCars = this.filterByPricePerDaydOnly(
      this._filterByPricePerDaydOnlyValue
    );
  }
  filterByPricePerDaydOnly(value: number): ICar[] {
    this._SearchByCarOwner='';
    this._filterByAvailableOnlyCheck = false;
    this._filterByTopratedOnlyCheck = false;
    this._SearchByBrand='All';
    this._MinModelyearValue=2010;
    this._MaxModelyearValue=2024;
    this._AutomaticGearboxCheck=false;
    this._ManualGearboxCheck=false;
    this._SearchByCarcolorValue='';
    this._SearchByLocationValue='';

    if (value == 0) {
      return this.Cars;
    }
    return this.Cars.filter(
      (car: ICar) => car.costPerDay == this.filterByPricePerDaydOnlyValue
    );
  }
  PricePerDay(value: number): string {
    if (value > 0) {
      return Math.round(value) + 'LE';
    }

    return `${value}`;
  }

  yearModelSearch(value: number): string {
    return `${value}`;
  }
  panelOpenState = false;

  //***************************************//
  //******Filter By Top Brand Only*********//
  //***************************************//

  _SearchByBrand:string='';
  public get SearchByBrand():string{
    return this._SearchByBrand;
  }
  public set SearchByBrand(value:string){
    this._SearchByBrand = value;
    // alert(this._SearchByBrand);
    this.FilteredCars = this.filterBybrandNameOnly(
      this._SearchByBrand
    );
  }
  filterBybrandNameOnly(value:string):ICar[]
  {
    this._SearchByCarOwner='';
    this._filterByAvailableOnlyCheck = false;
    this._filterByTopratedOnlyCheck = false;
    this._filterByPricePerDaydOnlyValue = 0;
    this._MinModelyearValue=2010;
    this._MaxModelyearValue=2024;
    this._AutomaticGearboxCheck=false;
    this._ManualGearboxCheck=false;
    this._SearchByCarcolorValue='';
    this._SearchByLocationValue='';

    if (value == 'All' || value=='Other') {
      return this.Cars;
    }
    return this.Cars.filter(
      (car: ICar) => car.modelName == value
    );
  }

  //***************************************//
  //******Filter By Model year Only *******//
  //***************************************//
  private _MinModelyearValue:number=2010;
  private _MaxModelyearValue:number=2024;

  public get MinModelyearValue(){
    return this._MinModelyearValue;
  }
  public set MinModelyearValue(value:number){
    this._MinModelyearValue = value;
    this.FilteredCars = this.filterByyearModel(
      value, this._MaxModelyearValue
    );
  }

  public get MaxModelyearValue(){
    return  this._MaxModelyearValue;
  }
  public set MaxModelyearValue(value:number){
    this._MaxModelyearValue = value;
    this.FilteredCars = this.filterByyearModel(
      this._MaxModelyearValue, value
    );
  }

  filterByyearModel(min:number, max:number):ICar[]{
    this._SearchByCarOwner='';
    this._filterByAvailableOnlyCheck = false;
    this._filterByTopratedOnlyCheck = false;
    this._filterByPricePerDaydOnlyValue = 0;
    this._SearchByBrand='';
    this._AutomaticGearboxCheck=false;
    this._ManualGearboxCheck=false;
    this._SearchByCarcolorValue='';
    this._SearchByLocationValue='';

    return this.Cars.filter(
      (car: ICar) => car.year <= this._MaxModelyearValue && car.year >= this._MinModelyearValue
    );
  }

  //***************************************//
  //***Filter By Auto GearBox Type Only ***//
  //***************************************//
  private _AutomaticGearboxCheck:boolean=false;
  public get AutomaticGearbox(){
    return this._AutomaticGearboxCheck;
  }
  public set AutomaticGearbox(value:boolean){
    this._AutomaticGearboxCheck = value;
    this.FilteredCars = this.filterByAutoGearBox(value);
  }

  filterByAutoGearBox(value:boolean):ICar[]{
    this._SearchByCarOwner='';
    this._filterByAvailableOnlyCheck = false;
    this._filterByTopratedOnlyCheck = false;
    this._filterByPricePerDaydOnlyValue = 0;
    this._SearchByBrand='';
    this._MinModelyearValue=2010;
    this._MaxModelyearValue=2024;
    this._ManualGearboxCheck=false;
    this._SearchByCarcolorValue='';
    this._SearchByLocationValue='';

    if(value == true)
    return this.Cars.filter(
      (car: ICar) => car.gearBoxType == "Automatic"
    );
    else{
      return this.Cars
    }
  }

  //***************************************//
  //**Filter By Manual GearBox Type Only **//
  //***************************************//

  private _ManualGearboxCheck:boolean=false;
  public get ManualGearbox(){
    return this._ManualGearboxCheck;
  }
  public set ManualGearbox(value:boolean){
    this._ManualGearboxCheck = value;
    this.FilteredCars = this.filterByManualGearBox(value);
  }

  filterByManualGearBox(value:boolean):ICar[]{
    this._SearchByCarOwner='';
    this._filterByAvailableOnlyCheck = false;
    this._filterByTopratedOnlyCheck = false;
    this._filterByPricePerDaydOnlyValue = 0;
    this._SearchByBrand='';
    this._MinModelyearValue=2010;
    this._MaxModelyearValue=2024;
    this._AutomaticGearboxCheck=false;
    this._SearchByCarcolorValue='';
    this._SearchByLocationValue='';

    if(value == true)
    return this.Cars.filter(
      (car: ICar) => car.gearBoxType == "Manual"
    );
    else{
      return this.Cars
    }
  }
  //***************************************//
  //****** Filter By Car color Only *******//
  //***************************************//
  private _SearchByCarcolorValue='';
  public get SearchByCarcolorValue(){
    return this._SearchByCarcolorValue;
  }
  public set SearchByCarcolorValue(value:string){
    this._SearchByCarcolorValue = value;
    this.FilteredCars = this.SearchByCarcolor(value);
  }
  SearchByCarcolor(value:string):ICar[]{
    this._SearchByCarOwner='';
    this._filterByAvailableOnlyCheck = false;
    this._filterByTopratedOnlyCheck = false;
    this._filterByPricePerDaydOnlyValue = 0;
    this._SearchByBrand='';
    this._MinModelyearValue=2010;
    this._MaxModelyearValue=2024;
    this._AutomaticGearboxCheck=false;
    this._ManualGearboxCheck=false;
    this._SearchByLocationValue='';

    if(value == 'All' || value=='Other'){
      return this.Cars
    }
    else{
      return this.Cars.filter(
      (car: ICar) => car.color == value);
    }
  }

  //***************************************//
  //****** Filter By Car Location *********//
  //***************************************//

  private _SearchByLocationValue='';
  public get SearchByLocationValue(){
    return this._SearchByLocationValue;
  }
  public set SearchByLocationValue(value:string){
    this._SearchByLocationValue = value;
    this.FilteredCars = this.SearchByLocation(value);
  }

  SearchByLocation(value:string):ICar[]{
    this._SearchByCarOwner='';
    this._filterByAvailableOnlyCheck = false;
    this._filterByTopratedOnlyCheck = false;
    this._filterByPricePerDaydOnlyValue = 0;
    this._SearchByBrand='';
    this._MinModelyearValue=2010;
    this._MaxModelyearValue=2024;
    this._AutomaticGearboxCheck=false;
    this._ManualGearboxCheck=false;
    this._SearchByCarcolorValue='';

    if(value == 'All'){
      return this.Cars
    }
    else{
      return this.Cars.filter(
      (car: ICar) => car.locationOfRent == value);
    }
  }

  //***************************************//
  //*********** Paginator *****************//
  //***************************************//

  OnPageChanges(event: PageEvent){
    const startIndex = event.pageIndex * event.pageSize;
    let endIndex = startIndex + event.pageSize;
    if(endIndex> this.Cars.length){
      endIndex = this.Cars.length;
    }
    this.FilteredCars = this.Cars.slice(startIndex,endIndex)
  }
  //***************************************//
  //***** Pop up Card To Send Request *****//
  //***************************************//
  // param1: string='';
  // param2: string='';
  param3: number=7;
  async sendCarRequest(p1:string,p2:string){
    try {
      const response = await this.carService.sendCarRentalRequest(this.NID,p2,this.param3);
      console.log("Done");
      this.router.navigate(['/UserDashBoard']);
    } catch (error) {
      console.error(error);
    }
  }


}
