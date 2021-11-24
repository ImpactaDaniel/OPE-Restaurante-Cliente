import { ThrowStmt } from '@angular/compiler';
import { AfterContentChecked, Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
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

  constructor(private router: Router, private tokenService: TokenService, private invoiceHubService: InvoiceHubServiceService) {}

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
    console.log('here');
    if(this.tokenService.isAuthenticated()){
      this.invoiceHubService.init();
      return;
    }
    this.invoiceHubService.stopConnection();
  }

  async showMenuEvent(): Promise<boolean> {
    return new Promise((s, f) => {
      this.router.events.pipe(filter(ev => ev instanceof NavigationEnd)).subscribe((event: NavigationEnd) => {
        s(event.url.indexOf('login') < 0);
      });
    })
  }
}
