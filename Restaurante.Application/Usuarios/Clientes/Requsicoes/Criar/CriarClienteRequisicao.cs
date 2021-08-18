using MediatR;
using Restaurante.Application.Comum;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Comum;
using Restaurante.Domain.Usuarios.Factories.Clientes;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Repositorios;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Application.Usuarios.Clientes.Requsicoes.Criar
{
    public class CriarClienteRequisicao : RequisicaoCliente<CriarClienteRequisicao>, IRequest<RespostaRequisicao<int>>
    {
        public CriarClienteRequisicao()
        {
        }
        public CriarClienteRequisicao(Cliente cliente) : base(cliente)
        {
        }
        public class CriarClienteRequisicaoHandler : IRequestHandler<CriarClienteRequisicao, RespostaRequisicao<int>>
        {
            private readonly IClienteFactory _clienteFactory;
            private readonly IClienteDomainRepositorio _clienteRepositorio;
            public CriarClienteRequisicaoHandler(IClienteFactory clienteFactory, IClienteDomainRepositorio clienteRepositorio)
            {
                _clienteFactory = clienteFactory;
                _clienteRepositorio = clienteRepositorio;
            }
            public async Task<RespostaRequisicao<int>> Handle(CriarClienteRequisicao request, CancellationToken cancellationToken)
            {
                var cliente = _clienteFactory
                    .ComEndereco(request.Endereco)
                    .ComNome(request.Nome)
                    .ComTelefone(request.Telefone)
                    .Build();
                var resposta = await _clienteRepositorio.Salvar(cliente, cancellationToken);
                return new RespostaRequisicao<int>(cliente.Id);
            }
        }
    }
}
