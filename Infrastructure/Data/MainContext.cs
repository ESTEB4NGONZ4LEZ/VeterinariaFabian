
using System.Reflection;
using Core.Entities;
using Infrastructure.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<UserRol> UserRols { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<DetalleMovimiento> DetalleMovimientos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<MedicamentoProveedor> MedicamentoProveedores { get; set; }
        public DbSet<MovimientoMedicamento> MovimientoMedicamentos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Raza> Razas { get; set; }
        public DbSet<TipoMovimiento> TipoMovimientos { get; set; }
        public DbSet<TratamientoMedico> TratamientoMedicos { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicamentoProveedor>().HasKey(x => new {x.MedicamentoId, x.ProveedorId});
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }
    }
}