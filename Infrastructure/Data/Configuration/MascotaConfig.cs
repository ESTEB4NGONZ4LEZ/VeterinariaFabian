
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class MascotaConfig : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable("mascota");

            builder.HasOne(x => x.Propietario)
                   .WithMany(a => a.Mascotas)
                   .HasForeignKey(e => e.PropietarioId)
                   .IsRequired();

            builder.HasOne(x => x.Especie)
                   .WithMany(a => a.Mascotas)
                   .HasForeignKey(e => e.EspecieId)
                   .IsRequired();

            builder.Property(x => x.Nombre)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.FechaNacimiento)
                   .HasColumnType("date")
                   .IsRequired();
        }
    }
}