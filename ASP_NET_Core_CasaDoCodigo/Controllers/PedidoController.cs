using ASP_NET_Core_CasaDoCodigo.Models;
using ASP_NET_Core_CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Core_CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {

        private readonly IDataService _dataService;

        public PedidoController(IDataService dataService)
        {
            _dataService = dataService;
        }

        private CarrinhoViewModel GetCarrinhoViewModel()
        {
            var itensCarrinho = _dataService.GetItensPedido();
            var viewModel = new CarrinhoViewModel(itensCarrinho);

            return viewModel;
        }

        public IActionResult Carrossel()
        {
            var produtos = _dataService.GetProdutos();

            return View(produtos);
        }

        public IActionResult Carrinho(int? produtoId)
        {
            if (produtoId.HasValue)
                _dataService.AddItemPedido(produtoId.Value);

            var viewModel = GetCarrinhoViewModel();

            return View(viewModel);
        }

        public IActionResult Resumo()
        {
            var viewModel = GetCarrinhoViewModel();

            return View(viewModel);
        }

        public IActionResult Cadastro()
        {
            var pedido = _dataService.GetPedido();

            if (pedido == null)
                return RedirectToAction("Carrossel");
            else
                return View(pedido);
        }

        [HttpPost]
        public UpdateItemPedidoResponse PostQuantidade([FromBody]ItemPedido itemPedido)
        {
            return _dataService.UpdateItemPedido(itemPedido);
        }
    }
}