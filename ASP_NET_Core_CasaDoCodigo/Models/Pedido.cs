using System.Collections.Generic;

namespace ASP_NET_Core_CasaDoCodigo.Models
{
    public class Pedido : BaseModel
    {
        public List<ItemPedido> Itens { get; private set; }

        public Pedido()
        {
            Itens = new List<ItemPedido>();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }

        public string Municipio { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
    }
}
