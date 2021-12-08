import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { Listener } from 'selenium-webdriver';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-criar-pedido',
  templateUrl: './criar-pedido.component.html',
  styleUrls: ['./criar-pedido.component.css']
})
export class CriarPedidoComponent implements OnInit {

  public columnsToDisplay = ['name', 'accompaniments', 'price', 'quantity']
  public products: any
  form: FormGroup;
  public cartoes: any[];

  constructor(private formBuilder: FormBuilder, private router: Router, public clienteService: ClienteService) {}

  ngOnInit() {
    this.getCartProducts();
    this.form = this.formBuilder.group({
      numero: ["", Validators.required],
      validade: ["", Validators.required],
      codigo: ["", Validators.required],
    })
  }

  public cadastrarCartao() {
    if (!this.form.valid) return;
    this.cartoes.push(this.form.value);
    console.log(this.cartoes)
  }

  private getCartProducts() {
    this.clienteService.getCartProducts().subscribe(res => {
      this.products = res?.items;
      console.log(res)
    })
  }

  public createInvoice() {

  }

  public toCart(): void {
    this.router.navigate(['cliente/pedido/carrinho'])
  }

}