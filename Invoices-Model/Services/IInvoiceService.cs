using Invoices_Model.Entities;
using Invoices_Model.SearchCriterias;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices_Model.Services
{
    public interface IInvoiceService
    {
        Task<IQueryable<IInvoice>> GetInvoices(IInvoiceSearchCriteria invoiceSearchCriteria);
        Task<IInvoice> GetInvoiceByNumber(int? invoiceNumber);
        void Create(Invoice invoice);
        void Update(int? invoiceNumber, Invoice invoice);
    }
}
