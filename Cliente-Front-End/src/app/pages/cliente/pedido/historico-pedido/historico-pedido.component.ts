import { Component, Inject, OnInit } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-historico-pedido',
  templateUrl: './historico-pedido.component.html',
  styleUrls: ['./historico-pedido.component.css']
})
export class HistoricoPedidoComponent implements OnInit {

  public pedidosList: any
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

  public toDetails(id: string) {
    console.log(id)
  }

  public toCart(id: string) {
    console.log(id)
  }

}
