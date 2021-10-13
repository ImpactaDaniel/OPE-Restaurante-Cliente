import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { PasswordChangeComponent } from './password-change/password-change/password-change.component';

const routes: Routes = [
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'password-change', component: PasswordChangeComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)],
})
export class AuthRoutingModule { }
