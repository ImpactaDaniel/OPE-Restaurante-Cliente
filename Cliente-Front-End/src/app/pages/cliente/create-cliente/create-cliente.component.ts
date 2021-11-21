import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AlertService } from "src/app/services/alert.service";
import { ConsultaCepService } from "src/app/services/consulta-cep.service";
import { Cliente } from "../../../models/cliente/cliente";
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
    let cep = this.form.get("endereco").get("cep");
    if (cep.invalid) return;
    var endereco = await this.consultaCepService
      .consultaCep(cep.value)
      .toPromise();
    this.form.get("endereco").get("logradouro").setValue(endereco.logradouro);
    this.form.get("endereco").get("estado").setValue(endereco.uf);
    this.form.get("endereco").get("cidade").setValue(endereco.localidade);
    this.form.get("endereco").get("bairro").setValue(endereco.bairro);
  }

  async cadastrarCliente() {
    if (!this.form.valid) return;
    this.cliente = this.getCliente();

    this.error = false;
    this.erroMsg = "";
    console.log(this.cliente)
    let retorno = await this.clienteService
      .createCliente(this.cliente)
      .toPromise();

    console.log(retorno)
    this.error = !retorno.sucesso;

    if (!retorno.sucesso) {
      for (let notification of retorno.erros) {
        this.erroMsg += `\n${notification}`;
      }
      return;
    }
    this.alertService.showSuccess("Sucesso", "Você foi cadastrado com sucesso!")
  }

  private getCliente(): Cliente {
    let cliente = new Cliente(this.form.value);
    if(!cliente){
      this.alertService.showError("Erro", "Houve um problema ao pegar os dados do cadastro.")
    }
    return cliente;
  }
}
