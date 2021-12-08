import { Routes, RouterModule } from '@angular/router';
import { ActiveBasketComponent } from './active-basket/active-basket.component';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./active-basket/active-basket.module').then(m => m.ActiveBasketModule)
  },
];

export const BasketRoutes = RouterModule.forChild(routes);
