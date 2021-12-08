using AutoMapper;
using Restaurante.Clientes.Domain.Baskets.Models;
using Restaurante.Clientes.Domain.Baskets.Repositories.Interfaces;
using Restaurante.Clientes.Integracoes.Config;
using Restaurante.Integrations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Infra.Baskets.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly RestauranteService _restauranteService;
        private readonly IMapper _mapper;

        private readonly IntegrationSettings _settings;

        public BasketRepository(RestauranteService restauranteService, IMapper mapper, IntegrationSettings settings)
        {
            _restauranteService = restauranteService;
            _mapper = mapper;
            _settings = settings;
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
            try
            {
                var response = await _restauranteService.GetActiveBasketAsync(customerId, cancellationToken);

                if (!response.Success)
                    throw new Exception("Houve um erro ao tentar retornar a cesta!");

                if (response.Result is null)
                    return null;

                GetPhoto(response.Result.Items);

                return _mapper.Map<Domain.Baskets.Models.Basket>(response.Result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void GetPhoto(IEnumerable<Integrations.BasketItem> basketItems)
        {
            foreach (var item in basketItems)
                item.Product.Photo.Path = _settings.UrlRestauranteService + "/Products/" + item.Product.Photo.Path;
        }

        public async Task RemoveItem(int customerId, int productId, CancellationToken cancellationToken = default)
        {
            var response = await _restauranteService.RemoveBasketItemAsync(customerId, productId, cancellationToken);

            if (!response.Success)
                throw new Exception(response.Result);
        }
    }
}
