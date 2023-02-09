using Api.Intuit.Domain.BdIntuitClientes.Configuration;
using Api.Intuit.Domain.BdIntuitClientes.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Intuit.Domain.BdIntuitClientes
{
    public partial class ClientesDbContex : DbContext
    {
        public ClientesDbContex()
        {
        }

        public ClientesDbContex(DbContextOptions<ClientesDbContex> options):base(options) 
        {
            
        }
        public virtual DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
          
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
