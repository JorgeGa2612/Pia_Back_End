using Microsoft.EntityFrameworkCore;
using PiaTienda.Entidades;

namespace PiaTienda
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
         public DbSet<Clientes> Clientes { get; set; }
         //lo mismo para todas las entidades
         public DbSet <Articulos> Articulos { get; set; }

        public DbSet <Categorias> Categorias { get; set; }

        public DbSet <Distribuidores> Distribuidores { get; set; }

        public DbSet <Empleados> Empleados { get; set; }

        public DbSet <Ventas> Ventas { get; set; }

    }
}
