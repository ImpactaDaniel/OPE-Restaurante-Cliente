using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Buscar;
using Restaurante.Application.Usuarios.Clientes.Requsicoes.Criar;
using Restaurante.Clientes.Application.Usuarios.Clientes.Requsicoes.Autenticar;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.API.Controllers
{
    [ApiController, Route("[controller]")]
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

        [HttpPost("LoginCustomer")]
        public async Task<IActionResult> LoginCustomer([FromBody] AutenticarClienteRequisicao request, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("GetCurrentCustomer"), Authorize]
        public async Task<IActionResult> GetCurrentCustomer(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new BuscarClientePorIdRequisicao { Id = GetLoggedUserId() }, cancellationToken));
        }

        private int GetLoggedUserId()
        {
            var userId = User.Claims.First(c => c.Type == "id").Value;
            return int.Parse(userId);
        }
    }
}
