namespace Restaurante.Clientes.Domain.Pedidos.Enums
{
    public enum InvoiceStatus
    {
        Created,
        Accepted,
        Rejected,
        PaymentPending,
        Payed,
        Shipped,
        Delivered,
        Closed
    }
}
