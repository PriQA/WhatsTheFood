import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ColDef } from 'ag-grid-community';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  public calories?: any[];
  public foods?: food[];
  private http: HttpClient;

  columnDefs: ColDef[] = [
    { field: 'name' },
    { field: 'calorie' },
    { field: 'imageLocation' }];

  constructor(http: HttpClient) {
    this.http = http;
    http.get<any[]>('/home/calories').subscribe(result => {
      this.calories = result;
    }, error => console.error(error));

    this.http.get<food[]>('/food').subscribe(result => {
      this.foods = result;
    }, error => console.error(error));

  }

  public filterCalorie(value: string) {

    this.http.get<food[]>('/food/'+value).subscribe(result => {
      this.foods = result;
    }, error => console.error(error));


  }

  title = 'WhatsTheFood';
}
interface calorie {
  name: string;
}

interface calorie {
  name: string;
}

interface food {
  name: string;
  calorie: string;
  imageLocation:string
}
