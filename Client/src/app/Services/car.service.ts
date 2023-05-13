import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ICar } from '../Models/ICar';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  baseApiUrl: string = 'https://localhost:7136'
httpOption;
constructor(private http: HttpClient){
    this.httpOption = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    // ,'Authorization': 'Bearer ' + this.
}),
};
}

getAllCars(): Observable<ICar[]> {
    return this.http.get<ICar[]>(this.baseApiUrl + '/Admin/GetAllCars')
}

DeleteCar(vin:string): Observable<any> {
  return this.http.delete<any>(this.baseApiUrl + `/Owner/RemoveACar/${vin}`)
}


// updateCar(addCar: Car): Observable<Car[]> {
//     addCar.VIN = '2';
//     return this.http.post<Car[]>(this.baseApiUrl + '/Admin/RegisterNewCar', addCar)
// }
}
