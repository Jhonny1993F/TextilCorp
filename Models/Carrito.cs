namespace TextilCorp.Models
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        public int Cantidad { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Clientes { get; set; }

        public int ProductoId { get; set; }
        public Producto? Productos { get; set; }
    }
}
