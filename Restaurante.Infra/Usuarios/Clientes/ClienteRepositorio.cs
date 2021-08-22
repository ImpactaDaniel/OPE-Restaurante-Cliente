using Microsoft.EntityFrameworkCore;
using Restaurante.Clientes.Infra.Usuarios.Encoder;
using Restaurante.Domain.Comum.Modelos;
using Restaurante.Domain.Comum.Modelos.Intefaces;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Repositorios;
using Restaurante.Infra.Comum.Persistencia;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Infra.Usuarios.Clientes
{
    public class ClienteRepositorio :
        RepositorioDados<IRestauranteDbContext, Cliente>,
        IClienteDomainRepositorio
    {
        private readonly IClienteValidator _clienteValidator;
        private readonly IPasswordEncoder _encoder;
        public ClienteRepositorio(IRestauranteDbContext dbContext, IClienteValidator clienteValidator, IPasswordEncoder encoder) : base(dbContext)
        {
            _encoder = encoder;
            _clienteValidator = clienteValidator;
        }

        public override async Task<RespostaConsulta<Cliente>> Salvar(Cliente entidade, CancellationToken cancellationToken = default)
        { 
            var respostaValidator = _clienteValidator.Validar(entidade);
            if (!respostaValidator.Sucesso)
                return new RespostaConsulta<Cliente>(respostaValidator.Erros);

            entidade.AtualizarSenha(_encoder.Encode(entidade.Senha));
            return await base.Salvar(entidade, cancellationToken);
        }

        public async Task<RespostaConsulta<Cliente>> Buscar(int id, CancellationToken cancellationToken = default)
        {
            var cliente = await 
                All()
                .Include(c => c.Endereco)
                .Include(c => c.Telefone)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente is null)
                return RetornaErro<Cliente>("Cliente não encontrado!");
            return new RespostaConsulta<Cliente>(cliente);
        }

        public async Task<RespostaConsulta<Endereco>> BuscarEndereco(int id, CancellationToken cancellationToken = default)
        {
            var endereco = await Data
                .Enderecos
                .FirstOrDefaultAsync(e => e.Id == id);

            if(endereco is null)
                return RetornaErro<Endereco>("Endereço não encontrado!");

            return new RespostaConsulta<Endereco>(endereco);
        }
        public async Task<RespostaConsulta<Telefone>> BuscarTelefone(int id, CancellationToken cancellationToken = default)
        {
            var erros = new List<string>(1);

            var telefone = await
                Data
                .Telefones
                .FirstOrDefaultAsync(t => t.Id == id);

            if (telefone is null)
                return RetornaErro<Telefone>("Telefone não encontrado!");
            return new RespostaConsulta<Telefone>(telefone);
        }

        public async Task<bool> Deletar(int id, CancellationToken cancellationToken = default)
        {
            var cliente = await Data.Clientes.FindAsync(id);

            if (cliente is null)
                return false;

            Data.Clientes.Remove(cliente);

            await Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<RespostaConsulta<Cliente>> Logar(string email, string password, CancellationToken cancellationToken = default)
        {
            var cliente = await Data.Clientes.FirstAsync(t => t.Email == email);

            if (cliente != null)
            {
                if (_encoder.VerficarSenha(cliente.Senha, password))
                    return RetornaErro<Cliente>("Cliente email e senha incorretos.");

                return new RespostaConsulta<Cliente>(cliente);
            } else
            {
                return RetornaErro<Cliente>("Cliente não encontrado.");
            }      
        }
    }
}
