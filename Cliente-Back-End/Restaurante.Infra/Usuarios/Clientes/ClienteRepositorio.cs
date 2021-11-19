using Restaurante.Clientes.Infra.Usuarios.Encoder.Interfaces;
using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Repositorios.Interfaces;
using Restaurante.Integrations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Infra.Usuarios.Clientes
{
    public class ClienteRepositorio :
        IClienteDomainRepositorio
    {
        private readonly IClienteValidator _clienteValidator;
        private readonly IPasswordEncoder _encoder;
        private readonly RestauranteService _restauranteService;
        public ClienteRepositorio(IClienteValidator clienteValidator, IPasswordEncoder encoder, RestauranteService restauranteService)
        {
            _encoder = encoder;
            _clienteValidator = clienteValidator;
            _restauranteService = restauranteService;
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

        public async Task<RespostaConsulta<Cliente>> Salvar(Cliente entidade, CancellationToken cancellationToken = default)
        {
            var response = await _restauranteService.CreateCustomerAsync(new CreateCustomerRequest
            {
                Address = new AddressRequest
                {
                    Cep = entidade.Endereco.CEP,
                    City = entidade.Endereco.Cidade,
                    State = entidade.Endereco.Estado,
                    District = entidade.Endereco.Bairro,
                    Number = entidade.Endereco.Numero,
                    Street = entidade.Endereco.Logradouro
                },
                BirthDate = entidade.DataNascimento,
                Document = entidade.CPF,
                Email = entidade.Email,
                Name = entidade.Nome,
                Password = entidade.Senha,
                Phones = new List<PhoneRequest>
                {
                    new PhoneRequest
                    {
                        Ddd = entidade.Telefone.DDD,
                        PhoneNumber = entidade.Telefone.Numero
                    }
                }
            }, cancellationToken);

            return new RespostaConsulta<Cliente>(entidade);

        }
    }
}
