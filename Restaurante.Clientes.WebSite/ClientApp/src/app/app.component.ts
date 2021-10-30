import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'app';

  /**
   *
   */
  constructor(private router: Router) {


  }

  async mostrarMenu(): Promise<boolean> {
    return new Promise((s, f) => {
      this.router.events.pipe(filter(ev => ev instanceof NavigationEnd)).subscribe((event: NavigationEnd) => {
        s(event.url.indexOf('login') < 0 && event.url.indexOf('signup') < 0);
      });
    })
  }
}
