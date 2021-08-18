﻿using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Infra.Comum.Helpers;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Restaurante.Infra.Usuarios.Validators
{
    internal class ClientValidator : IClienteValidator
    {
        public Resposta Validar(Cliente entidade)
        {
            var erros = new List<string>();
            var emailValido = ValidarEmail(entidade.Email, erros);
            var senhaValida = ValidarSenha(entidade.Senha, erros);
            if (emailValido && senhaValida)
                return new Resposta();
            return new Resposta(false, erros);
        }

        public bool ValidarEmail(string email, IList<string> erros)
        {
            var regex = new Regex(RegexHelpers.REGEX_EMAIL);
            if (!regex.Match(email).Success)
                erros.Add("E-mail Inválido!");
            return regex.Match(email).Success;
        }

        public bool ValidarSenha(string senha, IList<string> erros)
        {
            var regex = new Regex(RegexHelpers.REGEX_STRONG_PASSWORD);
            if (!regex.Match(senha).Success)
                erros.Add("Senha Inválida!");
            return regex.Match(senha).Success;
        }
    }
}
