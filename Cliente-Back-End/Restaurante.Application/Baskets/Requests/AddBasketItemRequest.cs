using MediatR;
using Restaurante.Clientes.Domain.Baskets.Repositories.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Application.Baskets.Requests
{
    public class AddBasketItemRequest : IRequest<string>
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Obs { get; set; }

        internal class AddBasketItemRequestHandler : IRequestHandler<AddBasketItemRequest, string>
        {
            private readonly IBasketRepository _basketRepository;

            public AddBasketItemRequestHandler(IBasketRepository basketRepository)
            {
                _basketRepository = basketRepository;
            }

            public async Task<string> Handle(AddBasketItemRequest request, CancellationToken cancellationToken)
            {
                try
                {
                    await _basketRepository.AddOrUpdateItem(request.CustomerId, new Domain.Baskets.Models.BasketItem
                    {
                        Obs = request.Obs,
                        ProductId = request.ProductId,
                        Quantity = request.Quantity
                    }, cancellationToken);

                    return "Item Adicionado com sucesso!";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }
    }
}
