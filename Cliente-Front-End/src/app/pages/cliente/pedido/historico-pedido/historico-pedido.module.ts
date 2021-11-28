import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { NgModule } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { RouterModule, Routes } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { HistoricoPedidoComponent } from './historico-pedido.component';
import { PedidoGuard } from '../pedido.guard';
import { MatExpansionModule } from '@angular/material/expansion';


const routes: Routes = [
  {
    path: '',
    component: HistoricoPedidoComponent,
    canActivate: [PedidoGuard]
  }
]

@NgModule({
  declarations: [HistoricoPedidoComponent],
  imports: [
    FormsModule,
    MatSelectModule,
    MatInputModule,
    MatCardModule,
    MatTableModule,
    MatExpansionModule,
    MatIconModule,
    RouterModule.forChild(routes)
  ]
})
export class HistoricoPedidoModule { }
