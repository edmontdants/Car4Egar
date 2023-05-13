import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICar } from 'src/app/Models/ICar';
import { IRentRequest } from 'src/app/Models/IRentRequest';
import { environment } from 'src/environment/environment';


@Injectable({
  providedIn: 'root'
})
export class UserServicesService {

  NID = String(sessionStorage.getItem('userNID'));
  constructor(private http : HttpClient) { }
  baseApiUrl :string = 'https://localhost:7136/Owner/GetAllRequests';

 public getAllRentalRequests() : Observable<any[]>
{

  return this.http.get<any[]>(this.baseApiUrl);
}

baseApiUrlUsers :string = 'https://localhost:7136/Admin/GetAllActivatedUsers';
public getAllUsers() : Observable<any[]>
{

  return this.http.get<any[]>(this.baseApiUrlUsers);
}

baseApiUrl2 :string = 'https://localhost:7136';
RegisterCar(NewCar:ICar)
{
  return this.http.post(this.baseApiUrl2 + '/Admin/RegisterNewCarVM', NewCar);
}
SetRentRequestStatus(vid: any,acc:number): Observable<any> {
  return this.http.get<any>(
    `${environment.apiBaseUrl}/Borrower/CarRentalRequestAcception` + '/' + vid+'/'+acc
  );
}
DeleteCarRequest(vid: string): Observable<any> {
  return this.http.delete<any>(
    `${environment.apiBaseUrl}/Borrower/CarRentalRequestDelete` + '/' + vid
  );

}

CancelCarRequest(vid: string): Observable<any> {
  return this.http.delete<any>(
    `${environment.apiBaseUrl}/Borrower/CarRentalRequestCancel` + '/' + vid
  );

}


}



