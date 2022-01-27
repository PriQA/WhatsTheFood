import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ColDef } from 'ag-grid-community';
import { ImageFormatterComponent } from "../_helper/ImageFormatterComponent";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  public calories?: any[];
  public foods?: food[];
  private http: HttpClient;

  columnDefs: ColDef[] = [
    { field: 'name' },
    { field: 'calorie' },
    { field: 'price' },
    {
      headerName: '',
      field: 'imageLocation',
      width: 100,
      sortable: false,
      autoHeight: true,
      cellRendererFramework: ImageFormatterComponent
    }];

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

    this.http.get<food[]>('/food/' + value).subscribe(result => {
      this.foods = result;
    }, error => console.error(error));


  }

  ngOnInit(): void {
  }

  public executeSelectedChange = (event: any) => {
    console.log(event);
  }
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
  imageLocation: string
}
