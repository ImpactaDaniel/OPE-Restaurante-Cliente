import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConsultaCepService {
  private urlViaCep = "https://viacep.com.br/ws";

  constructor(private httpClient: HttpClient) { }

  public consultaCep(cep: string): Observable<ViaCepResponse> {
    return this.httpClient.get<ViaCepResponse>(`${this.urlViaCep}/${cep}/json`);
  }
}

export class ViaCepResponse {
  logradouro: string;
  bairro: string;
  localidade: string;
  uf: string;
}
