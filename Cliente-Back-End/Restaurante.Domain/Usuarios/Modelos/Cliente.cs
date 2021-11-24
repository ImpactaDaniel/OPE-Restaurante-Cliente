using Restaurante.Domain.Comum.Modelos;
using System;
using System.Collections.Generic;

namespace Restaurante.Domain.Usuarios.Modelos
{
    public class Cliente : Entidade<int>
    {
        public string Nome { get; private set; }
        public Telefone Telefone { get; set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public IList<Endereco> Enderecos { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nome, string email, string senha, Telefone telefone)
        {
            ValidarStringNullOrEmpty(nome, "Nome");
            ValidarStringNullOrEmpty(email, "E-mail");
            ValidarStringNullOrEmpty(senha, "Senha");
            Email = email;
            Senha = senha;
            Nome = nome;
            Telefone = telefone;
        }

        public Cliente(int id, string nome, string email, string senha, Telefone telefone)
            : base(id)
        {
            ValidarStringNullOrEmpty(nome, "Nome");
            ValidarStringNullOrEmpty(email, "E-mail");
            ValidarStringNullOrEmpty(senha, "Senha");
            Email = email;
            Senha = senha;
            Nome = nome;
            Telefone = telefone;
        }

        public Cliente AtualizarNome(string nome)
        {
            ValidarStringNullOrEmpty(nome, "Nome");
            if (Nome != nome)
                Nome = nome;
            return this;
        }

        public Cliente AtualizarTelefone(Telefone telefone)
        {
            Telefone = telefone;
            return this;
        }

        public Cliente AtualizarTelefone(string ddd, string numero)
        {
            Telefone = new Telefone(ddd, numero);
            return this;
        }
        public Cliente AtualizarSenha(string senha)
        {
            ValidarStringNullOrEmpty(senha, "Senha");
            if (Senha != senha)
                Senha = senha;
            return this;
        }

        public Cliente AtualizarEmail(string email)
        {
            ValidarStringNullOrEmpty(email, "Email");
            if (Email!= email)
                Email = email;
            return this;
        }
    }
}
