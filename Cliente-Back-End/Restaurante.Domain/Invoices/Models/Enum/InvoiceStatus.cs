namespace Restaurante.Domain.Invoices.Models.Enum
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
