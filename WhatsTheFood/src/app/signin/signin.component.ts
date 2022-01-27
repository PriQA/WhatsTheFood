import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';


@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})


export class SigninComponent implements OnInit {
   
  private http: HttpClient;
  loading = false;
  submitted = false;

  constructor(public loginForm: FormGroup, http: HttpClient) {
    this.http = http;   

  }

  get f() { return this.loginForm.controls; }

  ngOnInit(): void {
  }

  public executeSelectedChange = (event: any) => {
    console.log(event);
  }

  onSubmit() {
    this.submitted = true;
  }
}

interface user {
  name: string;
  password: string;
}
