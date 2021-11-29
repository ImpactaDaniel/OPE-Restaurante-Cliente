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

  public createCliente(cliente: Cliente): Observable<APIResponse<boolean>> {
    return this.httpClient.post<APIResponse<boolean>>(this.url + 'Cliente/CreateCustomer', cliente)
  }

  public getInvoicesByCustomer() {
    return this.httpClient.get<APIResponse<any>>(this.url + 'Invoice/InvoicesHistory')
  }

  public getInvoiceById(id: string): any {
    return this.httpClient.get<any>(this.url + 'Invoice/InvoiceById/' + id)
  }
}
