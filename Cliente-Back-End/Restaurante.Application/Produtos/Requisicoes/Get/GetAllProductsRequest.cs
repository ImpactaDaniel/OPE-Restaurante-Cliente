using MediatR;
using Restaurante.Clientes.Application.Produtos.Comum;
using Restaurante.Clientes.Domain.Produtos.Interfaces;
using Restaurante.Clientes.Domain.Produtos.Modelos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Application.Produtos.Requisicoes.Get
{
    public class GetAllProductsRequest : RequisicaoProduto, IRequest<IEnumerable<ProductCategory>>
    {
        internal class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, IEnumerable<ProductCategory>>
        {
            private readonly IProdutoDomainRepository _produtoDomainRepository;

            public GetAllProductsRequestHandler(IProdutoDomainRepository produtoDomainRepository)
            {
                _produtoDomainRepository = produtoDomainRepository;
            }

            public async Task<IEnumerable<ProductCategory>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
            {
                return await _produtoDomainRepository.GetProductsGroupByCategories(cancellationToken);
            }
        }
    }
}
