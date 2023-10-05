﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using concessionaria_WEBAPI.Data;

#nullable disable

namespace concessionaria_WEBAPI.Migrations
{
    [DbContext(typeof(ConcessionariaDBContext))]
    partial class ConcessionariaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("concessionaria_WEBAPI.Models.ClienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<long>("Telefone")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("concessionaria_WEBAPI.Models.OficinaModel", b =>
                {
                    b.Property<int>("IdCarroOficina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Procedimento")
                        .IsRequired()
                        .HasMaxLength(511)
                        .HasColumnType("TEXT");

                    b.HasKey("IdCarroOficina");

                    b.ToTable("Oficina");
                });

            modelBuilder.Entity("concessionaria_WEBAPI.Models.PedidoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("DataHoraPedido")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ValorCompra")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
