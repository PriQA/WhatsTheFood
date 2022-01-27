import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})


export class SignupComponent implements OnInit {

 
  loading = false;
  submitted = false;

  constructor(public formGroup: FormGroup, private httpclient: HttpClient, private formBuilder: FormBuilder) {
   
  } 

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  get f() { return this.formGroup.controls; }

  public executeSelectedChange = (event: any) => {
    console.log(event);
  }

  onSubmit() {
    this.submitted = true;  

    if (this.formGroup.invalid) {
      return;
    }

    this.loading = true;
   
  }

}

interface user {
  name: string;
}

