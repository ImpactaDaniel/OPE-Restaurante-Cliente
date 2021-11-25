import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { APIResponse } from '../../../models/common/apiResponse';

@Injectable({
  providedIn: 'root'
})

export class RestauranteService {

  constructor(@Inject('BASE_URL') private url: string, private httpClient: HttpClient) { }

  getAllProducts() {
    return this.httpClient.get<APIResponse<any>>(this.url + 'Produtos/GetAllProducts')
  }
}
