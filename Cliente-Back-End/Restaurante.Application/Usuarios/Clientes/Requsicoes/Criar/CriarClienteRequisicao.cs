using MediatR;
using Restaurante.Application.Comum;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Comum;
using Restaurante.Domain.Usuarios.Factories.Clientes.Interfaces;
using Restaurante.Domain.Usuarios.Modelos;
using Restaurante.Domain.Usuarios.Repositorios.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Application.Usuarios.Clientes.Requsicoes.Criar
{
    public class CriarClienteRequisicao : RequisicaoCliente<CriarClienteRequisicao>, IRequest<RespostaRequisicao<bool>>
    {
        public CriarClienteRequisicao()
        {
        }

        internal class CriarClienteRequisicaoHandler : IRequestHandler<CriarClienteRequisicao, RespostaRequisicao<bool>>
        {
            private readonly IClienteFactory _clienteFactory;
            private readonly IClienteDomainRepositorio _clienteRepositorio;
            public CriarClienteRequisicaoHandler(IClienteFactory clienteFactory, IClienteDomainRepositorio clienteRepositorio)
            {
                _clienteFactory = clienteFactory;
                _clienteRepositorio = clienteRepositorio;
            }
            public async Task<RespostaRequisicao<bool>> Handle(CriarClienteRequisicao request, CancellationToken cancellationToken)
            {
                var cliente = _clienteFactory
                    .ComEndereco(new Endereco(request.Endereco.CEP, request.Endereco.Logradouro, request.Endereco.Bairro, request.Endereco.Numero, request.Endereco.Complemento) { Cidade = request.Endereco.Cidade, Estado = request.Endereco.Estado })
                    .ComNome(request.Nome)
                    .ComTelefone(request.Telefone.DDD, request.Telefone.Telefone)
                    .ComEmail(request.Email)
                    .ComSenha(request.Senha)
                    .Build();
                cliente.CPF = request.CPF;
                cliente.DataNascimento = request.DataNascimento;
                var resposta = await _clienteRepositorio.Salvar(cliente, cancellationToken);
                if (!resposta.Sucesso)
                    return new RespostaRequisicao<bool>(resposta);
                return new RespostaRequisicao<bool>(resposta, resposta.Sucesso);
            }
        }
    }
}
