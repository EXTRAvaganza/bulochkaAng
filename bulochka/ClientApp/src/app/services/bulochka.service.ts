import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { IBulochka } from '../shared/models/bulochka';

@Injectable()
export class BulochkaService {

  constructor(private httpClient: HttpClient,@Inject('BASE_URL') baseUrl: string) { }

  getData() {
    let bulochki;
    return this.httpClient.get<IBulochka[]>(document.getElementsByTagName('base')[0].href + 'bulochka');
  }
}
// 