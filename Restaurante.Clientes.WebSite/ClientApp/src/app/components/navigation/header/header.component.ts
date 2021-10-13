import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../pages/cliente/services/auth-service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  userNameLogged: string;

  @Output() public sidenavToggle = new EventEmitter();

  constructor(private authService: AuthService, public router: Router) {

  }

  ngOnInit(): void {
    this.getUserNameLogged()
  }

  public onToggleSidenav = () => {
    this.sidenavToggle.emit()
  }

  getUserNameLogged() {
    let localstorage = localStorage.getItem('cliente')
    if (localstorage) {
      let userData = JSON.parse(localstorage)
      this.userNameLogged = userData.username
    }
  }

  logOut() {
    this.authService.logout()
  }

}
