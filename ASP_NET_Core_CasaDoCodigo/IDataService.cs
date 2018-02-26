using ASP_NET_Core_CasaDoCodigo.Models;
using System.Collections.Generic;

namespace ASP_NET_Core_CasaDoCodigo
{
    public interface IDataService
    {
        void InicializaDB();
        List<Produto> GetProdutos();
        List<ItemPedido> GetItensPedido();
        UpdateItemPedidoResponse UpdateItemPedido(ItemPedido itemPedido);
        void AddItemPedido (int produtoId);
        Pedido GetPedido();
    }
}