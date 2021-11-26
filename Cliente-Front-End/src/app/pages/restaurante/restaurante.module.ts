import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestauranteRoutingModule } from './restaurante-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
import { LogoModule } from 'src/app/components/logo/logo.module';
import { MenuRestauranteComponent } from './menu-restaurante/menu-restaurante.component';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import {MatExpansionModule} from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [MenuRestauranteComponent],
  imports: [
    CommonModule,
    RestauranteRoutingModule,
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
export class RestauranteModule { }
