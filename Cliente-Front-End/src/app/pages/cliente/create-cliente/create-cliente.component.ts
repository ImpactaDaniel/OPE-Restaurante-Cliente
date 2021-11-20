import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { AlertService } from "src/app/services/alert.service";
import { ConsultaCepService } from "src/app/services/consulta-cep.service";
import { Cliente, Phone } from "../../../models/cliente/cliente";
import { ClienteService } from "../services/cliente.service";

@Component({
  selector: "app-create-cliente",
  templateUrl: "./create-cliente.component.html",
  styleUrls: ["./create-cliente.component.scss"],
})
export class CreateClienteComponent implements OnInit {
  error = false;
  erroMsg = "";
  cliente: Cliente;
  form: FormGroup;

  constructor(
    private formbuilder: FormBuilder,
    private clienteService: ClienteService,
    private consultaCepService: ConsultaCepService,
    private alertService: AlertService
  ) { }

  ngOnInit(): void {
    this.form = this.formbuilder.group({
      nome: ["", Validators.required],
      email: ["", [Validators.required, Validators.email]],
      senha: [
        "",
        [
          Validators.required,
          Validators.pattern(/(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])/),
        ],
      ],
      endereco: this.formbuilder.group({
        logradouro: [""],
        numero: ["", Validators.required],
        bairro: [""],
        cep: [
          "",
          [
            Validators.minLength(8),
            Validators.pattern(/[0-9]{8}/),
            Validators.required,
          ],
        ],
        cidade: [""],
        estado: [""],
        complemento: [""]
      }),
      telefone: this.formbuilder.group({
        ddd: [
          "", 
          [ Validators.required,
            Validators.pattern(/\d+/g),
            Validators.maxLength(2),
          ],
        ],
        telefone: [
          "",
          [
            Validators.required,
            Validators.pattern(/\d+/g),
            Validators.maxLength(11),
          ],
        ],
      }),
      cpf: ["", [Validators.required, Validators.pattern(/\d+/g)]],
      dataNascimento: ["", Validators.required],
    });
  }

  async consultarCep() {
    let cep = this.form.get("addresses").get("cep");
    if (cep.invalid) return;
    var endereco = await this.consultaCepService
      .consultaCep(cep.value)
      .toPromise();
    this.form.get("addresses").get("street").setValue(endereco.logradouro);
    this.form.get("addresses").get("state").setValue(endereco.uf);
    this.form.get("addresses").get("city").setValue(endereco.localidade);
    this.form.get("addresses").get("neighbourhood").setValue(endereco.bairro);
  }

  async cadastrarCliente() {
    console.log(this.form)
    if (!this.form.valid) return;
    this.cliente = this.getCliente();

    this.error = false;
    this.erroMsg = "";

    let retorno = await this.clienteService
      .createCliente(this.cliente)
      .toPromise();

    this.error = !retorno.success;

    if (!retorno.success) {
      for (let notification of retorno.notifications) {
        this.erroMsg += `\n${notification.message}`;
      }
      return;
    }

    this.alertService.showSuccess("Sucesso", "Você foi cadastrado com sucesso!")
  }

  private getCliente(): Cliente {
    let cliente = new Cliente(this.form.value);
    var phone = new Phone();
    phone.phoneNumber = this.form.get("phones").get("phoneNumber").value;
    cliente.phones.push(phone);
    return cliente;
  }
}
