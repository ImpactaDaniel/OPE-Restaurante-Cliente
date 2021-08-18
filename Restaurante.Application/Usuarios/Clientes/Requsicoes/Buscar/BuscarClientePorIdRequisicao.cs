using MediatR;
using Restaurante.Application.Comum;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Comum;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Repositorios;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Application.Usuarios.Clientes.Requsicoes.Buscar
{
    public class BuscarClientePorIdRequisicao : RequisicaoCliente<BuscarClientePorIdRequisicao>, IRequest<RespostaRequisicao<Cliente>>
    {
        public BuscarClientePorIdRequisicao()
        {
        }

        internal class BuscarClientePorIdRequisicaoHandler : IRequestHandler<BuscarClientePorIdRequisicao, RespostaRequisicao<Cliente>>
        {
            private readonly IClienteDomainRepositorio _clienteRepositorio;
            public BuscarClientePorIdRequisicaoHandler(IClienteDomainRepositorio clienteRepositorio)
            {
                _clienteRepositorio = clienteRepositorio;
            }
            public async Task<RespostaRequisicao<Cliente>> Handle(BuscarClientePorIdRequisicao request, CancellationToken cancellationToken)
            {
                var respostaCliente = await _clienteRepositorio.Buscar(request.Id, cancellationToken);
                // cliente.Password = string.Empty;

                return new RespostaRequisicao<Cliente>(respostaCliente, respostaCliente.Resposta);
            }
        }
    }
}
