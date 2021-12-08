import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { NgModule } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { RouterModule, Routes } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { CriarPedidoComponent } from './criar-pedido.component';
import { PedidoGuard } from '../pedido.guard';
import { MatExpansionModule } from '@angular/material/expansion';
import { CommonModule } from '@angular/common';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatButtonModule } from '@angular/material/button';
import {MatStepperModule} from '@angular/material/stepper';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatRadioModule} from '@angular/material/radio';


const routes: Routes = [
  {
    path: '',
    component: CriarPedidoComponent,
    canActivate: [PedidoGuard]
  }
]

@NgModule({
  declarations: [CriarPedidoComponent],
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatCardModule,
    MatSelectModule,
    MatExpansionModule,
    MatProgressBarModule,
    MatButtonModule,
    MatStepperModule,
    MatFormFieldModule,
    MatRadioModule,
    RouterModule.forChild(routes)
  ]
})
export class CriarPedidoModule { }
