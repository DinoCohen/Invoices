using Invoices_Model.Entities;
using Invoices_Model.SearchCriterias;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices_Model.Repositories
{
    public interface IInvoiceRepository
    {
        Task<IQueryable<IInvoice>> GetInvoices(IInvoiceSearchCriteria invoiceSearchCriteria);
        Task<Invoice> GetInvoiceByNumber(int invoiceNumber);
        void Create(Invoice invoice);
        void Update(Invoice invoice);
    }
}
