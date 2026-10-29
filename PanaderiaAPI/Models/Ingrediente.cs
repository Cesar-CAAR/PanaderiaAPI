namespace PanaderiaAPI.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
    }
}