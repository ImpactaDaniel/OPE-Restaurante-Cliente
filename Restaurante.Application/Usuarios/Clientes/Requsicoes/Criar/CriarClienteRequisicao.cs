using MediatR;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Comum;
using Restaurante.Domain.Usuarios.Factories.Clientes;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Repositorios;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Application.Usuarios.Clientes.Requsicoes.Criar
{
    public class CriarClienteRequisicao : RequisicaoCliente<CriarClienteRequisicao>, IRequest<CriarClienteResposta>
    {
        public CriarClienteRequisicao()
        {
        }
        public CriarClienteRequisicao(Cliente cliente) : base(cliente)
        {
        }
        internal class CriarClienteRequisicaoHandler : IRequestHandler<CriarClienteRequisicao, CriarClienteResposta>
        {
            private readonly IClienteFactory _clienteFactory;
            private readonly IClienteDomainRepositorio _clienteRepositorio;
            public CriarClienteRequisicaoHandler(IClienteFactory clienteFactory, IClienteDomainRepositorio clienteRepositorio)
            {
                _clienteFactory = clienteFactory;
                _clienteRepositorio = clienteRepositorio;
            }
            public async Task<CriarClienteResposta> Handle(CriarClienteRequisicao request, CancellationToken cancellationToken)
            {
                var cliente = _clienteFactory
                    .ComEndereco(request.Endereco)
                    .ComNome(request.Nome)
                    .ComTelefone(request.Telefone)
                    .Build();
                await _clienteRepositorio.Salvar(cliente, cancellationToken);
                return new CriarClienteResposta(cliente.Id);
            }
        }
    }
}
