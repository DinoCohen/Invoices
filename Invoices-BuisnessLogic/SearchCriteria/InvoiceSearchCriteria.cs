using Invoices_Model.Enum;
using Invoices_Model.SearchCriterias;
using System;
using System.Collections.Generic;

namespace Invoices_BuisnessLogic.SearchCriteria
{
    public class InvoiceSearchCriteria : IInvoiceSearchCriteria
    {
        public int Page { get; set; } = 1;

        public int RecordsPerPage { get; set; } = 10;
        //private readonly int maxRecordsPerPage = 50;

        //public int RecordsPerPage
        //{
        //    get
        //    {
        //        return recordsPerPage;
        //    }
        //    set
        //    {
        //        recordsPerPage = (value > maxRecordsPerPage) ? maxRecordsPerPage : value;
        //    }
        //}

        public PaginationDTO Pagination
        {
            get { return new PaginationDTO() { Page = Page, RecordsPerPage = RecordsPerPage }; }
        }
        public int? MinAmount { get; set; }
        public int? MaxAmount { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public IEnumerable<InvoiceProcessingStatus> Status { get; set; }
        public IEnumerable<PaymentMethod> PaymentMethod { get; set; }
        public string OrderingField { get; set; }
        public bool AscendingOrder { get; set; } = true;
    }
}
