using ASP_NET_Core_CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Core_CasaDoCodigo
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
