import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketRoutes } from './basket.routing';
import { ActiveBasketComponent } from './active-basket/active-basket.component';

@NgModule({
  imports: [
    CommonModule,
    BasketRoutes
  ]
})
export class BasketModule { }
