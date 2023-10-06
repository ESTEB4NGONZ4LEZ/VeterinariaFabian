
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class TratamientoMedicoConfig : IEntityTypeConfiguration<TratamientoMedico>
    {
        public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
        {
            builder.ToTable("tratamiento_medico");

            builder.HasOne(x => x.Cita)
                   .WithMany(a => a.TratamientosMedicos)
                   .HasForeignKey(e => e.CitaId)
                   .IsRequired();

            builder.HasOne(x => x.Medicamento)
                   .WithMany(a => a.TratamientoMedicos)
                   .HasForeignKey(e => e.MedicamentoId)
                   .IsRequired();

            builder.Property(x => x.Dosis)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(x => x.FechaAdministracion)
                   .HasColumnType("datetime")
                   .IsRequired();
        }
    }
}