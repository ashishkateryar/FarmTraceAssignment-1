import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-farm-data',
  templateUrl: './fetch-farm-data.component.html'
})
export class FetchFarmDataComponent {
  public farmInfoList: FarmInfo[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<FarmInfo[]>(baseUrl + 'farmdata').subscribe(result => {
      this.farmInfoList = result;
    }, error => console.error(error));
  }
}

interface FarmInfo {
  name: string;
  animals: Animal[];
}
interface Animal {
  id: number;
  sex: string;
  animalType: string;
  feedings: Feeding[];
  milkings: Milking[];
}

interface Feeding {
  dateTime: Date;
  amount: number;
}

interface Milking {
  dateTime: Date;
  amount: number;
}
  
