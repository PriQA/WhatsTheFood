import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})

export class SigninComponent implements OnInit {
  private httpClient: HttpClient;
  form: any = {
    username: null,
    password: null
  };
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  roles: string[] = [];

  constructor(httpClient: HttpClient) {
    this.httpClient = httpClient;
  }

  ngOnInit(): void {
    //if (this.tokenStorage.getToken()) {
    //  this.isLoggedIn = true;
    //  this.roles = this.tokenStorage.getUser().roles;
    //}
  }

  onSubmit(): void {
    const { username, password } = this.form;

    const url = '/user/signin';
    const body = {
      username, password
    }
    const headers = new Headers(
      {
        'Content-Type': 'application/json'
      });
    this.httpClient.post(url, body).subscribe({
      next: data => {
        // this.token = data.;
        console.log(data);
        this.isLoggedIn = true;
        this.isLoginFailed = false;
      },
      error: error => {
        this.errorMessage = error.message
        console.error('There was an error!', error);
      }
    })
  }


  reloadPage(): void {
    window.location.reload();
  }
}
