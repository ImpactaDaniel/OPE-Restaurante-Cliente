import { Cliente } from './../../../models/cliente/cliente';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { APIResponse } from '../../../models/common/apiResponse';

@Injectable({
  providedIn: 'root'
})

export class ClienteService {

  private urlRestaurante: string = 'https://localhost:44318/'
  constructor(@Inject('BASE_URL') private url: string, private httpClient: HttpClient) { }

  createCliente(cliente: Cliente): Observable<APIResponse<boolean>> {
    console.log(this.url)
    return this.httpClient.post<APIResponse<boolean>>(this.urlRestaurante + '/Cliente/CreateCustomer', cliente)
  }
}
