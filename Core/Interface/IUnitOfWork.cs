
namespace Core.Interface
{
    public interface IUnitOfWork
    {
        IUser Users { get; }
        IRol Rols { get; }
        IRefreshToken RefreshToken { get; }
        ICita Cita { get; }
        IDetalleMovimiento DetalleMovimiento { get; }
        IEspecialidad Especialidad { get; }
        IEspecie Especie { get; }
        ILaboratorio Laboratorio { get; }
        IMascota Mascota { get; }
        IMedicamento Medicamento { get; }
        IMovimientoMedicamento MovimientoMedicamento { get; }
        IPropietario Propietario { get; }
        IProveedor Proveedor { get; }
        IRaza Raza { get; }
        ITipoMovimiento TipoMovimiento { get; }
        ITratamientoMedico TratamientoMedico { get; }
        IVeterinario Veterinario { get; }
        Task<int> SaveAsync();
    }
}