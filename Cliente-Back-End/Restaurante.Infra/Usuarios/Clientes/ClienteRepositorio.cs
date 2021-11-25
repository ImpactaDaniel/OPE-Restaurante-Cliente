using Newtonsoft.Json;
using Restaurante.Clientes.Infra.Usuarios.Encoder.Interfaces;
using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Repositorios.Interfaces;
using Restaurante.Integrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Infra.Usuarios.Clientes
{
    public class ClienteRepositorio :
        IClienteDomainRepositorio
    {
        private readonly IClienteValidator _clienteValidator;
        private readonly RestauranteService _restauranteService;
        public ClienteRepositorio(IClienteValidator clienteValidator, RestauranteService restauranteService)
        {
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

        public async Task<RespostaConsulta<Cliente>> Logar(string email, string password, CancellationToken cancellationToken = default)
        {
            var erros = new List<string>
            {
                "E-mail ou senha inválidos!"
            };

            try
            {
                var valid = _clienteValidator.ValidarEmail(email, erros) && _clienteValidator.ValidarSenha(password, erros);

                if (!valid)
                    return new RespostaConsulta<Cliente>(erros);

                var response = await _restauranteService.LoginCustomerAsync(new GetUserAuthenticateRequest
                {
                    Email = email,
                    Password = password
                }, cancellationToken);

                if (!response.Success)
                    return new RespostaConsulta<Cliente>(erros);

                var enderecos = GetAddresses(response.Result.Addresses);

                return new RespostaConsulta<Cliente>(new Cliente(response.Result.Id, response.Result.Name, response.Result.Email, response.Result.Password, new Telefone(response.Result.Phone.Ddd, response.Result.Phone.PhoneNumber))
                {
                    Enderecos = enderecos.ToList()
                });
            }
            catch (ApiException)
            {
                return new RespostaConsulta<Cliente>(erros);
            }
        }

        private static IEnumerable<Endereco> GetAddresses(IEnumerable<CustomerAddress> customerAddress)
        {
            foreach (var address in customerAddress)
                yield return new Endereco(address.Cep, address.Street, address.District, address.Number, String.Empty);
        }

        public async Task<RespostaConsulta<Cliente>> Salvar(Cliente entidade, CancellationToken cancellationToken = default)
        {
            var validation = _clienteValidator.Validar(entidade);
            if (!validation.Sucesso)
                return new RespostaConsulta<Cliente>(validation.Erros);

            var response = await _restauranteService.CreateCustomerAsync(new CreateCustomerRequest
            {
                Address = new AddressRequest
                {
                    Cep = entidade.Enderecos.First().CEP,
                    City = entidade.Enderecos.First().Cidade,
                    State = entidade.Enderecos.First().Estado,
                    District = entidade.Enderecos.First().Bairro,
                    Number = entidade.Enderecos.First().Numero,
                    Street = entidade.Enderecos.First().Logradouro
                },
                BirthDate = entidade.DataNascimento,
                Document = entidade.CPF,
                Email = entidade.Email,
                Name = entidade.Nome,
                Password = entidade.Senha,
                Phone = new PhoneRequest
                {
                    Ddd = entidade.Telefone.DDD,
                    PhoneNumber = entidade.Telefone.Numero
                }
            }, cancellationToken);

            if (!response.Success)
                return new RespostaConsulta<Cliente>(new List<string> { response.Result });

            return new RespostaConsulta<Cliente>(entidade);
        }
    }
}
