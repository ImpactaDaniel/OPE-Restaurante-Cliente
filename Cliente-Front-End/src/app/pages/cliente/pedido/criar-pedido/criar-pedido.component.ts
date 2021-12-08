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
  public cart: any
  form: FormGroup;
  public creditCard: any[] = [];
  public customerData: any;
  public customerAddress: any;

  constructor(private formBuilder: FormBuilder, private router: Router, public clienteService: ClienteService, private cartService: BasketService) {}

  ngOnInit() {
    this.getCurrentCart();
    this.getCurrentCustomer();
    this.form = this.formBuilder.group({
      numero: ["", Validators.required],
      validade: ["", Validators.required],
      codigo: ["", Validators.required],
      tipoPagamento: ["", Validators.required]
    })
  }

  private getCurrentCustomer() {
    this.clienteService.getCurrentCustomer().subscribe(res => {
      this.customerData = res?.entidade?.enderecos[0];
    })
  }

  public createCreditCard() {
    if (!this.form.valid) return;
    this.creditCard.push(this.form.value);
  }

  private getCurrentCart() {
    this.cartService.getBasketByCustomer().subscribe(res => {
      this.cart = res;
      this.products = res?.items;
    })
  }

  public createInvoice() {
    const createInvoiceRequest = {
      customerAddress: this.customerData?.id,
      paymentType: this.form.value?.tipoPagamento,
      basketId: this.cart?.id
    }
    this.clienteService.createInvoice(createInvoiceRequest).subscribe(res => {
      this.cartService.basketUpdated.emit(true);
    })
  }

  public toCart(): void {
    this.router.navigate(['cliente/cart'])
  }

}
