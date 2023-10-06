
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class CitaConfig : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.ToTable("cita");

            builder.HasOne(x => x.Mascota)
                   .WithMany(a => a.Citas)
                   .HasForeignKey(e => e.MascotaId)
                   .IsRequired();

            builder.Property(x => x.Fecha)
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(x => x.Motivo)
                   .IsRequired();
            
            builder.HasOne(x => x.Veterinario)
                   .WithMany(a => a.Citas)
                   .HasForeignKey(e => e.VeterinarioId)
                   .IsRequired();
        }
    }
}