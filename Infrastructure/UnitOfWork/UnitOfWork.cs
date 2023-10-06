
using Infrastructure.Repository;
using Core.Interface;
using Infrastructure.Data;
using Core.Entities;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MainContext _context;
        public UnitOfWork(MainContext context)
        {
            _context = context;
        }

        private UserRepository _users;
        private RolRepository _rols;
        private RefreshTokenRepository _refreshToken;
        private CitaRepository _citas;
        private DetalleMovimientoRepository _detalleMovimientos;
        private EspecialidadRepository _especialidades;
        private EspecieRepository _especies;
        private LaboratorioRepository _laboratorios;
        private MascotaRepository _mascotas;
        private MedicamentoRepository _medicamentos;
        private MovimientoMedicamentoRepository _movimientoMedicamento;
        private PropietarioRepository _propietarios;
        private ProveedorRepository _proveedores;
        private RazaRepository _razas;
        private TipoMovimientoRepository _tipoMovimientos;
        private TratamientoMedicoRepository _tratamientoMedicos;
        private VeterinarioRepository _veterinarios;

        public IUser Users 
        {
            get
            {
                _users ??= new UserRepository(_context);
                return _users;
            }
        }

        public IRol Rols
        {
            get
            {
                _rols ??= new RolRepository(_context);
                return _rols;
            }
        }

        public IRefreshToken RefreshToken
        {
            get
            {
                _refreshToken ??= new RefreshTokenRepository(_context);
                return _refreshToken;
            }
        }

        public ICita Cita
        {
            get
            {
                _citas ??= new CitaRepository(_context);
                return _citas;
            }
        }

        public IDetalleMovimiento DetalleMovimiento
        {
            get
            {
                _detalleMovimientos ??= new DetalleMovimientoRepository(_context);
                return _detalleMovimientos;
            }
        }

        public IEspecialidad Especialidad
        {
            get
            {
                _especialidades ??= new EspecialidadRepository(_context);
                return _especialidades;
            }
        }

        public IEspecie Especie
        {
            get
            {
                _especies ??= new EspecieRepository(_context);
                return _especies;
            }
        }

        public ILaboratorio Laboratorio
        {
            get
            {
                _laboratorios ??= new LaboratorioRepository(_context);
                return _laboratorios;
            }
        }
        public IMascota Mascota
        {
            get
            {
                _mascotas ??= new MascotaRepository(_context);
                return _mascotas;
            }
        }

        public IMedicamento Medicamento
        {
            get
            {
                _medicamentos ??= new MedicamentoRepository(_context);
                return _medicamentos;
            }
        }

        public IMovimientoMedicamento MovimientoMedicamento
        {
            get
            {
                _movimientoMedicamento ??= new MovimientoMedicamentoRepository(_context);
                return _movimientoMedicamento;
            }
        }

        public IPropietario Propietario
        {
            get
            {
                _propietarios ??= new PropietarioRepository(_context);
                return _propietarios;
            }
        }

        public IRaza Raza
        {
            get
            {
                _razas ??= new RazaRepository(_context);
                return _razas;
            }
        }

        public ITipoMovimiento TipoMovimiento
        {
            get
            {
                _tipoMovimientos ??= new TipoMovimientoRepository(_context);
                return _tipoMovimientos;
            }
        }

        public ITratamientoMedico TratamientoMedico
        {
            get
            {
                _tratamientoMedicos ??= new TratamientoMedicoRepository(_context);
                return _tratamientoMedicos;
            }
        }

        public IVeterinario Veterinario
        {
            get
            {
                _veterinarios ??= new VeterinarioRepository(_context);
                return _veterinarios;
            }
        }

        public IProveedor Proveedor
        {
            get
            {
                _proveedores ??= new ProveedorRepository(_context);
                return _proveedores;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}