import { Cliente } from './../../../models/cliente/cliente';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { APIResponse } from '../../../models/common/apiResponse';

@Injectable({
  providedIn: 'root'
})

export class ClienteService {

  constructor(@Inject('BASE_URL') private url: string, private httpClient: HttpClient) { }

  createCliente(cliente: Cliente): Observable<APIResponse<boolean>> {
    return this.httpClient.post<APIResponse<boolean>>(this.url + 'Cliente/Create', cliente)
  }
}
