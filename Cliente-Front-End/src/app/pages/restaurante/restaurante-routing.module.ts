import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { RestauranteGuard } from './restaurante.guard';
import { MenuRestauranteComponent } from './menu-restaurante/menu-restaurante.component';

const routes: Routes = [
  {
    path: 'menu',
    component: MenuRestauranteComponent
  },
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class RestauranteRoutingModule { }
