using Restaurante.Clientes.Infra.Usuarios.Encoder.Interfaces;
using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Repositorios.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Infra.Usuarios.Clientes
{
    public class ClienteRepositorio :
        IClienteDomainRepositorio
    {
        private readonly IClienteValidator _clienteValidator;
        private readonly IPasswordEncoder _encoder;
        public ClienteRepositorio(IClienteValidator clienteValidator, IPasswordEncoder encoder)
        {
            _encoder = encoder;
            _clienteValidator = clienteValidator;
        }

        public Task<RespostaConsulta<Cliente>> Buscar(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public RespostaConsulta<Cliente> Buscar(Func<Cliente, bool> condicao)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaConsulta<Endereco>> BuscarEndereco(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaConsulta<Telefone>> BuscarTelefone(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deletar(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaConsulta<Cliente>> Logar(string email, string password, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaConsulta<Cliente>> Salvar(Cliente entidade, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
