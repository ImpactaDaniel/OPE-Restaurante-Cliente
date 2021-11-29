import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  templateUrl: './pedido-dialog.component.html',
  styleUrls: ['./pedido-dialog.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class PedidoDialogComponent implements OnInit {

  public expandedElement: any;

  public invoice: any;
  public invoiceTotalPrice: number = 0;
  public invoicesData = new MatTableDataSource<any>();
  public invoiceLogs = new MatTableDataSource<any>();

  public columnsToDisplay = ['productId', 'productName', 'accompaniments', 'quantity', 'price', 'obs']
  public columnsToDisplayLogs = ['logId', 'date', 'type', 'message']
  public invoiceLogType = [
    {id: 0, name: 'Criado'}, {id: 1, name: 'Atualizado'}, {id: 2, name: 'Deletado'}, {id: 3, name: 'Fechado'}
  ]

  constructor(@Inject(MAT_DIALOG_DATA) private data: any) { }

  ngOnInit(): void {
    this.invoice = this.data?.invoice;
    this.invoicesData.data = this.data?.invoice?.products;
    this.invoiceLogs.data = this.data?.invoice?.logs;
    this.invoiceTotalPrice = this.invoicesData.data.map(x => x.product.price * x.quantity)
                                                    .reduce((a, b) => a+b, 0)
  }

}
