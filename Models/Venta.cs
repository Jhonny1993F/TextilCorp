using System.Security.Principal;

namespace TextilCorp.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        public float MontoTotal { get; set; }
        public int Telefono { get; set; }
        public string? Direccion { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Clientes { get; set; }

        public int ProductoId { get; set; }
        public Producto? Productos { get; set; }

    }
}
