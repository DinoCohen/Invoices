using Invoices_Model.Enum;
using System;

namespace Invoices_Model.Entities
{
    public interface IInvoice
    {
        int InvoiceNumber { get; set; }
        DateTime InvoiceCreation { get; set; }
        DateTime? InvoiceLastChange { get; set; }
        InvoiceProcessingStatus Status { get; set; }
        decimal Amount { get; set; }
        PaymentMethod PaymentMethod { get; set; }
    }
}
