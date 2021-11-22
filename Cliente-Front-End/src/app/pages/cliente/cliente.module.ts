import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateClienteComponent } from './create-cliente/create-cliente.component';
//import { EditClienteComponent } from './edit-cliente/edit-cliente.component';
import { ClienteRoutingModule } from './cliente-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginClienteComponent } from './login-cliente/login-cliente';
import { NgxMaskModule } from 'ngx-mask';
import { LogoModule } from 'src/app/components/logo/logo.module';

@NgModule({
  declarations: [CreateClienteComponent,
    //EditClienteComponent,
    LoginClienteComponent],
  imports: [
    CommonModule,
    ClienteRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatSelectModule,
    NgxMaskModule.forRoot(),
    MatInputModule,
    LogoModule
  ]
})
export class ClienteModule { }
