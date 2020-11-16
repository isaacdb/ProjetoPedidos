using Microsoft.EntityFrameworkCore;
using Teste2.Models;

namespace Teste2.Data
{
    public class Teste2Context : DbContext
    {
        public Teste2Context (DbContextOptions<Teste2Context> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }

        public DbSet<ClientOrder> ClientOrder { get; set; }

        public DbSet<ProductOrder> ProductOrder { get; set; }

        public DbSet<Product> Product { get; set; }
    }
}
