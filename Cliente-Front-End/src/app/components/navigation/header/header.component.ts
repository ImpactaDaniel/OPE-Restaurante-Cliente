import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { Router } from "@angular/router";
import { TokenService } from "src/app/services/token.service";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.scss"],
})
export class HeaderComponent implements OnInit {

  @Output() public sidenavToggle = new EventEmitter();

  userNameLogged = "";

  constructor(
    private authService: TokenService,
    private router: Router
  ) { }

  ngOnInit() {
    this.getUserName();
    this.authService.userChanged.subscribe(() => {
      this.getUserName();
    });
  }

  private getUserName() {
    this.userNameLogged = "";
    if (this.authService.isAuthenticated())
      this.userNameLogged = this.authService.getTokenData().unique_name;
  }

  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  };

  logOut() {
    this.authService.logout();
    this.router.navigate(["/cliente/login"]);
  }
}
