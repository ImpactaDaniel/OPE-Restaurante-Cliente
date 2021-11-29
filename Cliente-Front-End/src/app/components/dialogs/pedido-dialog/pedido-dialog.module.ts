import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatExpansionModule} from '@angular/material/expansion';
import { PedidoDialogComponent } from './pedido-dialog.component';


@NgModule({
  declarations: [PedidoDialogComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatTableModule,
    MatExpansionModule
  ],
  exports: [PedidoDialogComponent]
})
export class PedidoDialogModule { }
