﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TextilCorp.Data;

#nullable disable

namespace TextilCorp.Migrations
{
    [DbContext(typeof(TextilCorpContext))]
    partial class TextilCorpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TextilCorpWeb.Models.Carrito", b =>
                {
                    b.Property<int>("CarritoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarritoId"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ClientesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductosId")
                        .HasColumnType("int");

                    b.HasKey("CarritoId");

                    b.HasIndex("ClientesId");

                    b.HasIndex("ProductosId");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("TextilCorpWeb.Models.Categorias", b =>
                {
                    b.Property<int>("CategoriasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriasId"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriasId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("TextilCorpWeb.Models.Clientes", b =>
                {
                    b.Property<int>("ClientesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientesId"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("ClientesId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("TextilCorpWeb.Models.Marcas", b =>
                {
                    b.Property<int>("MarcasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarcasId"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarcasId");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("TextilCorpWeb.Models.Productos", b =>
                {
                    b.Property<int>("ProductosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductosId"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CategoriasId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarcasId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<bool>("Stock")
                        .HasColumnType("bit");

                    b.HasKey("ProductosId");

                    b.HasIndex("CategoriasId");

                    b.HasIndex("MarcasId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("TextilCorpWeb.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuariosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuariosId"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("UsuariosId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TextilCorpWeb.Models.Ventas", b =>
                {
                    b.Property<int>("VentasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VentasId"), 1L, 1);

                    b.Property<int>("ClientesId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("MontoTotal")
                        .HasColumnType("real");

                    b.Property<int>("ProductosId")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("VentasId");

                    b.HasIndex("ClientesId");

                    b.HasIndex("ProductosId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("TextilCorpWeb.Models.Carrito", b =>
                {
                    b.HasOne("TextilCorpWeb.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TextilCorpWeb.Models.Productos", "Productos")
                        .WithMany()
                        .HasForeignKey("ProductosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("TextilCorpWeb.Models.Productos", b =>
                {
                    b.HasOne("TextilCorpWeb.Models.Categorias", "Categorias")
                        .WithMany()
                        .HasForeignKey("CategoriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TextilCorpWeb.Models.Marcas", "Marcas")
                        .WithMany()
                        .HasForeignKey("MarcasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorias");

                    b.Navigation("Marcas");
                });

            modelBuilder.Entity("TextilCorpWeb.Models.Ventas", b =>
                {
                    b.HasOne("TextilCorpWeb.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TextilCorpWeb.Models.Productos", "Productos")
                        .WithMany()
                        .HasForeignKey("ProductosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}