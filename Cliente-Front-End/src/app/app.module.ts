import { GlobalErrorHandler } from './middlewares/GlobalErrorHandler';
import { Error404Component } from './components/errors/error404/error404.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RequestInterceptor } from './middlewares/TokenInterceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderModule } from './components/navigation/header/header.module';
import { SideNavModule } from './components/navigation/side-nav/side-nav.module';
import { ErrorHandler, NgModule } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { PedidoDialogModule } from './components/dialogs/pedido-dialog/pedido-dialog.module';
import {MatSnackBarModule} from '@angular/material/snack-bar';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    RouterModule.forRoot([
      {
        path: 'cliente',
        loadChildren: () => import('./pages/cliente/cliente.module').then(m => m.ClienteModule),
      },
      {
        path: 'cliente/pedido',
        loadChildren: () => import('./pages/cliente/pedido/pedido.module').then(m => m.PedidoModule),
      },
      {
        path: 'restaurante',
        loadChildren: () => import('./pages/restaurante/restaurante.module').then(m => m.RestauranteModule)
      },
      {
        path: '**',
        component: Error404Component
      }
    ]),
    HttpClientModule,
    BrowserAnimationsModule,
    SideNavModule,
    HeaderModule,
    MatSidenavModule,
    MatDialogModule,
    MatSnackBarModule,
    PedidoDialogModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: RequestInterceptor,
      multi: true
    },
    {
      provide: ErrorHandler,
      useClass: GlobalErrorHandler
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
