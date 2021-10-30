import { Model } from "../common/model";

export class Cliente extends Model {
  name: string;
  lastName: string;
  statusDescription: string;
  status: Boolean;
  username: string;
  email: string;
  phones: Phone[] = [];
  addresses: Address[] = [];
  password: string;
  current_password: string;
  new_password: string;
}

export class Phone extends Model {
  phoneNumber: string;
}

export class Address extends Model {
  cep: string;
  state: string;
  city: string;
  neighbourhood: string;
  public_place: string;
  number: string;
  complement: string;
}
