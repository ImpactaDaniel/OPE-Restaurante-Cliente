using MediatR;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Comum;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Repositorios;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Application.Usuarios.Clientes.Requsicoes.Buscar
{
    public class BuscarClientePorIdRequisicao : RequisicaoCliente<BuscarClientePorIdRequisicao>, IRequest<BuscarClienteResposta>
    {
        public BuscarClientePorIdRequisicao()
        {
        }

        internal class BuscarClientePorIdRequisicaoHandler : IRequestHandler<BuscarClientePorIdRequisicao, BuscarClienteResposta>
        {
            private readonly IClienteDomainRepositorio _clienteRepositorio;
            public BuscarClientePorIdRequisicaoHandler(IClienteDomainRepositorio clienteRepositorio)
            {
                _clienteRepositorio = clienteRepositorio;
            }
            public async Task<BuscarClienteResposta> Handle(BuscarClientePorIdRequisicao request, CancellationToken cancellationToken)
            {
                var respostaCliente = await _clienteRepositorio.Buscar(request.Id, cancellationToken);
                // cliente.Password = string.Empty;
                if (!respostaCliente.Sucesso)
                    throw new InvalidOperationException(respostaCliente.Erros?.First());

                return new BuscarClienteResposta(respostaCliente.Resposta);
            }
        }
    }
}
