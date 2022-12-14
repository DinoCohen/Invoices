using Invoices_Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices_Model.Entities
{
    public class Invoice : IInvoice
    {
        const string errorMessage = "The field {0} is required";

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Required(ErrorMessage = errorMessage)]
        public int InvoiceNumber { get; set; }

        public DateTime InvoiceCreation { get; set; }

        public DateTime? InvoiceLastChange { get; set; }

        public InvoiceProcessingStatus Status { get; set; }

        [Required(ErrorMessage = errorMessage)]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = errorMessage)]
        public PaymentMethod PaymentMethod { get; set; }

        public Invoice()
        {
            InvoiceCreation = DateTime.Now;
            Status = InvoiceProcessingStatus.New;
        }
    }
}