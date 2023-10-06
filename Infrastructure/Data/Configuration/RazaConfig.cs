
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class RazaConfig : IEntityTypeConfiguration<Raza>
    {
        public void Configure(EntityTypeBuilder<Raza> builder)
        {
            builder.ToTable("raza");
            
            builder.Property(x => x.Nombre)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasOne(x => x.Especie)
                   .WithMany(a => a.Razas)
                   .HasForeignKey(e => e.EspecieId)
                   .IsRequired();
        }
    }
}