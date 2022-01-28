import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  signin(username: string, password: string): Observable<any> {
    return this.http.post('/user/authenticate', {
      username,
      password
    }, httpOptions);
  }

  signup(username: string, email: string, password: string, firstname: string, lastname: string, phonenumber: string, streetaddress1: string, streetaddress2: string, city: string, state: string, zipcode: string): Observable<any> {
    return this.http.post('/home/user/register', {
      username,
      email,
      password,
      firstname,
      lastname,
      phonenumber,
      streetaddress1,
      streetaddress2,
      city,
      state,
      zipcode
    }, httpOptions);
  }
}
