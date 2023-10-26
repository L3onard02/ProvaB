using Microsoft.EntityFrameworkCore;
using punto1.Entities;

namespace Punto1.DataSource
{
    public class ProvaContext : DbContext
    {
    
        
            public ProvaContext()
            {
            }
            public ProvaContext(DbContextOptions<ProvaContext> options)
            : base(options)
            {
            }


        public DbSet<Cliente> Clienti { get; set; }
    }
    
}
