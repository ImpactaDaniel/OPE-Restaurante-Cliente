namespace Restaurante.Domain.Pedidos.Models.Enum
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
