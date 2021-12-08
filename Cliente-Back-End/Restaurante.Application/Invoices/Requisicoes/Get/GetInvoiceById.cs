using MediatR;
using Restaurante.Clientes.Domain.Invoices.Interfaces;
using Restaurante.Domain.Pedidos.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Application.Invoices.Requisicoes.Get
{
    public class GetInvoiceByIdRequest : IRequest<Invoice>
    {
        public int Id { get; set; }
        internal class GetInvoiceByIdRequestRequestHandler : IRequestHandler<GetInvoiceByIdRequest, Invoice>
        {
            private readonly IInvoiceDomainRepository _invoiceRepository;

            public GetInvoiceByIdRequestRequestHandler(IInvoiceDomainRepository invoiceRepository)
            {
                _invoiceRepository = invoiceRepository;
            }

            public async Task<Invoice> Handle(GetInvoiceByIdRequest request, CancellationToken cancellationToken)
            {
                return await _invoiceRepository.GetById(request.Id, cancellationToken);
            }
        }
    }
}
