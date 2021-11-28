import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PedidoGuard } from './pedido.guard';
import { HistoricoPedidoComponent } from './historico-pedido/historico-pedido.component';

const routes: Routes = [
  {
    path: 'historico',
    component: HistoricoPedidoComponent, canActivate: [PedidoGuard]
  },
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class PedidoRoutingModule { }
