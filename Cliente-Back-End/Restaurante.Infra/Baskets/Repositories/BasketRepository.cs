using AutoMapper;
using Restaurante.Clientes.Domain.Baskets.Models;
using Restaurante.Clientes.Domain.Baskets.Repositories.Interfaces;
using Restaurante.Integrations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Infra.Baskets.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly RestauranteService _restauranteService;
        private readonly IMapper _mapper;

        public BasketRepository(RestauranteService restauranteService, IMapper mapper)
        {
            _restauranteService = restauranteService;
            _mapper = mapper;
        }

        public async Task AddOrUpdateItem(int customerId, Domain.Baskets.Models.BasketItem item, CancellationToken cancellationToken = default)
        {
            var response = await _restauranteService.AddBasketItemAsync(customerId, new AddBasketItemRequest
            {
                CustomerId = customerId,
                ProductId = item.ProductId,
                Obs = item.Obs,
                Quantity = item.Quantity
            }, cancellationToken);

            if (!response.Success)
                throw new Exception(response.Result);
        }

        public async Task<Domain.Baskets.Models.Basket> GetActiveBasket(int customerId, CancellationToken cancellationToken = default)
        {
            var response = await _restauranteService.GetActiveBasketAsync(customerId, cancellationToken);

            if (!response.Success)
                throw new Exception("Houve um erro ao tentar retornar a cesta!");

            return _mapper.Map<Domain.Baskets.Models.Basket>(response.Result);
        }
        public async Task RemoveItem(int customerId, int productId, CancellationToken cancellationToken = default)
        {
            var response = await _restauranteService.RemoveBasketItemAsync(customerId, productId, cancellationToken);

            if (!response.Success)
                throw new Exception(response.Result);
        }
    }
}
