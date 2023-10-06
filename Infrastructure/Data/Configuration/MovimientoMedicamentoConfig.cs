
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class MovimientoMedicamentoConfig : IEntityTypeConfiguration<MovimientoMedicamento>
    {
        public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
        {
            builder.ToTable("movimiento_medicamento");

            builder.HasOne(x => x.Medicamento)
                   .WithMany(a => a.MovimientoMedicamentos)
                   .HasForeignKey(e => e.MedicamentoId)
                   .IsRequired();

            builder.Property(x => x.Cantidad)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(x => x.Fecha)
                   .HasColumnType("date")
                   .IsRequired();

            builder.HasOne(x => x.TipoMovimiento)
                   .WithMany(a => a.MovimientoMedicamentos)
                   .HasForeignKey(e => e.TipoMovimientoId)
                   .IsRequired();
        }
    }
}