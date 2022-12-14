using Invoices_API.Helpers;
using Invoices_BuisnessLogic.SearchCriteria;
using Invoices_Model.Entities;
using Invoices_Model.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoices_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<IEnumerable<IInvoice>> GetAll([FromQuery] InvoiceSearchCriteria searchCriteria = null)
        {
            var queryableInvoices = await _invoiceService.GetInvoices(searchCriteria);

            var invoices = queryableInvoices.Paginate(searchCriteria.Pagination).ToListAsync();
            return await invoices;
        }

        [HttpGet("{invoiceNumber}", Name = "getInvoice")]
        public async Task<ActionResult<IInvoice>> GetInvoice(int? invoiceNumber)
        {
            if (invoiceNumber is null)
            {
                return BadRequest();
            }
            var result = await _invoiceService.GetInvoiceByNumber(invoiceNumber);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Invoice invoice)
        {
            if (invoice is null)
                return BadRequest();

            _invoiceService.Create(invoice);
            return new CreatedAtRouteResult("getInvoice", new { invoice.InvoiceNumber }, invoice);
        }

        [HttpPut("{invoiceNumber}")]
        public async Task<ActionResult> Put(int? invoiceNumber, [FromBody] Invoice invoice)
        {
            if (invoice is null)
                return BadRequest();

            _invoiceService.Update(invoiceNumber, invoice);
            return NoContent();
        }
    }
}
