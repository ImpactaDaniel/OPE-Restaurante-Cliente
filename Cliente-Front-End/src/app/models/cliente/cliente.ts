import { Model } from "../common/model";

export class Cliente extends Model {
  nome: string;
  email: string;
  cpf: string;
  dataNascimento: string;
  telefone: Telefone;
  endereco: Endereco;
  senha: string;
}

export class Telefone extends Model {
  ddd: string;
  telefone: string;
}

export class Endereco extends Model {
  cep: string;
  estado: string;
  cidade: string;
  bairro: string;
  logradouro: string;
  numero: string;
  complemento: string;
}
