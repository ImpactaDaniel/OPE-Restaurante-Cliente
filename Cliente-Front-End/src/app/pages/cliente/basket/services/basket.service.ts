import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  constructor(@Inject('BASE_URL') private url: string, private httpClient: HttpClient) { }

  public getBasketByCustomer() {
    return this.httpClient.get<any>(this.url + 'Baskets/GetActiveBasket')
  }

  public addBasketItem(productId: number, quantity: number) {
    return this.httpClient.post(this.url + 'Baskets/AddBasketItem', {
      productId,
      quantity
    }, {
      responseType: 'arraybuffer'
    })
  }

  public removeBasketItem(productId: number) {
    return this.httpClient.delete(this.url + 'Baskets/RemoveBasketItem/' + productId, {
      responseType: 'arraybuffer'
    });
  }

}
