using Invoicing.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Invoicing.Models.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
        : base(opts)
        { }

        public DbSet<Client> Client { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
    }
}
