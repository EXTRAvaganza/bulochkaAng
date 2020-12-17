import { Injectable } from '@angular/core';
import { IBulochka } from '../shared/models/bulochka';
import { BulochkaService } from './bulochka.service';
import { Bulochka } from '../shared/models/bulochka.model';
import { Observable } from 'rxjs';

@Injectable()
export class PredictionService {

  constructor(private bulochkaService:BulochkaService)   { }

  getFuturePrice(element:Bulochka)
  {
    if(element.type.id == 2)
    {
        return element.currentPrice/2;
    }
    else if(element.type.id == 4)
    {
      return element.currentPrice*0.96;  
    }
    else 
    {
      return element.currentPrice*0.98;
    }
  }
}