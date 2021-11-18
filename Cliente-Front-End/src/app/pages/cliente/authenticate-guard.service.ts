import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { TokenService } from 'src/app/services/token.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticateGuardService implements CanActivate {

  constructor(private tokenService: TokenService) { }
  canActivate(): boolean {
    return !this.tokenService.isAuthenticated();
  }
}
