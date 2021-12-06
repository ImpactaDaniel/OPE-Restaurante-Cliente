using MediatR;
using Restaurante.Clientes.Domain.Baskets.Models;
using Restaurante.Clientes.Domain.Baskets.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Application.Baskets.Requests
{
    public class GetActiveBasketRequest : IRequest<Basket>
    {
        public int CustomerId { get; set; }

        internal class GetActiveBasketRequestHandler : IRequestHandler<GetActiveBasketRequest, Basket>
        {
            private readonly IBasketRepository _basketRepository;

            public GetActiveBasketRequestHandler(IBasketRepository basketRepository)
            {
                _basketRepository = basketRepository;
            }

            public async Task<Basket> Handle(GetActiveBasketRequest request, CancellationToken cancellationToken)
            {
                return await _basketRepository.GetActiveBasket(request.CustomerId, cancellationToken);
            }
        }
    }
}
