import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CreateRideModel } from '../models/CreateRideModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarpoolService {

  constructor(private http:HttpClient) { }
  public createRide(createRide:CreateRideModel):Observable<CreateRideModel>
  {
    return this.http.post<CreateRideModel>(`http://localhost:5001/api/carpool/create`, createRide);
  }
  public getSingleRide(){}
}
