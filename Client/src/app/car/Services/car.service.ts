import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ICar } from 'src/app/Models/ICar';
import { Observable } from 'rxjs';
import { IRentRequest } from 'src/app/Models/IRentRequest';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  constructor(private http : HttpClient) {}
  baseApiUrl :string = 'https://localhost:7136';


   SetRentRequestStatus(vid: string,acc:number): Observable<any> {
    return this.http.get<any>(
      `${environment.apiBaseUrl}/Borrower/CarRentalRequestAcception` + '/' + vid+'/'+acc
    );
  }

  getAllCars() : Observable<ICar[]>
    {
      return this.http.get<any[]>(this.baseApiUrl + '/Admin/GetAllCars');
    }


    public async sendCarRentalRequest(param1: string, param2: string, param3: number){
      const url = `${this.baseApiUrl}/Borrower/CarRentalRequest`;
      const headers = new HttpHeaders({
        'id': param1,
        'carVin': param2,
        'days': String(param3)
      });

      const response = await this.http.post(url,null ,{ headers }).toPromise();
      return response;

    }







  // baseApiUrl2 :string = 'https://localhost:7136/Borrower/CarRentalRequest';
  // SendCarRequest(id:string, carVin:string ,days:number) : Observable<IRentRequest>
  // {
  //   id = '12345678901234';
  //   const url = `${this.baseApiUrl}/${id}/${carVin}/${days}`;
  //   return this.http.post(url,null);
  // }
  // addDeveloper(adddeveloper:Developer) : Observable<Developer>
  // {
  //   adddeveloper.id = '8AA63E57-0000-418B-8CE2-3946C8D4E5FC';
  //   return this.http.post<Developer>(this.baseApiUrl + '/api/Developer', adddeveloper);
  // }
  // getDeveloper(id:string)
  // {
  //   return this.http.get<Developer>(this.baseApiUrl + '/api/Developer/' + id);
  // }
  // updateDeveloper(id:string, developerUpdate:Developer): Observable<Developer>
  // {
  //   return this.http.put<Developer>(this.baseApiUrl + '/api/Developer/'+ id, developerUpdate);
  // }

  // deleteDeveloper(id:string): Observable<Developer>
  // {
  //   return this.http.delete<Developer>(this.baseApiUrl +'/api/Developer/' + id);
  // }
}
