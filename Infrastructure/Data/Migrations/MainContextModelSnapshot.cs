﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("cita", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Fecha = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MascotaId = 1,
                            Motivo = "Vacunacion recien nacido",
                            VeterinarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            Fecha = new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MascotaId = 2,
                            Motivo = "Revicion preventiva",
                            VeterinarioId = 2
                        },
                        new
                        {
                            Id = 3,
                            Fecha = new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MascotaId = 3,
                            Motivo = "Vacunacion contra pulgas",
                            VeterinarioId = 3
                        },
                        new
                        {
                            Id = 4,
                            Fecha = new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MascotaId = 4,
                            Motivo = "Terapias",
                            VeterinarioId = 4
                        });
                });

            modelBuilder.Entity("Core.Entities.DetalleMovimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("MedicamentoId")
                        .HasColumnType("int");

                    b.Property<int>("MovimientoMedicamentoId")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("MedicamentoId");

                    b.HasIndex("MovimientoMedicamentoId");

                    b.ToTable("DetalleMovimientos");
                });

            modelBuilder.Entity("Core.Entities.Especialidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Especialidades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "...",
                            Nombre = "Cirujano Vascular"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "...",
                            Nombre = "Terapia"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "...",
                            Nombre = "Psicologo"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "...",
                            Nombre = "Enfermera"
                        });
                });

            modelBuilder.Entity("Core.Entities.Especie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Especies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Felino"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Canino"
                        });
                });

            modelBuilder.Entity("Core.Entities.Laboratorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Laboratorios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Direccion = "Calle labora 1 ",
                            Nombre = "Genfar",
                            Telefono = "435234234"
                        },
                        new
                        {
                            Id = 2,
                            Direccion = "Calle labora 2",
                            Nombre = "Laboratorio 1",
                            Telefono = "435234234"
                        },
                        new
                        {
                            Id = 3,
                            Direccion = "Calle labora 3",
                            Nombre = "Laboratorio 2",
                            Telefono = "435234234"
                        },
                        new
                        {
                            Id = 4,
                            Direccion = "Calle labora 4",
                            Nombre = "Laboratorio 3",
                            Telefono = "435234234"
                        });
                });

            modelBuilder.Entity("Core.Entities.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EspecieId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PropietarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EspecieId");

                    b.HasIndex("PropietarioId");

                    b.ToTable("mascota", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EspecieId = 2,
                            FechaNacimiento = new DateOnly(2019, 7, 3),
                            Nombre = "Mini",
                            PropietarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            EspecieId = 2,
                            FechaNacimiento = new DateOnly(2020, 6, 3),
                            Nombre = "Mascota 1",
                            PropietarioId = 2
                        },
                        new
                        {
                            Id = 3,
                            EspecieId = 1,
                            FechaNacimiento = new DateOnly(2017, 1, 3),
                            Nombre = "Mascota 2",
                            PropietarioId = 3
                        },
                        new
                        {
                            Id = 4,
                            EspecieId = 1,
                            FechaNacimiento = new DateOnly(2019, 8, 3),
                            Nombre = "Mascota 3",
                            PropietarioId = 4
                        });
                });

            modelBuilder.Entity("Core.Entities.Medicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadDisponible")
                        .HasColumnType("int");

                    b.Property<int>("LaboratorioId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Precio")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("LaboratorioId");

                    b.ToTable("medicamento", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CantidadDisponible = 20,
                            LaboratorioId = 1,
                            Nombre = "Medicamento 1",
                            Precio = 56000.0
                        },
                        new
                        {
                            Id = 2,
                            CantidadDisponible = 12,
                            LaboratorioId = 1,
                            Nombre = "Medicamento 2",
                            Precio = 67000.0
                        },
                        new
                        {
                            Id = 3,
                            CantidadDisponible = 65,
                            LaboratorioId = 2,
                            Nombre = "Medicamento 3",
                            Precio = 10000.0
                        },
                        new
                        {
                            Id = 4,
                            CantidadDisponible = 32,
                            LaboratorioId = 3,
                            Nombre = "Medicamento 4",
                            Precio = 16500.0
                        });
                });

            modelBuilder.Entity("Core.Entities.MedicamentoProveedor", b =>
                {
                    b.Property<int>("MedicamentoId")
                        .HasColumnType("int");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.HasKey("MedicamentoId", "ProveedorId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("medicamento_proveedor", (string)null);
                });

            modelBuilder.Entity("Core.Entities.MovimientoMedicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<int>("MedicamentoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoMovimientoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicamentoId");

                    b.HasIndex("TipoMovimientoId");

                    b.ToTable("movimiento_medicamento", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Propietario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Propietarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "esteban@gmail.com",
                            Nombre = "Esteban",
                            Telefono = "213123123"
                        },
                        new
                        {
                            Id = 2,
                            Email = "propietario1@gmail.com",
                            Nombre = "Propietario1",
                            Telefono = "213123123"
                        },
                        new
                        {
                            Id = 3,
                            Email = "propietario2@gmail.com",
                            Nombre = "Propietario2",
                            Telefono = "213123123"
                        },
                        new
                        {
                            Id = 4,
                            Email = "propietario3@gmail.com",
                            Nombre = "Propietario3",
                            Telefono = "213123123"
                        });
                });

            modelBuilder.Entity("Core.Entities.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Core.Entities.Raza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EspecieId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EspecieId");

                    b.ToTable("raza", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EspecieId = 2,
                            Nombre = "Bull Dog"
                        },
                        new
                        {
                            Id = 2,
                            EspecieId = 2,
                            Nombre = "Pincher"
                        },
                        new
                        {
                            Id = 3,
                            EspecieId = 1,
                            Nombre = "Leon"
                        },
                        new
                        {
                            Id = 4,
                            EspecieId = 1,
                            Nombre = "Gato"
                        },
                        new
                        {
                            Id = 5,
                            EspecieId = 1,
                            Nombre = "Tigrillo"
                        });
                });

            modelBuilder.Entity("Core.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Core.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Rols");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "...",
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 2,
                            Description = "...",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Description = "...",
                            Name = "Employee"
                        });
                });

            modelBuilder.Entity("Core.Entities.TipoMovimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TipoMovimientos");
                });

            modelBuilder.Entity("Core.Entities.TratamientoMedico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CitaId")
                        .HasColumnType("int");

                    b.Property<int>("Dosis")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAdministracion")
                        .HasColumnType("datetime");

                    b.Property<int>("MedicamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CitaId");

                    b.HasIndex("MedicamentoId");

                    b.ToTable("tratamiento_medico", (string)null);
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Username", "Email")
                        .IsUnique();

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Core.Entities.UserRol", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("IdUser", "IdRol");

                    b.HasIndex("IdRol");

                    b.ToTable("UserRols");
                });

            modelBuilder.Entity("Core.Entities.Veterinario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadId");

                    b.ToTable("veterinario", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "veterinario1@gmail.com",
                            EspecialidadId = 1,
                            Nombre = "Veterinario 1",
                            Telefono = "4352345"
                        },
                        new
                        {
                            Id = 2,
                            Email = "veterinario2@gmail.com",
                            EspecialidadId = 1,
                            Nombre = "Veterinario 2",
                            Telefono = "4352345"
                        },
                        new
                        {
                            Id = 3,
                            Email = "veterinario3@gmail.com",
                            EspecialidadId = 2,
                            Nombre = "Veterinario 3",
                            Telefono = "4352345"
                        },
                        new
                        {
                            Id = 4,
                            Email = "veterinario4@gmail.com",
                            EspecialidadId = 3,
                            Nombre = "Veterinario 4",
                            Telefono = "4352345"
                        });
                });

            modelBuilder.Entity("Core.Entities.Cita", b =>
                {
                    b.HasOne("Core.Entities.Mascota", "Mascota")
                        .WithMany("Citas")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Veterinario", "Veterinario")
                        .WithMany("Citas")
                        .HasForeignKey("VeterinarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("Core.Entities.DetalleMovimiento", b =>
                {
                    b.HasOne("Core.Entities.Medicamento", "Medicamento")
                        .WithMany("DetalleMovimientos")
                        .HasForeignKey("MedicamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.MovimientoMedicamento", "MovimientoMedicamento")
                        .WithMany("DetalleMovimientos")
                        .HasForeignKey("MovimientoMedicamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");

                    b.Navigation("MovimientoMedicamento");
                });

            modelBuilder.Entity("Core.Entities.Mascota", b =>
                {
                    b.HasOne("Core.Entities.Especie", "Especie")
                        .WithMany("Mascotas")
                        .HasForeignKey("EspecieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Propietario", "Propietario")
                        .WithMany("Mascotas")
                        .HasForeignKey("PropietarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especie");

                    b.Navigation("Propietario");
                });

            modelBuilder.Entity("Core.Entities.Medicamento", b =>
                {
                    b.HasOne("Core.Entities.Laboratorio", "Laboratorio")
                        .WithMany("Medicamentos")
                        .HasForeignKey("LaboratorioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laboratorio");
                });

            modelBuilder.Entity("Core.Entities.MedicamentoProveedor", b =>
                {
                    b.HasOne("Core.Entities.Medicamento", "Medicamento")
                        .WithMany("MedicamentoProveedores")
                        .HasForeignKey("MedicamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Proveedor", "Proveedor")
                        .WithMany("MedicamentoProveedores")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Core.Entities.MovimientoMedicamento", b =>
                {
                    b.HasOne("Core.Entities.Medicamento", "Medicamento")
                        .WithMany("MovimientoMedicamentos")
                        .HasForeignKey("MedicamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoMovimiento", "TipoMovimiento")
                        .WithMany("MovimientoMedicamentos")
                        .HasForeignKey("TipoMovimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");

                    b.Navigation("TipoMovimiento");
                });

            modelBuilder.Entity("Core.Entities.Raza", b =>
                {
                    b.HasOne("Core.Entities.Especie", "Especie")
                        .WithMany("Razas")
                        .HasForeignKey("EspecieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especie");
                });

            modelBuilder.Entity("Core.Entities.TratamientoMedico", b =>
                {
                    b.HasOne("Core.Entities.Cita", "Cita")
                        .WithMany("TratamientosMedicos")
                        .HasForeignKey("CitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Medicamento", "Medicamento")
                        .WithMany("TratamientoMedicos")
                        .HasForeignKey("MedicamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cita");

                    b.Navigation("Medicamento");
                });

            modelBuilder.Entity("Core.Entities.UserRol", b =>
                {
                    b.HasOne("Core.Entities.Rol", "Rol")
                        .WithMany("UserRols")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("UserRols")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.Veterinario", b =>
                {
                    b.HasOne("Core.Entities.Especialidad", "Especialidad")
                        .WithMany("Veterinarios")
                        .HasForeignKey("EspecialidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidad");
                });

            modelBuilder.Entity("Core.Entities.Cita", b =>
                {
                    b.Navigation("TratamientosMedicos");
                });

            modelBuilder.Entity("Core.Entities.Especialidad", b =>
                {
                    b.Navigation("Veterinarios");
                });

            modelBuilder.Entity("Core.Entities.Especie", b =>
                {
                    b.Navigation("Mascotas");

                    b.Navigation("Razas");
                });

            modelBuilder.Entity("Core.Entities.Laboratorio", b =>
                {
                    b.Navigation("Medicamentos");
                });

            modelBuilder.Entity("Core.Entities.Mascota", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("Core.Entities.Medicamento", b =>
                {
                    b.Navigation("DetalleMovimientos");

                    b.Navigation("MedicamentoProveedores");

                    b.Navigation("MovimientoMedicamentos");

                    b.Navigation("TratamientoMedicos");
                });

            modelBuilder.Entity("Core.Entities.MovimientoMedicamento", b =>
                {
                    b.Navigation("DetalleMovimientos");
                });

            modelBuilder.Entity("Core.Entities.Propietario", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Core.Entities.Proveedor", b =>
                {
                    b.Navigation("MedicamentoProveedores");
                });

            modelBuilder.Entity("Core.Entities.Rol", b =>
                {
                    b.Navigation("UserRols");
                });

            modelBuilder.Entity("Core.Entities.TipoMovimiento", b =>
                {
                    b.Navigation("MovimientoMedicamentos");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Navigation("UserRols");
                });

            modelBuilder.Entity("Core.Entities.Veterinario", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
