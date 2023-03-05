using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Repositories.Interface;

namespace mvc.Controllers
{
    public class PedidoController : Controller
    {
        //criandocampo para acessar o repositório
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        //construtor para utilização dos métodos 
        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            this._produtoRepository = produtoRepository;
            this._pedidoRepository = pedidoRepository;
        }

        public IActionResult Principal()
        {
            //utilizando o método get proutos para listar os produtos
            return View(_produtoRepository.GetProdutos());  
        }
        public IActionResult Carrinho(string codigo)
        {
            //se o id passado for diferente de nulo, adicione um pedido 
            if (!string.IsNullOrEmpty(codigo))
            {
                _pedidoRepository.AddItem(codigo);
               
            }
            Pedido pedido = _pedidoRepository.GetPedido();
            return View(pedido.Itens);
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Resumo()
        {
            Pedido pedido = _pedidoRepository.GetPedido();

            return View(pedido);
        }
    }
}
