namespace TextilCorp.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public bool Stock { get; set; }
        public byte[]? Imagen { get; set; }

        public int MarcaId { get; set; }
        public Marca? Marcas { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categorias { get; set; }
    }
}
