using MediatR;
using Restaurante.Clientes.Application.Produtos.Comum;
using Restaurante.Clientes.Domain.Comum.Modelos;
using Restaurante.Clientes.Domain.Produtos.Interfaces;
using Restaurante.Clientes.Domain.Produtos.Modelos;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Application.Produtos.Requisicoes.Get
{
    public class GetAllProductsRequest : RequisicaoProduto, IRequest<PaginationInfo<Produto>>
    {
        internal class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, PaginationInfo<Produto>>
        {
            private readonly IProdutoDomainRepository _produtoDomainRepository;

            public GetAllProductsRequestHandler(IProdutoDomainRepository produtoDomainRepository)
            {
                _produtoDomainRepository = produtoDomainRepository;
            }

            public async Task<PaginationInfo<Produto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
            {
                return await _produtoDomainRepository.GetProducts(request.Size, request.Page, cancellationToken);
            }
        }
    }
}
