import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  private httpClient: HttpClient;

  form: any = {
    username: null,
    email: null,
    password: null,
    firstname: null,
    lastname: null,
    phonenumber: null,
    streetaddress1: null,
    streetaddress2: null,
    city: null,
    state: null,
    zipcode: null
  };
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';
 
  constructor(httpClient: HttpClient) {
    this.httpClient = httpClient;

  }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const { username, email, password, firstname, lastname, phonenumber, streetaddress1, streetaddress2, city, state, zipcode } = this.form;

        const url = '/user/register';
        const body = {
          username, email, password, firstname, lastname, phonenumber, streetaddress1, streetaddress2, city, state, zipcode 
        }
        const headers = new Headers(
        {
          'Content-Type': 'application/json'
        });
        this.httpClient.post(url, body).subscribe({
          next: data => {
           // this.token = data.;
            console.log(data);
            this.isSuccessful = true;
            this.isSignUpFailed = false;
          },
          error: error => {
            this.errorMessage = error.message
            console.error('There was an error!', error);
          }
        })   
  }
}




