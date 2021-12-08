import { HttpClient } from '@angular/common/http';
import { EventEmitter, Inject, Injectable, Output } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  @Output() basketUpdated = new EventEmitter<boolean>();

  constructor(@Inject('BASE_URL') private url: string, private httpClient: HttpClient) { }

  public getBasketByCustomer() {
    return this.httpClient.get<any>(this.url + 'Baskets/GetActiveBasket')
  }

  public addBasketItem(productId: number, quantity: number, callback: (res: any) => any) {
    return this.httpClient.post(this.url + 'Baskets/AddBasketItem', {
      productId,
      quantity
    }, {
      responseType: 'arraybuffer'
    }).subscribe((res) => {
      callback(res);
      this.basketUpdated.emit();
    })
  }

  public removeBasketItem(productId: number, callback: (res: any) => any) {
    return this.httpClient.delete(this.url + 'Baskets/RemoveBasketItem/' + productId, {
      responseType: 'arraybuffer'
    }).subscribe(res => {
      this.basketUpdated.emit(true);
      callback(res);
    })
  }

}
