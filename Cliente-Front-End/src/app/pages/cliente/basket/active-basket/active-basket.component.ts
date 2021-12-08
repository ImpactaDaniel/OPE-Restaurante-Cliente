import { Router } from '@angular/router';
import { AlertService } from './../../../../services/alert.service';
import { BasketService } from './../services/basket.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-active-basket',
  templateUrl: './active-basket.component.html',
  styleUrls: ['./active-basket.component.css']
})
export class ActiveBasketComponent implements OnInit {

  public basketItems: any;

  constructor(private basketService: BasketService, private alertService: AlertService, private router: Router) { }

  ngOnInit() {
    this.getBasket();
  }

  private getBasket() {
    this.basketService.getBasketByCustomer().subscribe(res => {
      this.basketItems = res?.items;
    })
  }

  public updateQuantity(item: any, quantity: number) {
    item.quantity = quantity;
  }

  public updateBasketItem(product: any, quantity: number) {
    this.basketService.addBasketItem(product?.id, quantity, () => {
      this.alertService.showSuccess('Atualizado', 'Item atualizado com sucesso!');
      this.getBasket();
    });
  }

  public toInvoice() {
    this.router.navigate(['/cliente/pedido/criar']);
  }

  public removeBasketItem(product: any) {
    this.alertService.showQuestion(`Confirmar`, `Remover ${product?.name} do carrinho?`, () => {
      this.basketService.removeBasketItem(product?.id, () => {
        this.alertService.showSuccess('Removido', 'Item removido com sucesso!');
        this.getBasket();
      });
    })
  }

}
