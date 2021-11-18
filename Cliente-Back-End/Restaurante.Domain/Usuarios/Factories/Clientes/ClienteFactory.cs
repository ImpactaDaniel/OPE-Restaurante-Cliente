using Restaurante.Domain.Usuarios.Factories.Clientes.Interfaces;
using Restaurante.Domain.Usuarios.Modelos;
using System;

namespace Restaurante.Domain.Usuarios.Factories.Clientes
{
    internal class ClienteFactory : IClienteFactory
    {
        private Telefone _telefone = default;
        private Endereco _endereco = default;
        private string _nome = default;
        private string _senha = default;
        private string _email = default;

        private bool _telefoneTemValor = false;
        private bool _enderecoTemValor = false;
        private bool _nomeTemValor = false;
        private bool _senhaTemValor = false;
        private bool _emailTemValor = false;
        public Cliente Build()
        {
            if (!_telefoneTemValor || !_nomeTemValor || !_enderecoTemValor || !_senhaTemValor || !_emailTemValor)
                throw new ArgumentException("Nome, e-mail, senha, telefone e endereço precisam ter valor!");
            return
                new Cliente(_nome, _email, _senha, _telefone, _endereco);
        }

        public IClienteFactory ComEmail(string email)
        {
            _email = string.IsNullOrEmpty(email) ? throw new ArgumentException("E-mail é obrigatório!") : email;
            _emailTemValor = !string.IsNullOrEmpty(email);
            return this;
        }

        public IClienteFactory ComEndereco(Endereco endereco)
        {
            _endereco = endereco ?? throw new ArgumentException("Endereço é obrigatório!");
            _enderecoTemValor = true;
            return this;
        }

        public IClienteFactory ComNome(string nome)
        {
            _nome = string.IsNullOrEmpty(nome) ? throw new ArgumentException("Nome é obrigatório!") : nome;
            _nomeTemValor = !string.IsNullOrEmpty(_nome);
            return this;
        }

        public IClienteFactory ComSenha(string senha)
        {
            _senha = string.IsNullOrEmpty(senha) ? throw new ArgumentException("Senha é obrigatório!") : senha;
            _senhaTemValor = !string.IsNullOrEmpty(_nome);
            return this;
        }

        public IClienteFactory ComTelefone(string ddd, string numero)
        {
            _telefone = new Telefone(ddd, numero);
            _telefoneTemValor = true;
            return this;
        }

        public IClienteFactory ComTelefone(Telefone telefone)
        {
            _telefone = telefone ?? throw new ArgumentException("Telefone é obrigatório!");
            _telefoneTemValor = true;
            return this;
        }
    }
}
