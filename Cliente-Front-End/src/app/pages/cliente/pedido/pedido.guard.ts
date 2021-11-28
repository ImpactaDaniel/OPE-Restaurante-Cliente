import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { TokenService } from "src/app/services/token.service";

@Injectable({ providedIn: 'root' })
export class PedidoGuard implements CanActivate {

  constructor(private tokenService: TokenService, private router: Router) { }

  canActivate(): boolean {
    if(!this.tokenService.isAuthenticated()){
      this.router.navigate(['/cliente/login']);  
      return false
    }
    return true
  }
}
