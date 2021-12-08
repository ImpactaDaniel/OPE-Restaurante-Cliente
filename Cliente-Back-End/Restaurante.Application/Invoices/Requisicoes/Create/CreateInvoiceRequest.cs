using MediatR;
using Restaurante.Clientes.Domain.Invoices.Interfaces;
using Restaurante.Domain.Pedidos.Models;
using Restaurante.Domain.Pedidos.Models.Enum;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Application.Invoices.Requisicoes.Create
{
    public class CreateInvoiceRequest : IRequest<Invoice>
    {
        public int BasketId { get; set; }
        public int CustomerId { get; set; }
        public int CustomerAddress { get; set; }
        public PaymentType PaymentType { get; set; }

        internal class CreateInvoiceRequestHandler : IRequestHandler<CreateInvoiceRequest, Invoice>
        {
            private readonly IInvoiceDomainRepository _invoiceRepository;

            public CreateInvoiceRequestHandler(IInvoiceDomainRepository invoiceRepository)
            {
                _invoiceRepository = invoiceRepository;
            }

            public async Task<Invoice> Handle(CreateInvoiceRequest request, CancellationToken cancellationToken)
            {
                return await _invoiceRepository.CreateInvoice(request.BasketId, request.CustomerId, request.CustomerAddress, request.PaymentType, cancellationToken);
            }
        }
    }
}
