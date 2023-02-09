using Api.Intuit.Domain.BdIntuitClientes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Intuit.Domain.BdIntuitClientes.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {  
            builder.HasKey(table => table.ID);
            builder.Property(table => table.ID).ValueGeneratedOnAdd();
            
            builder.Property(table => table.name).HasMaxLength(30);
            builder.Property(table => table.surname).HasMaxLength(30);
            builder.Property(table => table.birthdate).HasMaxLength(30);
            builder.Property(table => table.cuit).HasMaxLength(30);
            builder.Property(table => table.address).HasMaxLength(60).IsRequired(false);
            builder.Property(table => table.phone).HasMaxLength(30);
            builder.Property(table => table.email).HasMaxLength(90);


        }
    }
}
