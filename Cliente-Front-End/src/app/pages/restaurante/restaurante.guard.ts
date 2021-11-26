import { Injectable } from "@angular/core";
import { CanActivate } from "@angular/router";
import { TokenService } from "src/app/services/token.service";

@Injectable({ providedIn: 'root' })
export class RestauranteGuard implements CanActivate {

  constructor(private tokenService: TokenService) { }

  canActivate(): boolean {
    return this.tokenService.isAuthenticated();
  }
}
