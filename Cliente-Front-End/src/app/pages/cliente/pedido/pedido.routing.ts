import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'historico',
    loadChildren: () => import('./historico-pedido/historico-pedido.module').then(m => m.HistoricoPedidoModule)
  },
];

export const PedidoRoutes = RouterModule.forChild(routes);
