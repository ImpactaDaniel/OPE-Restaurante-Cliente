import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'criar',
    loadChildren: () => import('./criar-pedido/criar-pedido.module').then(m => m.CriarPedidoModule)
  },
  {
    path: 'historico',
    loadChildren: () => import('./historico-pedido/historico-pedido.module').then(m => m.HistoricoPedidoModule)
  },
];

export const PedidoRoutes = RouterModule.forChild(routes);
