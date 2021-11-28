import { ViewEncapsulation } from '@angular/compiler/src/core';
import { Component, Inject, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { InvoiceStatus } from 'src/app/models/common/invoiceStatus';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-historico-pedido',
  templateUrl: './historico-pedido.component.html',
  styleUrls: ['./historico-pedido.component.scss']
})
export class HistoricoPedidoComponent implements OnInit {
  encapsulation: ViewEncapsulation.None
  public barColor: string = 'red';
  public pedidosList: any
  public invoiceStatusClosed = [InvoiceStatus.Rejected, InvoiceStatus.Closed]
  public statusList = [
    {status: InvoiceStatus.Created, name: 'Criado', value: 20, color: 'orange'}, 
    {status: InvoiceStatus.Accepted, name: 'Aceito', value: 40, color: 'blue'}, 
    {status: InvoiceStatus.Rejected, name: 'Rejeitado', value: 0, color: 'red'},
    {status: InvoiceStatus.PaymentPending, name: 'Pagamento Pendente', value: 50, color: 'orange'}, 
    {status: InvoiceStatus.Payed, name: 'Pago', value: 60, color: 'blue'},
    {status: InvoiceStatus.Shipped, name: 'Enviado', value: 80, color: 'green'}, 
    {status: InvoiceStatus.Delivered, name: 'Entregue', value: 100, color: 'green'},
    {status: InvoiceStatus.Closed, name: 'Fechado', value: 0, color: 'gray'}
  ]

  constructor(@Inject('BASE_URL') public url: string, public clienteService: ClienteService) { }

  ngOnInit(): void {
    this.getAllInvoices();
  }

  private getAllInvoices() {

    this.clienteService.getInvoicesByCustomer().subscribe(res => {
      console.log(res)
      this.pedidosList = res
    })
  }

  public details(id: string) {
    console.log(id)
    this.clienteService.getInvoiceById(id).subscribe(res => {
      console.log(res)
    })
  }

  public cart(id: string) {
    console.log(id)
  }

}
