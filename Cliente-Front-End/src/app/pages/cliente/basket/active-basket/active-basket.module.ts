import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { RouterModule, Routes } from "@angular/router";
import { PedidoGuard } from "../../pedido/pedido.guard";
import { ActiveBasketComponent } from "./active-basket.component";

const routes: Routes = [
  {
    path: '',
    component: ActiveBasketComponent,
    canActivate: [PedidoGuard]
  }
]


@NgModule({
  declarations: [ActiveBasketComponent],
  imports: [
    CommonModule,
    MatIconModule,
    MatInputModule,
    MatCardModule,
    RouterModule.forChild(routes)
  ]
})
export class ActiveBasketModule { }
