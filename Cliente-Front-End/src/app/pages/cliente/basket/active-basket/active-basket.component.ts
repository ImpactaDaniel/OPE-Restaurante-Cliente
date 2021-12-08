import { BasketService } from './../services/basket.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-active-basket',
  templateUrl: './active-basket.component.html',
  styleUrls: ['./active-basket.component.css']
})
export class ActiveBasketComponent implements OnInit {

  constructor(private basketService: BasketService) { }

  ngOnInit() {
    this.basketService.getInvoicesByCustomer().subscribe(res => {
      console.log(res);
    })
  }

}
