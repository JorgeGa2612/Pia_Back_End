using Microsoft.EntityFrameworkCore;
using PiaTienda.Entidades;

namespace PiaTienda
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Ventas> Ventas { get; set; }

        public DbSet<Empleados> Empleados { get; set; }

        public DbSet<Distribuidores> Distribuidores { get; set; }

        public DbSet<Categorias> Categorias { get; set; }

        public DbSet<Articulos> Articulos { get; set; }
    }
}
