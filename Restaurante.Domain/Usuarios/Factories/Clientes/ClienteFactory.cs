using Restaurante.Domain.Usuarios.Modelos;
using System;

namespace Restaurante.Domain.Usuarios.Factories.Clientes
{
    internal class ClienteFactory : IClienteFactory
    {
        private Telefone _telefone = default;
        private Endereco _endereco = default;
        private string _nome = default;

        private bool _telefoneTemValor = false;
        private bool _enderecoTemValor = false;
        private bool _nomeTemValor = false;
        public Cliente Build()
        {
            if (!_telefoneTemValor || !_nomeTemValor || !_enderecoTemValor)
                throw new ArgumentException("Nome, telefone e endereço precisam ter valor!");
            return
                new Cliente(_nome, _telefone, _endereco);
        }

        public IClienteFactory ComEndereco(Endereco endereco)
        {
            _endereco = endereco ?? throw new ArgumentException("Endereço é obrigatório!");
            _enderecoTemValor = true;
            return this;
        }

        public IClienteFactory ComNome(string nome)
        {
            _nome = nome;
            _nomeTemValor = !string.IsNullOrEmpty(_nome);
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
