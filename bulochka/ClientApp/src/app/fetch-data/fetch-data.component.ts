import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BulochkaService } from '../services/bulochka.service';
import { IBulochka } from '../shared/models/bulochka';
import { PredictionService } from '../services/prediction.service';
import { Bulochka } from '../shared/models/bulochka.model';
import { Observable, observable, Subscription, timer } from 'rxjs';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  providers: [BulochkaService,PredictionService]
})
export class FetchDataComponent implements OnInit {

  public bulochki: Bulochka[];
  timer: any;
  constructor(private bulochkaService:BulochkaService,private predictionservice: PredictionService) {  }
  
  ngOnInit(): void {
    this.bulochkaService.getData().subscribe((data:IBulochka[]) => {
      this.bulochki = <Bulochka[]>data;
      this.bulochki.forEach(element => {
        element.futurePrice = this.predictionservice.getFuturePrice(element);
      })
    })
    this.timer = timer(1000,1000);
    this.timer.subscribe(()=> {
    this.bulochki.forEach(element =>
      {
        if(element.type.id == 2 && element.startPrice == element.currentPrice)
          element.secToChange = Math.round((new Date(element.controlSellTime).getTime() - new Date().getTime())/1000); 
        if(element.type.id !=2)
        {
          element.secToChange = Math.round((new Date(element.lastupdateTimestamp).getTime() + 1000*60*60 - new Date().getTime())/1000);
        }
        if(element.secToChange<0)
          element.secToChange=0;
      })    
    })
  }
}

