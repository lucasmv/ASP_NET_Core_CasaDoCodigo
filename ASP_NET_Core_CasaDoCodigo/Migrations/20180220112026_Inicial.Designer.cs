using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ASP_NET_Core_CasaDoCodigo;

namespace ASP_NET_Core_CasaDoCodigo.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20180220112026_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASP_NET_Core_CasaDoCodigo.Models.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("PrecoUnitario");

                    b.Property<int?>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItensPedido");
                });

            modelBuilder.Entity("ASP_NET_Core_CasaDoCodigo.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<decimal>("Preco");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ASP_NET_Core_CasaDoCodigo.Models.ItemPedido", b =>
                {
                    b.HasOne("ASP_NET_Core_CasaDoCodigo.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");
                });
        }
    }
}
