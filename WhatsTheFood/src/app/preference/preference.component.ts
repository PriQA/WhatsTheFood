import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-prefernce',
  templateUrl: './preference.component.html',
  styleUrls: ['./preference.component.css']
})

export class PrefernceComponent implements OnInit {

  public ingredients?: ingredient[];
  private httpClient: HttpClient;

  prefernceForm: any;
  errorMessage = '';

  form: any = {
    likes: null,
    dislikes: null
  };
  
  constructor(httpClient: HttpClient, private formBuilder: FormBuilder) {

    this.prefernceForm = this.formBuilder.group({
      selectedDislikes: '',
      selectedLikes:''
    });

    this.httpClient = httpClient;
    httpClient.get<ingredient[]>('/ingredient').subscribe(result => {
      this.ingredients = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

  public executeSelectedChange = (event: any) => {
    console.log(event);
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
      },
      error: error => {
        this.errorMessage = error.message
        console.error('There was an error!', error);
      }
    })
  }

}

interface ingredient {
  ingredientId: number;
  name: string;
}
