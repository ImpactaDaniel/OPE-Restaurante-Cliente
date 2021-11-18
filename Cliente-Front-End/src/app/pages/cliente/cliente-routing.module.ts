import { AuthenticateGuardService } from './authenticate-guard.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CreateClienteComponent } from './create-cliente/create-cliente.component';
//import { EditClienteComponent } from './edit-cliente/edit-cliente.component';
import { ClienteGuard } from './cliente.guard';
import { LoginClienteComponent } from './login-cliente/login-cliente';

const routes: Routes = [
  {
    path: 'create',
    component: CreateClienteComponent
  },
  //{
  //  path: 'edit',
  //  component: EditClienteComponent
  //},
  {
    path: 'login',
    component: LoginClienteComponent,
    canActivate: [AuthenticateGuardService]
  }
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class ClienteRoutingModule { }
