using MediatR;
using Restaurante.Clientes.Domain.Baskets.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Application.Baskets.Requests
{
    public class RemoveBasketItemRequest : IRequest<string>
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        internal class RemoveBasketItemRequestHandler : IRequestHandler<RemoveBasketItemRequest, string>
        {
            private readonly IBasketRepository _basketRepository;

            public RemoveBasketItemRequestHandler(IBasketRepository basketRepository)
            {
                _basketRepository = basketRepository;
            }

            public async Task<string> Handle(RemoveBasketItemRequest request, CancellationToken cancellationToken)
            {
                await _basketRepository.RemoveItem(request.CustomerId, request.ProductId, cancellationToken);
                return "Removido com sucesso!";
            }
        }
    }
}
