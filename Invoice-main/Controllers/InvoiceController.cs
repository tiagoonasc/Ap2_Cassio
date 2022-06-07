using System;
using Invoicing.Controllers.ViewModels;
using Invoicing.Models.Domain;
using Invoicing.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Controllers
{
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _repository;
        public InvoiceController(IInvoiceRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet("v1/invoices")]
        public IActionResult GetList()
        {
            var listInvoices = _repository.GetAll();
            return Ok(listInvoices);
        }

        [HttpGet("v1/invoices/{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var invoice = _repository.GetById(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        [HttpPost("v1/invoices")]
        public IActionResult Post([FromBody] InvoiceCreateViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newInvoice = new Invoice
            {
                IssuanceDate = DateTime.Now,
                DueDate = model.DueDate,
                AmountCharge = model.AmountCharge,
                Status = false,
                ClientId = model.ClientId
            };

            _repository.Create(newInvoice);
            return Ok(new
            {
                message = "Cobrança vinculada ao cliente de código " + model.ClientId
            });
        } 

        [HttpPatch("v1/invoices/{id:int}")]
        public ActionResult Patch([FromRoute] int id)
        {
            var invoice = _repository.GetById(id);

            if (invoice == null) return NotFound();

            invoice.PaymentDate = DateTime.Now;
            invoice.Status = true;

            _repository.Update(invoice);
            return Ok(new
            {
                message = "Pagamento realizado com sucesso",
                id = id
            });
        }
    }
}
