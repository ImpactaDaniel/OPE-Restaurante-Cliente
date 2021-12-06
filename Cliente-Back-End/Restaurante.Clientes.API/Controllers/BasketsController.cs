using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Clientes.Application.Baskets.Requests;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.API.Controllers
{
    [ApiController, Route("[controller]")]
    public class BasketsController : Controller
    {
        private readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetActiveBasket"), Authorize]
        public async Task<IActionResult> GetActiveBasket(CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(new GetActiveBasketRequest { CustomerId = GetLoggedUserId() }, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("RemoveBasketItem/{productId}"), Authorize]
        public async Task<IActionResult> RemoveBasketItem(int productId, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(new RemoveBasketItemRequest { CustomerId = GetLoggedUserId(), ProductId = productId }, cancellationToken);
            return Ok(response);
        }

        [HttpPost("AddBasketItem"), Authorize]
        public async Task<IActionResult> AddBasketItem([FromBody] AddBasketItemRequest request, CancellationToken cancellationToken = default)
        {
            request.CustomerId = GetLoggedUserId();
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }


        private int GetLoggedUserId()
        {
            var userId = User.Claims.First(c => c.Type == "id").Value;
            return int.Parse(userId);
        }
    }
}
