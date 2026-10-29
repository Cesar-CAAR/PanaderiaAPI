namespace PanaderiaAPI.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string TemperaturaHorneado { get; set; } = string.Empty;

        public List<Ingrediente> Ingredientes { get; set; } = new();
    }
}