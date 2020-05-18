import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../_models';
import { Observable, throwError } from 'rxjs';
import { map, delay, catchError } from 'rxjs/operators';

@Injectable()

export class UserService {
    constructor(private http: HttpClient) { }

    
    register(user: User): Observable<any> {
        return this.http.post(`http://localhost:5001/api/users/register`, user);
    }
    resetPassword(email:string){
      return this.http.get<IResponse>('http://localhost:5001/api/users/ForgotPassword/',{
            params:
            {
                model:email
            }
        }).pipe(
            catchError((err) => {
                console.log('error', err);
                return throwError(err);
            })
        );
    }
    checkEmail(s: string): Observable<any> {

        return this.http.get<IResponse>('http://localhost:5001/api/users/checkEmail/',{
            params:
            {
                model:s
            }
        }).pipe(
            catchError((err) => {
                console.log('error', err);
                return throwError(err);
            })
        );

    }
}
interface IResponse {
    email: string
}
