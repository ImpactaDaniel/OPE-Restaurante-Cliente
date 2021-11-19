using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Criar;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.API.Controllers
{
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CriarClienteRequisicao request, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
