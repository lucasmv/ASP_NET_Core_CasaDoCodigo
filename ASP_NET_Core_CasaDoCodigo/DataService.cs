using ASP_NET_Core_CasaDoCodigo.Models;
using ASP_NET_Core_CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_Core_CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly Contexto _contexto;
        private readonly IHttpContextAccessor _contextAccessor;
        public DataService(Contexto contexto, IHttpContextAccessor contextAccessor)
        {
            _contexto = contexto;
            _contextAccessor = contextAccessor;
        }

        public void AddItemPedido(int produtoId)
        {
            var produto = _contexto.Produtos.SingleOrDefault(x => x.Id == produtoId);

            if (produto != null)
            {
                int? pedidoId = GetSessionPedidoId();

                Pedido pedido = null;

                if (pedidoId.HasValue)
                    pedido = _contexto.Pedidos.Where(x => x.Id == pedidoId).SingleOrDefault();

                if (pedido == null)
                    pedido = new Pedido();

                if (!_contexto.ItensPedido.Any(x => x.Pedido.Id == pedido.Id && x.Produto.Id == produtoId))
                {
                    _contexto.ItensPedido.Add(new ItemPedido(pedido, produto, 1));
                    _contexto.SaveChanges();
                    SetSessionPedidoId(pedido);
                }
            }
        }

        private void SetSessionPedidoId(Pedido pedido)
        {
            _contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedido.Id);
        }

        private int? GetSessionPedidoId()
        {
            return _contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        public List<ItemPedido> GetItensPedido()
        {
            var pedidoId = GetSessionPedidoId();
            var pedido = _contexto.Pedidos.Where(x=>x.Id == pedidoId.Value).Single();
            return _contexto.ItensPedido.Where(x => x.Pedido.Id == pedido.Id).Include("Produto").ToList();
        }

        public List<Produto> GetProdutos()
        {
            return _contexto.Produtos.ToList();
        }

        public void InicializaDB()
        {
            this._contexto.Database.EnsureCreated();

            if (_contexto.Produtos.Count() == 0)
            {
                List<Produto> produtos = new List<Produto>
                {
                    new Produto("Sleep not found", 59.90m),
                    new Produto("May the code be with you", 59.90m),
                    new Produto("Rollback", 59.90m),
                    new Produto("REST", 69.90m),
                    new Produto("Design Patterns com Java", 69.90m),
                    new Produto("Vire o jogo com Spring Framework", 69.90m),
                    new Produto("Test-Driven Development", 69.90m),
                    new Produto("iOS: Programe para iPhone e iPad", 69.90m),
                    new Produto("Desenvolvimento de Jogos para Android", 69.90m)
                };

                foreach (var produto in produtos)
                {
                    this._contexto.Produtos.Add(produto);

                    //this._contexto.ItensPedido.Add(new ItemPedido(produto, 1));
                }

                this._contexto.SaveChanges();
            }
        }

        public UpdateItemPedidoResponse UpdateItemPedido(ItemPedido itemPedido)
        {
            var itemPedidoDB = _contexto.ItensPedido.Where(x => x.Id == itemPedido.Id).SingleOrDefault();
            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                if (itemPedido.Quantidade == 0)
                    _contexto.ItensPedido.Remove(itemPedidoDB);

                _contexto.SaveChanges();
            }

            var itensPedidos = _contexto.ItensPedido.ToList();

            var carrinhoViewModel = new CarrinhoViewModel(itensPedidos);

            return new UpdateItemPedidoResponse(itemPedidoDB, carrinhoViewModel);
        }

        public Pedido GetPedido()
        {
            int? pedidoId = GetSessionPedidoId();

            return _contexto.Pedidos.Where(p => p.Id == pedidoId).SingleOrDefault();
        }
    }
}
