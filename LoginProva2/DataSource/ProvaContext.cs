using Microsoft.EntityFrameworkCore;
using WebApiProvaFaseA.Entities;

namespace WebAPIVenditaLibri.DataSource
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


           
        public DbSet<Carrello> Carrelli { get; set; }
    }
    
}
