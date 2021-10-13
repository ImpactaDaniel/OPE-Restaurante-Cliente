import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { AuthGuardService } from 'src/app/guards/auth.guard';

const routes: Routes = [
  {
    //path: 'history', component: DeliveryHistoryComponent, canActivate: [AuthGuardService]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)],
})
export class ClienteRoutingModule { }
