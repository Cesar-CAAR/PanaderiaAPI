using Microsoft.EntityFrameworkCore;
using PanaderiaAPI.Models;

namespace PanaderiaAPI.Data
{
    public class PanaderiaContext : DbContext
    {
        public PanaderiaContext(DbContextOptions<PanaderiaContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
    }
}