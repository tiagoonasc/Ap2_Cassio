using Invoicing.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Invoicing.Models.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataContext _context;

        public InvoiceRepository(DataContext context)
        {
            this._context = context;
        }

        public void Create(Invoice invoice)
        {
            _context.Invoice.Add(invoice);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var invoice = _context.Invoice.Find(id);

            if (invoice == null)
                return false;
            else
            {
                _context.Invoice.Remove(invoice);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Invoice> GetAll()
        {
            return _context.Invoice.ToList();
        }

        public Invoice GetById(int id)
        {
            return _context.Invoice.SingleOrDefault(i => i.Id == id);
        }

        public void Update(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}