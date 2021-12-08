import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-criar-pedido',
  templateUrl: './criar-pedido.component.html',
  styleUrls: ['./criar-pedido.component.css']
})
export class CriarPedidoComponent implements OnInit {

  public columnsToDisplay = ['name', 'accompaniments', 'price', 'quantity']
  public products: any

  constructor(private _formBuilder: FormBuilder, private router: Router, public clienteService: ClienteService) {}

  ngOnInit() {
    this.getCartProducts();
  }

  private getCartProducts() {
    this.clienteService.getCartProducts().subscribe(res => {
      this.products = res.items;
      console.log(res)
    })
  }

  public createInvoice() {

  }

  public toCart(): void {
    this.router.navigate(['cliente/pedido/carrinho'])
  }

}
