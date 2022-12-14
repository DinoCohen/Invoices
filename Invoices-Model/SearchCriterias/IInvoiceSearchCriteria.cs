using Invoices_Model.Enum;
using System;
using System.Collections.Generic;

namespace Invoices_Model.SearchCriterias
{
    public interface IInvoiceSearchCriteria
    {
        int? MinAmount { get; set; }
        int? MaxAmount { get; set; }
        DateTime? MinDate { get; set; }
        DateTime? MaxDate { get; set; }
        IEnumerable<InvoiceProcessingStatus> Status { get; set; }
        IEnumerable<PaymentMethod> PaymentMethod { get; set; }
        string OrderingField { get; set; }
        bool AscendingOrder { get; set; }
    }
}
