using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_Core_CasaDoCodigo.Models.ViewModels
{
    public class CarrinhoViewModel
    {
        public List<ItemPedido> Itens { get; private set; }
        public decimal Total
        {
            get
            {
                return Itens.Sum(x => x.Subtotal);
            }
        }

        public CarrinhoViewModel(List<ItemPedido> itens)
        {
            Itens = itens;
        }
    }
}
