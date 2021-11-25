using AutoMapper;
using Restaurante.Clientes.Domain.Comum.Modelos;
using Restaurante.Clientes.Domain.Produtos.Interfaces;
using Restaurante.Clientes.Domain.Produtos.Modelos;
using Restaurante.Clientes.Integracoes.Config;
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
        private readonly IntegrationSettings _settings;

        public ProdutoRepository(RestauranteService restauranteService, IMapper mapper, IntegrationSettings settings)
        {
            _restauranteService = restauranteService;
            _mapper = mapper;
            _settings = settings;
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

        public async Task<IEnumerable<Domain.Produtos.Modelos.ProductCategory>> GetProductsGroupByCategories(CancellationToken cancellationToken = default)
        {
            var categories = await _restauranteService
                .GetGroupByCategoriesAsync(cancellationToken);

            foreach (var category in categories.Result)
                GetPhoto(category.Products);

            return _mapper.Map<IEnumerable<Domain.Produtos.Modelos.ProductCategory>>(categories.Result);
        }

        private void GetPhoto(IEnumerable<ProductResponseDTO> productResponseDTOs)
        {
            foreach (var productResponse in productResponseDTOs)
                productResponse.Photo.PhotoPath = _settings.UrlRestauranteService + "/" + productResponse.Photo.PhotoPath;
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
