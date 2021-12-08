import { BasketService } from './../../../pages/cliente/basket/services/basket.service';
import { AfterViewChecked, Component, EventEmitter, OnInit, Output } from "@angular/core";
import { Router } from "@angular/router";
import { TokenService } from "src/app/services/token.service";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.scss"],
})
export class HeaderComponent implements OnInit {

  @Output() public sidenavToggle = new EventEmitter();

  public cartItemsLength = 0;

  userNameLogged = "";

  constructor(
    private authService: TokenService,
    private router: Router,
    private cartService: BasketService
  ) { }

  ngOnInit() {
    this.getUserName();
    this.getCartItemsLength();
    this.cartService.basketUpdated.subscribe(() => {
      this.getCartItemsLength();
    })
    this.authService.userChanged.subscribe(() => {
      this.getUserName();
    });
  }

  private getCartItemsLength() {
    this.cartService.getBasketByCustomer().subscribe(cart => {
      this.cartItemsLength = cart?.items?.length;
      console.log(this.cartItemsLength)
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

  public toCart = () => {
    this.router.navigate(["/cliente/cart"]);
  }

  logOut() {
    this.authService.logout();
    this.router.navigate(["/cliente/login"]);
  }
}
