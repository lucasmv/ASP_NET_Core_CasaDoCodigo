using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ASP_NET_Core_CasaDoCodigo.Models
{

    public class ItemPedido : BaseModel       
    {
        [DataMember]
        [Required]
        public Pedido Pedido { get; private set; }

        [DataMember]
        [Required]
        public Produto Produto { get; private set; }

        [DataMember]
        public int Quantidade { get; private set; }

        [DataMember]
        public decimal PrecoUnitario { get; private set; }

        [DataMember]
        public decimal Subtotal
        {
            get
            {
                return Quantidade * PrecoUnitario;
            }
        }

        public ItemPedido(int id, Pedido pedido, Produto produto, int quantidade) : this(pedido, produto, quantidade)
        {
            this.Id = id;
        }

        public ItemPedido(Pedido pedido, Produto produto, int quantidade)
        {
            this.Pedido = pedido;
            this.Produto = produto;
            this.Quantidade = quantidade;
            this.PrecoUnitario = produto.Preco;
        }

        public ItemPedido()
        {

        }

        public void AtualizaQuantidade(int quantidade)
        {
            this.Quantidade = quantidade;
        }
    }
}
