using System.Text.RegularExpressions;

namespace TextilCorp.Models
{
    public class Productos
    {
        public int ProductosId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public bool Stock { get; set; }
        public string? Imagen { get; set; }

        public int MarcasId { get; set; }
        public Marcas? Marcas { get; set; }

        public int CategoriasId { get; set; }
        public Categorias? Categorias { get; set; }
    }
}
