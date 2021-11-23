using AutoMapper;
using Restaurante.Clientes.Domain.Comum.Modelos;
using Restaurante.Clientes.Domain.Produtos.Interfaces;
using Restaurante.Clientes.Domain.Produtos.Modelos;
using Restaurante.Integrations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Infra.Produtos.Repositories
{
    public class ProdutoRepository : IProdutoDomainRepository
    {
        private readonly RestauranteService _restauranteService;
        private readonly IMapper _mapper;

        public ProdutoRepository(RestauranteService restauranteService, IMapper mapper)
        {
            _restauranteService = restauranteService;
            _mapper = mapper;
        }

        public async Task<PaginationInfo<Produto>> GetProducts(int size, int page, CancellationToken cancellationToken = default)
        {
            var paginationInfo = await _restauranteService
                .GetAll5Async(page, size, cancellationToken);

            if (!paginationInfo.Success)
                return null;

            var products = _mapper.Map<IEnumerable<Produto>>(paginationInfo.Result.Entities);

            return new PaginationInfo<Produto>
            {
                Entities = products,
                Size = paginationInfo.Result.Size
            };
        }

        public async Task<PaginationInfo<Produto>> SearchProducts(int size, int page, string field, string value, CancellationToken cancellationToken = default)
        {
            var paginationInfo = await _restauranteService
                .Search5Async(field, value, page, size, cancellationToken);

            if (!paginationInfo.Success)
                return null;

            var products = _mapper.Map<IEnumerable<Produto>>(paginationInfo.Result.Entities);

            return new PaginationInfo<Produto>
            {
                Entities = products,
                Size = paginationInfo.Result.Size
            };
        }
    }
}
