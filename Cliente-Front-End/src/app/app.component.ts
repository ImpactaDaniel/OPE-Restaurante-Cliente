import { AlertService } from './services/alert.service';
import { AfterContentChecked, Component, OnInit } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { InvoiceHubServiceService } from './services/invoice-hub-service/invoice-hub-service.service';
import { TokenService } from './services/token.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements AfterContentChecked, OnInit {
  title = 'app';
  showMenu: Boolean;

  constructor(private router: Router, private tokenService: TokenService, private invoiceHubService: InvoiceHubServiceService, private alertService: AlertService ) {}

  async ngAfterContentChecked(){
    this.showMenu = await this.showMenuEvent()
  }

  ngOnInit(){
    this.subscribeEvent();
    this.tokenService.userChanged.subscribe(() => {
      this.subscribeEvent();
    });
  }

  private subscribeEvent(){
    if(this.tokenService.isAuthenticated()){
      this.invoiceHubService.init();
      this.subscribeEventNotification();
      return;
    }
    this.invoiceHubService.stopConnection();
  }

  private subscribeEventNotification() {
    this.invoiceHubService.emmiter.subscribe((res: any) => {
      this.showSnackbar(res.id)
    })
  }

  private showSnackbar(id: any){
    this.alertService.showInfo('Pedido Atualizado', 'Visualizar', `Pedido ${id} atualizado!`, () => {
      this.router.navigate(['/cliente/pedido/historico']);
    })
  }

  async showMenuEvent(): Promise<boolean> {
    return new Promise((s, _) => {
      this.router.events.pipe(filter(ev => ev instanceof NavigationEnd)).subscribe((event: NavigationEnd) => {
        s(event.url.indexOf('login') < 0);
      });
    })
  }
}
