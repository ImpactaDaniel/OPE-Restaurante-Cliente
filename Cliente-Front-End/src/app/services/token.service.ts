import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, Output, EventEmitter } from '@angular/core';
import jwt_decode from 'jwt-decode';
import { APIResponse } from 'src/app/models/common/apiResponse';
import { LoginModel } from 'src/app/models/common/login';
import { TokenData } from 'src/app/models/common/token.data';
import { InvoiceHubServiceService } from './invoice-hub-service/invoice-hub-service.service';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  @Output() public userChanged = new EventEmitter();

  chaveToken = btoa('tokenRequest');
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private url: string) { }

  public isAuthenticated(): boolean {
    let token = this.getToken();
    if(token && token !== null){
      return true;
    }
    return false;
  }

  public getTokenData(): TokenData {
    return new TokenData(jwt_decode(this.getToken().token));
  }

  // public async updatePassowrd(changePassword: ChangePasswordModel): Promise<APIResponse<any>> {
  //   let response = await this.httpClient.post<APIResponse<any>>(this.url + 'Auth/ChangePassowrd', changePassword).toPromise();

  //   if (response.sucesso) {
  //     this.saveToken(response.response.result);
  //     this.userChanged.emit();
  //   }

  //   return response;
  // }

  private saveToken(token: any): void {
    let json = JSON.stringify(token);
    localStorage.setItem(this.chaveToken, btoa(json));
  }

  // public async renewToken(): Promise<boolean> {
  //   let response = await this.httpClient.get<APIResponse<any>>(this.url + 'Auth/RenewToken').toPromise();
  //   if (response.sucesso)
  //     this.saveToken(response.entidade.token);
  //   return response.sucesso;
  // }

  public async authenticate(login: LoginModel): Promise<APIResponse<any>> {
    let response = await this.httpClient.post<APIResponse<any>>(this.url + 'Cliente/LoginCustomer', login).toPromise();
    if (response.sucesso) {
      this.saveToken(response.entidade);
      this.userChanged.emit();
    }

    return response;
  }

  public logout() {
    localStorage.removeItem(this.chaveToken);
    this.userChanged.emit();
  }

  public getToken(): any {
    let json = this.returnFromLocalStorage(this.chaveToken);
    if (json === '' || !json)
      return null;
    return JSON.parse(json);
  }

  private returnFromLocalStorage(key: string): string {
    let value = localStorage.getItem(key);
    if (!value || value === '')
      return value;
    return atob(value);
  }
}
