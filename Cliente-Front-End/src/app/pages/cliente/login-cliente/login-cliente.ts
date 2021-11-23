import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AlertService } from 'src/app/services/alert.service';
import { TokenService } from 'src/app/services/token.service';
import { LoginModel } from 'src/app/models/common/login';

@Component({
  selector: 'app-login-cliente',
  templateUrl: './login-cliente.html',
  styleUrls: ['./login-cliente.css']
})

export class LoginClienteComponent {
  form: FormGroup;

  constructor(private formbuilder: FormBuilder,
    private tokenservice: TokenService,
    private router: Router,
    private alertService: AlertService) { }

  ngOnInit(): void {
    this.form = this.formbuilder.group({
      email: [""],
      senha: [""]
    })
  }

  getInfoLogin(): LoginModel {
    let login = new LoginModel();
    login.email = this.form.get('email').value;
    login.senha = this.form.get('senha').value;
    return login;
  }

  toClienteCreate(): void {
    this.router.navigate(['cliente/create'])
  }

  authentication() {
    let login = this.getInfoLogin();
    this.tokenservice.authenticate(login).then((response) => {
      if (!response.sucesso) {
        var message = '';
        if (response.erros)
        response.erros.map(not => {
          message += not;
        });
        this.alertService.showError(null, message);
        return;
      }
      this.router.navigate(['/']);
    }).catch(e => {
      var message = '';
      message += e.message;
      this.alertService.showError(null, message);
    });
  }
}
