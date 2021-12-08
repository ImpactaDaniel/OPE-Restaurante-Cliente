import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  constructor(@Inject('BASE_URL') private url: string, private httpClient: HttpClient) { }

  public getInvoicesByCustomer() {
    return this.httpClient.get<any>(this.url + 'Baskets/GetActiveBasket')
  }

}
