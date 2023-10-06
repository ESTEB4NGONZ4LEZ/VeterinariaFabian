
namespace API.Dtos.Medicamento
{
    public class MedicamentoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CantidadDisponible { get; set; }
        public double Precio { get; set; }
        public int LaboratorioId { get; set; }
    }
}