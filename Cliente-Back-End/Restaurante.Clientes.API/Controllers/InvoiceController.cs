using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Clientes.Application.Invoices.Requisicoes.Create;
using Restaurante.Clientes.Application.Invoices.Requisicoes.Get;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.API.Controllers
{
    [ApiController, Route("[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("InvoicesHistory"), Authorize]
        public async Task<IActionResult> GetInvoicesHistory(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetInvoicesByCustomerRequest { CustomerId = GetLoggedUserId() }, cancellationToken));
        }

        [HttpGet("InvoiceById/{id}"), Authorize]
        public async Task<IActionResult> GetInvoiceById(int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetInvoiceByIdRequest { Id = id }, cancellationToken));
        }

        [HttpPost("CreateInvoice"), Authorize]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceRequest request, CancellationToken cancellationToken = default)
        {
            request.CustomerId = GetLoggedUserId();
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        private int GetLoggedUserId()
        {
            var userId = User.Claims.First(c => c.Type == "id").Value;
            return int.Parse(userId);
        }
    }
}
