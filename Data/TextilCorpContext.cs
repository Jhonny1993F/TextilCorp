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

        public DbSet<TextilCorp.Models.Carrito> Carrito { get; set; } = default!;

        public DbSet<TextilCorp.Models.Categoria>? Categoria { get; set; }

        public DbSet<TextilCorp.Models.Cliente>? Cliente { get; set; }

        public DbSet<TextilCorp.Models.Marca>? Marca { get; set; }

        public DbSet<TextilCorp.Models.Producto>? Producto { get; set; }

        public DbSet<TextilCorp.Models.Usuario>? Usuario { get; set; }

        public DbSet<TextilCorp.Models.Venta>? Venta { get; set; }
    }
}
