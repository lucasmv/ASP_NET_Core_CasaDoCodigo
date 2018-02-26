using ASP_NET_Core_CasaDoCodigo.Models;
using ASP_NET_Core_CasaDoCodigo.Models.ViewModels;

namespace ASP_NET_Core_CasaDoCodigo
{
    public class UpdateItemPedidoResponse
    {
        public ItemPedido ItemPedido { get; private set; }
        public CarrinhoViewModel CarrinhoViewModel { get; private set; }

        public UpdateItemPedidoResponse(ItemPedido itemPedido, CarrinhoViewModel carrinhoViewModel)
        {
            this.ItemPedido = itemPedido;
            this.CarrinhoViewModel = carrinhoViewModel;
        }
    }
}
