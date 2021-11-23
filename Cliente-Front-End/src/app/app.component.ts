import { ThrowStmt } from '@angular/compiler';
import { AfterContentChecked, Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements AfterContentChecked {
  title = 'app';
  showMenu: Boolean;

  constructor(private router: Router) {}

  async ngAfterContentChecked(){
    this.showMenu = await this.showMenuEvent()
  }

  async showMenuEvent(): Promise<boolean> {
    return new Promise((s, f) => {
      this.router.events.pipe(filter(ev => ev instanceof NavigationEnd)).subscribe((event: NavigationEnd) => {
        s(event.url.indexOf('login') < 0);
      });
    })
  }
}
