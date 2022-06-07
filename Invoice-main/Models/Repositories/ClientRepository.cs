using System.Collections.Generic;
using System.Linq;
using Invoicing.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Invoicing.Models.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            this._context = context;
        }

        public void Create(Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var client = _context.Client.Find(id);

            if (client == null)
                return false;
            else
            {
                _context.Client.Remove(client);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Client> GetAll()
        {
            return _context.Client.ToList();
        }

        public Client GetById(int id)
        {
            return _context.Client.SingleOrDefault(i => i.Id == id);
        }

        public void Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
