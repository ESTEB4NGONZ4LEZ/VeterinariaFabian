
using API.Dtos.Cita;
using API.Dtos.DetalleMovimiento;
using API.Dtos.Especialidad;
using API.Dtos.Especie;
using API.Dtos.Laboratorio;
using API.Dtos.Mascota;
using API.Dtos.Medicamento;
using API.Dtos.MovimientoMedicamento;
using API.Dtos.Propietario;
using API.Dtos.Proveedor;
using API.Dtos.Raza;
using API.Dtos.Rol;
using API.Dtos.TipoMovimiento;
using API.Dtos.TratamientoMedico;
using API.Dtos.User;
using API.Dtos.Veterinario;
using AutoMapper;
using Core.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserxRolDto>().ReverseMap();

            CreateMap<Rol, RolDto>().ReverseMap();

            CreateMap<Especialidad, EspecialidadDto>().ReverseMap();
            CreateMap<Especialidad, EspecialidadxVeterinarioDto>().ReverseMap();

            CreateMap<Veterinario, VeterinarioDto>().ReverseMap();
            CreateMap<Veterinario, VeterinarioxCitaDto>().ReverseMap();

            CreateMap<Cita, CitaDto>().ReverseMap();

            CreateMap<Medicamento, MedicamentoDto>().ReverseMap();

            CreateMap<Laboratorio, LaboratorioDto>().ReverseMap();

            CreateMap<Mascota, MascotaDto>().ReverseMap();

            CreateMap<Especie, EspecieDto>().ReverseMap();

            CreateMap<DetalleMovimiento, DetalleMovimientoDto>().ReverseMap();

            CreateMap<MovimientoMedicamento, MovimientoMedicamentoDto>().ReverseMap();

            CreateMap<Propietario, PropietarioDto>().ReverseMap();

            CreateMap<Proveedor, ProveedorDto>().ReverseMap();

            CreateMap<Raza, RazaDto>().ReverseMap();

            CreateMap<TipoMovimiento, TipoMovimientoDto>().ReverseMap();

            CreateMap<TratamientoMedico, TratamientoMedicoDto>().ReverseMap();
        }
    }
}