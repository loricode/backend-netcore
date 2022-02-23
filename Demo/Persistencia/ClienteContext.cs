
using Backend.Demo.Entidades;
using Microsoft.EntityFrameworkCore;


namespace Backend.Demo.Persistencia
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Configuracion> Configuraciones { get; set; }
    }
}
