import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError, observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Profile } from '../models/Profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) { }

  getPublicProfile(userId: string): Observable<Profile> {

    return this.http.get<Profile>('http://localhost:5001/api/profile/public', {
      params:
      {
        model: userId
      }
    }).pipe(
      catchError((err) => {
        console.log('error', err);
        return throwError(err);
      })
    );

  }
  updateName(firstName: string, lastName: string): Observable<Profile> {
    return this.http.post<Profile>('http://localhost:5001/api/profile/updatename', {
      firstName:firstName,
      lastName:lastName,
    })
  }
}
