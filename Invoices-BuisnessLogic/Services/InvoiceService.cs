using Invoices_Model.Entities;
using Invoices_Model.Repositories;
using Invoices_Model.SearchCriterias;
using Invoices_Model.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.Extensions.Logging;
using System;

namespace Invoices_BuisnessLogic.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ILogger<InvoiceService> _logger;


        public InvoiceService(IInvoiceRepository invoiceRepository, ILogger<InvoiceService> logger)
        {
            _invoiceRepository = invoiceRepository;
            _logger = logger;
        }

        public async Task<IQueryable<IInvoice>> GetInvoices(IInvoiceSearchCriteria invoiceSearchCriteria)
        {
            var invoices = await _invoiceRepository.GetInvoices(invoiceSearchCriteria);
            if (!string.IsNullOrWhiteSpace(invoiceSearchCriteria.OrderingField))
            {
                try
                {
                    invoices = invoices
                        .OrderBy($"{invoiceSearchCriteria.OrderingField} {(invoiceSearchCriteria.AscendingOrder ? "ascending" : "descending")}");

                }
                catch
                {
                    _logger.LogWarning("Could not oreder by field: " + invoiceSearchCriteria.OrderingField);
                }
            }
            return invoices;
        }

        public async Task<IInvoice> GetInvoiceByNumber(int? invoiceNumber)
        {
            Invoice invoice = null;

            if (invoiceNumber != null)
            {
                invoice = await _invoiceRepository.GetInvoiceByNumber((int)invoiceNumber);
            }
            return invoice;
        }

        public async void Create(Invoice invoice)
        {
            if (invoice != null)
            {
                var exist = GetInvoiceByNumber(invoice.InvoiceNumber);
                if (exist.Result == null)
                    _invoiceRepository.Create(invoice);
                else _logger.LogWarning($"Invoice number: {invoice.InvoiceNumber} already exist");
            }
        }

        public async void Update(int? invoiceNumber, Invoice invoice)
        {
            if (invoiceNumber != null)
            {
                var invoiceToUpdate = await _invoiceRepository.GetInvoiceByNumber((int)invoiceNumber);
                if (invoiceToUpdate != null)
                {
                    invoiceToUpdate.InvoiceLastChange = DateTime.Now;

                    if (invoice.InvoiceNumber != 0)
                    {
                        invoiceToUpdate.InvoiceNumber = invoice.InvoiceNumber;
                    }
                    if (invoice.Amount != 0)
                    {
                        invoiceToUpdate.Amount = invoice.Amount;
                    }
                    if (invoice.Status != 0)
                    {
                        invoiceToUpdate.Status = invoice.Status;
                    }
                    if (invoice.PaymentMethod != 0)
                    {
                        invoiceToUpdate.PaymentMethod = invoice.PaymentMethod;
                    }
                    _invoiceRepository.Update(invoiceToUpdate);
                }

            }
        }
    }
}
