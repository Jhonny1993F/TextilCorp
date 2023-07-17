using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TextilCorp.Models;

namespace TextilCorp.Data
{
    public class TextilCorpContext : DbContext
    {
        public TextilCorpContext (DbContextOptions<TextilCorpContext> options)
            : base(options)
        {
        }

        public DbSet<TextilCorp.Models.Ventas> Ventas { get; set; } = default!;

        public DbSet<TextilCorp.Models.Usuarios>? Usuarios { get; set; }

        public DbSet<TextilCorp.Models.Productos>? Productos { get; set; }

        public DbSet<TextilCorp.Models.Marcas>? Marcas { get; set; }

        public DbSet<TextilCorp.Models.Clientes>? Clientes { get; set; }

        public DbSet<TextilCorp.Models.Categorias>? Categorias { get; set; }

        public DbSet<TextilCorp.Models.Carrito>? Carrito { get; set; }
    }
}
