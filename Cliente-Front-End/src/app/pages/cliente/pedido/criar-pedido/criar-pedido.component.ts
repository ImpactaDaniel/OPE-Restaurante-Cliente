import { BasketService } from './../../basket/services/basket.service';
import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { Listener } from 'selenium-webdriver';
import { Cliente } from 'src/app/models/cliente/cliente';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-criar-pedido',
  templateUrl: './criar-pedido.component.html',
  styleUrls: ['./criar-pedido.component.css']
})
export class CriarPedidoComponent implements OnInit {

  public columnsToDisplay = ['name', 'accompaniments', 'price', 'quantity', 'total']
  public products: any
  form: FormGroup;
  public creditCard: any[] = [];
  public customerData: any;

  constructor(private formBuilder: FormBuilder, private router: Router, public clienteService: ClienteService, private cartService: BasketService) {}

  ngOnInit() {
    this.getCartProducts();
    this.getCurrentCustomer();
    this.form = this.formBuilder.group({
      numero: ["", Validators.required],
      validade: ["", Validators.required],
      codigo: ["", Validators.required],
    })
  }

  private getCurrentCustomer() {
    this.clienteService.getCurrentCustomer().subscribe(res => {
      this.customerData = res?.entidade?.enderecos[0];
      console.log(res)
      console.log(this.customerData)
    })
  }

  public createCreditCard() {
    if (!this.form.valid) return;
    this.creditCard.push(this.form.value);
    console.log(this.creditCard)
  }

  private getCartProducts() {
    this.cartService.getBasketByCustomer().subscribe(res => {
      this.products = res?.items;
    })
  }

  public createInvoice() {

  }

  public toCart(): void {
    this.router.navigate(['cliente/cart'])
  }

}
