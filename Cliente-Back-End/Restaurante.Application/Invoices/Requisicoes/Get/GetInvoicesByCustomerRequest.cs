using MediatR;
using Restaurante.Clientes.Domain.Invoices.Interfaces;
using Restaurante.Domain.Pedidos.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Application.Invoices.Requisicoes.Get
{
    public class GetInvoicesByCustomerRequest : IRequest<IEnumerable<Invoice>>
    {
        public int CustomerId { get; set; }
        internal class GetInvoicesByCustomerRequestHandler : IRequestHandler<GetInvoicesByCustomerRequest, IEnumerable<Invoice>>
        {
            private readonly IInvoiceDomainRepository _invoiceRepository;

            public GetInvoicesByCustomerRequestHandler(IInvoiceDomainRepository invoiceRepository)
            {
                _invoiceRepository = invoiceRepository;
            }

            public async Task<IEnumerable<Invoice>> Handle(GetInvoicesByCustomerRequest request, CancellationToken cancellationToken)
            {
                return await _invoiceRepository.GetByCustomer(request.CustomerId, cancellationToken);
            }
        }
    }
}
