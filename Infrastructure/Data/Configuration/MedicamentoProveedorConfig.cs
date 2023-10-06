
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class MedicamentoProveedorConfig : IEntityTypeConfiguration<MedicamentoProveedor>
    {
        public void Configure(EntityTypeBuilder<MedicamentoProveedor> builder)
        {
            builder.ToTable("medicamento_proveedor");

            builder.HasOne(x => x.Medicamento)
                   .WithMany(a => a.MedicamentoProveedores)
                   .HasForeignKey(e => e.MedicamentoId)
                   .IsRequired();

            builder.HasOne(x => x.Proveedor)
                   .WithMany(a => a.MedicamentoProveedores)
                   .HasForeignKey(e => e.ProveedorId)
                   .IsRequired();
        }
    }
}