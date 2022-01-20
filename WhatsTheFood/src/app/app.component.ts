import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public forecasts?: WeatherForecast[];
  public calories?: any[];

  constructor(http: HttpClient) {

    /*
     http.get<WeatherForecast[]>('/weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
    */

    http.get<any[]>('/home/calories').subscribe(result => {
      this.calories = result;
    }, error => console.error(error));
  }

  public filterCalory(filterVal: number) {
    /*
    if (filterVal == "0")
      this.forecasts = this.cacheForecasts;
    else
      this.forecasts = this.cacheForecasts.filter((item) => item.summary == filterVal);*/
  }

  title = 'WhatsTheFood';
}
interface calorie {
  name: string;
}


interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
