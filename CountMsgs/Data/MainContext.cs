using Microsoft.EntityFrameworkCore;

namespace CountMsgs.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options)
            : base(options)
        {
        }

        //public DbSet<Envio> Envios { get; set; }
    }
}
