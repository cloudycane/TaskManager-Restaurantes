﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManager.Infraestructura.Data;

#nullable disable

namespace TaskManager.Infraestructura.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250110133555_EliminarRelacionEntreEntidadesIngredientesyProductosParaVenderModel")]
    partial class EliminarRelacionEntreEntidadesIngredientesyProductosParaVenderModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TaskManager.Dominio.Entidades.CompraProductoSuministradorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CIF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronicoEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionLinea1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionLinea2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoDeCompra")
                        .HasColumnType("int");

                    b.Property<string>("FacturacionID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDeEmision")
                        .HasColumnType("datetime2");

                    b.Property<double?>("GastosDeEnvio")
                        .HasColumnType("float");

                    b.Property<double?>("GastosDeMantenimiento")
                        .HasColumnType("float");

                    b.Property<string>("Localidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MetodoDePago")
                        .HasColumnType("int");

                    b.Property<string>("NombreLegalDeLaEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrdenAdquisicionId")
                        .HasColumnType("int");

                    b.Property<string>("PaginaWebEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("TasaDeDescuento")
                        .HasColumnType("float");

                    b.Property<double?>("TasaDeIva")
                        .HasColumnType("float");

                    b.Property<double?>("TasaDeTransporte")
                        .HasColumnType("float");

                    b.Property<string>("TelefonoEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TerminosPago")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdenAdquisicionId");

                    b.ToTable("CompraProductoSuministradorFacturacion");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.IngrendientesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingrendientes");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.InventarioMateriaPrimaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CantidadProductoEnInventario")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaProductoInventario")
                        .HasColumnType("int");

                    b.Property<int>("CompraProductoSuministradorId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoProductoInventario")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDistribucion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompraProductoSuministradorId");

                    b.ToTable("InventarioMateriaPrimas");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.OrdenAdquisicionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CantidadDeOrden")
                        .HasColumnType("int");

                    b.Property<int?>("CompraProductoSuministradorModelId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("HoraDeCreacion")
                        .HasColumnType("time");

                    b.Property<double>("PrecioTotal")
                        .HasColumnType("float");

                    b.Property<int>("ProductoSuministradorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompraProductoSuministradorModelId");

                    b.HasIndex("ProductoSuministradorId");

                    b.ToTable("OrdenesAdquisicion");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.ProductosParaVenderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProducto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ProductosParaVender");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.ProductoSuministradorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CantidadProductoEnVenta")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaProductoSuministradorEnum")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionProducto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("OrdenAdquisicionModelId")
                        .HasColumnType("int");

                    b.Property<double>("PrecioProducto")
                        .HasColumnType("float");

                    b.Property<int>("SuministradorId")
                        .HasColumnType("int");

                    b.Property<int>("UnidadProductoEnum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdenAdquisicionModelId");

                    b.HasIndex("SuministradorId");

                    b.ToTable("ProductosSuministradores");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.ReservacionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoReservacionEnum")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechadeReservacion")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("HoradeReservacion")
                        .HasColumnType("time");

                    b.Property<int>("MesasEnum")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reservaciones");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.SuministradorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DireccionLinea1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DireccionLinea2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Localidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ProductoSuministradorModelId")
                        .HasColumnType("int");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProductoSuministradorModelId");

                    b.ToTable("Suministradores");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.CompraProductoSuministradorModel", b =>
                {
                    b.HasOne("TaskManager.Dominio.Entidades.OrdenAdquisicionModel", "OrdenAdquisicion")
                        .WithMany()
                        .HasForeignKey("OrdenAdquisicionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdenAdquisicion");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.InventarioMateriaPrimaModel", b =>
                {
                    b.HasOne("TaskManager.Dominio.Entidades.CompraProductoSuministradorModel", "CompraProductoSuministrador")
                        .WithMany()
                        .HasForeignKey("CompraProductoSuministradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompraProductoSuministrador");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.OrdenAdquisicionModel", b =>
                {
                    b.HasOne("TaskManager.Dominio.Entidades.CompraProductoSuministradorModel", null)
                        .WithMany("Ordenes")
                        .HasForeignKey("CompraProductoSuministradorModelId");

                    b.HasOne("TaskManager.Dominio.Entidades.ProductoSuministradorModel", "ProductoSuministrador")
                        .WithMany()
                        .HasForeignKey("ProductoSuministradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductoSuministrador");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.ProductoSuministradorModel", b =>
                {
                    b.HasOne("TaskManager.Dominio.Entidades.OrdenAdquisicionModel", null)
                        .WithMany("Productos")
                        .HasForeignKey("OrdenAdquisicionModelId");

                    b.HasOne("TaskManager.Dominio.Entidades.SuministradorModel", "Suministrador")
                        .WithMany()
                        .HasForeignKey("SuministradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Suministrador");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.SuministradorModel", b =>
                {
                    b.HasOne("TaskManager.Dominio.Entidades.ProductoSuministradorModel", null)
                        .WithMany("SuministradorList")
                        .HasForeignKey("ProductoSuministradorModelId");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.CompraProductoSuministradorModel", b =>
                {
                    b.Navigation("Ordenes");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.OrdenAdquisicionModel", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("TaskManager.Dominio.Entidades.ProductoSuministradorModel", b =>
                {
                    b.Navigation("SuministradorList");
                });
#pragma warning restore 612, 618
        }
    }
}
