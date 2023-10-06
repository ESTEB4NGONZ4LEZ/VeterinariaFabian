
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seed
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especie>()
                        .HasData
                        (
                            new Especie {Id = 1, Nombre = "Felino"},
                            new Especie {Id = 2, Nombre = "Canino"}
                        );

            modelBuilder.Entity<Raza>()
                        .HasData
                        (
                            new Raza {Id = 1, Nombre = "Bull Dog", EspecieId = 2},
                            new Raza {Id = 2, Nombre = "Pincher", EspecieId = 2},
                            new Raza {Id = 3, Nombre = "Leon", EspecieId = 1},
                            new Raza {Id = 4, Nombre = "Gato", EspecieId = 1},
                            new Raza {Id = 5, Nombre = "Tigrillo", EspecieId = 1}
                        );

            modelBuilder.Entity<Propietario>()
                        .HasData
                        (
                            new Propietario {Id = 1, Nombre = "Esteban", Email = "esteban@gmail.com", Telefono = "213123123"},
                            new Propietario {Id = 2, Nombre = "Propietario1", Email = "propietario1@gmail.com", Telefono = "213123123"},
                            new Propietario {Id = 3, Nombre = "Propietario2", Email = "propietario2@gmail.com", Telefono = "213123123"},
                            new Propietario {Id = 4, Nombre = "Propietario3", Email = "propietario3@gmail.com", Telefono = "213123123"}
                        );

            modelBuilder.Entity<Mascota>()
                        .HasData
                        (
                            new Mascota {Id = 1, PropietarioId = 1, EspecieId = 2, Nombre = "Mini", FechaNacimiento = new DateOnly(2019, 07, 03)},
                            new Mascota {Id = 2, PropietarioId = 2, EspecieId = 2, Nombre = "Mascota 1", FechaNacimiento = new DateOnly(2020, 06, 03)},
                            new Mascota {Id = 3, PropietarioId = 3, EspecieId = 1, Nombre = "Mascota 2", FechaNacimiento = new DateOnly(2017, 01, 03)},
                            new Mascota {Id = 4, PropietarioId = 4, EspecieId = 1, Nombre = "Mascota 3", FechaNacimiento = new DateOnly(2019, 08, 03)}
                        );

            modelBuilder.Entity<Veterinario>()
                        .HasData
                        (
                            new Veterinario {Id = 1, Nombre = "Veterinario 1", Email = "veterinario1@gmail.com", Telefono = "4352345", EspecialidadId = 1},
                            new Veterinario {Id = 2, Nombre = "Veterinario 2", Email = "veterinario2@gmail.com", Telefono = "4352345", EspecialidadId = 1},
                            new Veterinario {Id = 3, Nombre = "Veterinario 3", Email = "veterinario3@gmail.com", Telefono = "4352345", EspecialidadId = 2},
                            new Veterinario {Id = 4, Nombre = "Veterinario 4", Email = "veterinario4@gmail.com", Telefono = "4352345", EspecialidadId = 3}
                        );

            modelBuilder.Entity<Especialidad>()
                        .HasData
                        (
                            new Especialidad {Id = 1, Nombre = "Cirujano Vascular", Descripcion = "..."},
                            new Especialidad {Id = 2, Nombre = "Terapia", Descripcion = "..."},
                            new Especialidad {Id = 3, Nombre = "Psicologo", Descripcion = "..."},
                            new Especialidad {Id = 4, Nombre = "Enfermera", Descripcion = "..."}
                        );

            modelBuilder.Entity<Medicamento>()
                        .HasData
                        (
                            new Medicamento {Id = 1, Nombre = "Medicamento 1", CantidadDisponible = 20, Precio = 56000.00, LaboratorioId = 1},
                            new Medicamento {Id = 2, Nombre = "Medicamento 2", CantidadDisponible = 12, Precio = 67000.00, LaboratorioId = 1},
                            new Medicamento {Id = 3, Nombre = "Medicamento 3", CantidadDisponible = 65, Precio = 10000.00, LaboratorioId = 2},
                            new Medicamento {Id = 4, Nombre = "Medicamento 4", CantidadDisponible = 32, Precio = 16500.00, LaboratorioId = 3}
                        );

            modelBuilder.Entity<Laboratorio>()
                        .HasData
                        (
                            new Laboratorio {Id = 1, Nombre = "Genfar", Direccion = "Calle labora 1 ", Telefono = "435234234"},
                            new Laboratorio {Id = 2, Nombre = "Laboratorio 1", Direccion = "Calle labora 2", Telefono = "435234234"},
                            new Laboratorio {Id = 3, Nombre = "Laboratorio 2", Direccion = "Calle labora 3", Telefono = "435234234"},
                            new Laboratorio {Id = 4, Nombre = "Laboratorio 3", Direccion = "Calle labora 4", Telefono = "435234234"}
                        );

            modelBuilder.Entity<Cita>()
                        .HasData
                        (
                            new Cita {Id = 1, MascotaId = 1, Fecha = new DateTime(2023, 01, 23), Motivo = "Vacunacion recien nacido", VeterinarioId = 1},
                            new Cita {Id = 2, MascotaId = 2, Fecha = new DateTime(2022, 05, 26), Motivo = "Revicion preventiva", VeterinarioId = 2},
                            new Cita {Id = 3, MascotaId = 3, Fecha = new DateTime(2023, 03, 15), Motivo = "Vacunacion contra pulgas", VeterinarioId = 3},
                            new Cita {Id = 4, MascotaId = 4, Fecha = new DateTime(2021, 05, 24), Motivo = "Terapias", VeterinarioId = 4}
                        );

            modelBuilder.Entity<Rol>()
                        .HasData
                        (
                            new Rol {Id = 1, Name = "Manager", Description = "..."},
                            new Rol {Id = 2, Name = "Admin", Description = "..."},
                            new Rol {Id = 3, Name = "Employee", Description = "..."}
                        );           
        }
    }
}