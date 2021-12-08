import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketRoutes } from './basket.routing';
import { ActiveBasketComponent } from './active-basket/active-basket.component';

@NgModule({
  declarations: [ActiveBasketComponent],
  imports: [
    CommonModule,
    BasketRoutes
  ],
  exports: [ActiveBasketComponent]
})
export class BasketModule { }
