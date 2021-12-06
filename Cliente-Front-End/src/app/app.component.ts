import { AfterContentChecked, Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
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

  constructor(private router: Router, private tokenService: TokenService, private invoiceHubService: InvoiceHubServiceService, private snackBar: MatSnackBar) {}

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
    this.invoiceHubService.emmiter.subscribe(({id, status}) => {
      this.snackBar.open(`Pedido ${id} atualizado status: ${status}!`, 'verificar', {
        horizontalPosition: 'right',
        verticalPosition: 'top',
        duration: 5000
      }).onAction().subscribe(res => {
        console.log(res);
      });
    })
  }

  async showMenuEvent(): Promise<boolean> {
    return new Promise((s, f) => {
      this.router.events.pipe(filter(ev => ev instanceof NavigationEnd)).subscribe((event: NavigationEnd) => {
        s(event.url.indexOf('login') < 0);
      });
    })
  }
}
