import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PedidoRoutingModule } from './pedido-routing.module';
import { NgxMaskModule } from 'ngx-mask';
import { LogoModule } from 'src/app/components/logo/logo.module';
import { HistoricoPedidoComponent } from './historico-pedido/historico-pedido.component';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [HistoricoPedidoComponent],
  imports: [
    CommonModule,
    PedidoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatSelectModule,
    NgxMaskModule.forRoot(),
    MatInputModule,
    LogoModule,
    MatCardModule,
    MatTableModule,
    MatExpansionModule,
    MatIconModule
  ]
})
export class PedidoModule { }
