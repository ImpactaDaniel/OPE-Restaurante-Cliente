using AutoMapper;
using Restaurante.Clientes.Domain.Invoices.Interfaces;
using Restaurante.Integrations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.Infra.Invoices.Repositories
{
    public class InvoiceRepository : IInvoiceDomainRepository
    {

        private readonly RestauranteService _restauranteService;
        private readonly IMapper _mapper;

        public InvoiceRepository(RestauranteService restauranteService, IMapper mapper)
        {
            _restauranteService = restauranteService;
            _mapper = mapper;
        }

        public async Task<Restaurante.Domain.Pedidos.Models.Invoice> CreateInvoice(int basketId, int customerId, int customerAddress, Restaurante.Domain.Pedidos.Models.Enum.PaymentType paymentType, CancellationToken cancellationToken = default)
        {
            var response = await _restauranteService.Create4Async(new CreateInvoiceRequest
            {
                BasketId = basketId,
                CustomerId = customerId,
                CustomerAddress = customerAddress,
                PaymentType = paymentType == Restaurante.Domain.Pedidos.Models.Enum.PaymentType.Debit ? PaymentType._0 : PaymentType._1,
            }, cancellationToken);

            if (!response.Success)
                return null;

            return _mapper.Map<Restaurante.Domain.Pedidos.Models.Invoice>(response.Result);
        }

        public async Task<IEnumerable<Restaurante.Domain.Pedidos.Models.Invoice>> GetByCustomer(int customerId, CancellationToken cancellationToken = default)
        {
            var invoices = await _restauranteService
                .GetByCystomerAsync(customerId, cancellationToken);

            if (!invoices.Success)
                return null;

            return _mapper.Map<ICollection<Restaurante.Domain.Pedidos.Models.Invoice>>(invoices.Result);
        }

        public async Task<Restaurante.Domain.Pedidos.Models.Invoice> GetById(int id, CancellationToken cancellationToken = default)
        {
            var invoices = await _restauranteService
                .GetByIdAsync(id, cancellationToken);

            if (!invoices.Success)
                return null;

            return _mapper.Map<Restaurante.Domain.Pedidos.Models.Invoice>(invoices.Result);
        }
    }
}
