namespace TextilCorp.Models
{
    public class Ventas
    {
        public int VentasId { get; set; }
        public float MontoTotal { get; set; }
        public int Telefono { get; set; }
        public string? Direccion { get; set; }

        public int ClientesId { get; set; }
        public Clientes? Clientes { get; set; }

        public int ProductosId { get; set; }
        public Productos? Productos { get; set; }
    }
}
