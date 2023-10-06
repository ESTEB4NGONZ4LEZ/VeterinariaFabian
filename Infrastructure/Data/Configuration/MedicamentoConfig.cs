
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class MedicamentoConfig : IEntityTypeConfiguration<Medicamento>
    {
        public void Configure(EntityTypeBuilder<Medicamento> builder)
        {
            builder.ToTable("medicamento");

            builder.Property(x => x.Nombre)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.CantidadDisponible)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(x => x.Precio)
                   .HasColumnType("double")
                   .IsRequired();

            builder.HasOne(x => x.Laboratorio)
                   .WithMany(a => a.Medicamentos)
                   .HasForeignKey(e => e.LaboratorioId)
                   .IsRequired();
        }
    }
}