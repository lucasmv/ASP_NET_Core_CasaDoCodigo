using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Carrinho()
        {
            var viewModel = GetCarrinhoViewModel();

            return View(viewModel);
        }

        public IActionResult Resumo()
        {
            var viewModel = GetCarrinhoViewModel();

            return View(viewModel);
        }
    }
}