using Invoices_Model.Entities;
using Invoices_Model.Enum;
using System;

namespace Invoices_Model.DTOs
{
    public class InvoiceDTO : IInvoice
    {
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceCreation { get; set; }
        public DateTime? InvoiceLastChange { get; set; }
        public InvoiceProcessingStatus Status { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
