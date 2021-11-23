using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Clientes.Application.Produtos.Requisicoes.Get;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.API.Controllers
{
    [ApiController, Route("[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IMediator _mediator;

        public ProdutosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetAllProductsRequest(), cancellationToken));
        }
    }
}
