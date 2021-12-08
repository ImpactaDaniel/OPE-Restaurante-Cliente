import { Routes, RouterModule } from '@angular/router';
import { ActiveBasketComponent } from './active-basket/active-basket.component';

const routes: Routes = [
  {
    path: '',
    component: ActiveBasketComponent
  },
];

export const BasketRoutes = RouterModule.forChild(routes);
