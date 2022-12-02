using WebPasajero.Models;
using Microsoft.EntityFrameworkCore;

namespace WebPasajero.Data
{
    public class PasajeroContext : DbContext
    {
        public PasajeroContext(DbContextOptions<PasajeroContext> options) : base(options) { }

        public DbSet<Pasajero> pasajeros { get; set;}
    }
}
