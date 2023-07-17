namespace TextilCorp.Models
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        public int Cantidad { get; set; }

        public int ClientesId { get; set; }
        public Clientes? Clientes { get; set; }

        public int ProductosId { get; set; }
        public Productos? Productos { get; set; }
    }
}
