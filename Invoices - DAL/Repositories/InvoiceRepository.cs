using Invoices_Model.Entities;
using Invoices_Model.Repositories;
using Invoices_Model.SearchCriterias;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices___DAL.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InvoiceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<IInvoice>> GetInvoices(IInvoiceSearchCriteria invoiceSearchCriteria)
        {
            var result = await _dbContext.Invoices.Where(i => invoiceSearchCriteria.MinAmount == null ? true : i.Amount >= invoiceSearchCriteria.MinAmount)
                                  .Where(i => invoiceSearchCriteria.MaxAmount == null ? true : i.Amount <= invoiceSearchCriteria.MaxAmount)
                                  .Where(i => invoiceSearchCriteria.MinDate == null ? true : i.InvoiceCreation >= invoiceSearchCriteria.MinDate)
                                  .Where(i => invoiceSearchCriteria.MaxDate == null ? true : i.InvoiceCreation <= invoiceSearchCriteria.MaxDate)
                                  .Where(i => invoiceSearchCriteria.Status == null ? true : i.Status.Equals(invoiceSearchCriteria.Status))
                                  .Where(i => invoiceSearchCriteria.PaymentMethod == null ? true : i.PaymentMethod.Equals(invoiceSearchCriteria.PaymentMethod)).ToListAsync();

            return result.AsQueryable();
        }

        public async Task<Invoice> GetInvoiceByNumber(int invoiceNumber)
        {
            return await _dbContext.Invoices.FirstOrDefaultAsync(i => i.InvoiceNumber == invoiceNumber);
        }

        public void Create(Invoice invoice)
        {
            _dbContext.Invoices.Add(invoice);
            _dbContext.SaveChanges();
        }

        public void Update(Invoice invoice)
        {
            _dbContext.Entry(invoice).State = EntityState.Modified;
            _dbContext.SaveChangesAsync();
        }
    }
}
