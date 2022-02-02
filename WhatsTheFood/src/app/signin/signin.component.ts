import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TokenStorageService } from '../_service/token-storage.service';


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
  firstname = "";

  constructor(httpClient: HttpClient, private tokenStorage: TokenStorageService) {
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

    const url = '/user/authenticate';
    const body = {
      username, password
    }
    const headers = new Headers(
      {
        'Content-Type': 'application/json'
      });
    this.httpClient.post<authenticationReponse>(url, body).subscribe({
      next: data => {
        this.tokenStorage.saveToken(data.token);
        this.tokenStorage.saveUser(data.role);
        this.roles = this.tokenStorage.getUser().roles;
        this.firstname = data.firstName;        
        console.log(data);
        this.isLoggedIn = true;
        this.isLoginFailed = false;
       

      },
      error: error => {
        this.errorMessage = error.message
        this.isLoginFailed = true;
        console.error('There was an error!', error);
      }
    })

  }


  reloadPage(): void {
    window.location.reload();
  }
}

interface authenticationReponse {
  isAuthenticated: boolean;
  token: string;
  role:string
  firstName: string;
  lastName: string;
}
