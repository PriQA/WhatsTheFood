import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_service/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
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

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const { username, email, password, firstname,lastname,phonenumber,streetaddress1, streetaddress2, city, state,zipcode} = this.form;

    this.authService.signup(username, email, password, firstname, lastname, phonenumber, streetaddress1, streetaddress2, city, state, zipcode).subscribe(
      data => {
        console.log(data);
        this.isSuccessful = true;
        this.isSignUpFailed = false;
      },
      err => {
        this.errorMessage = err.error.message;
        this.isSignUpFailed = true;
      }
    );
  }
}
