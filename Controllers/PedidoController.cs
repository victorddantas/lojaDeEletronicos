using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Models.ViewModels;
using mvc.Repositories.Interface;
using System.Collections.Generic;

namespace mvc.Controllers
{
    public class PedidoController : Controller
    {
        //criandocampo para acessar o repositório
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;   

        //construtor para utilização dos métodos 
        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            this._produtoRepository = produtoRepository;
            this._pedidoRepository = pedidoRepository;
            this._itemPedidoRepository = itemPedidoRepository;
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

            //Como o controller retorna as view, é necessário criar uma instância da viweModel, passando como parâmetro (definido no construtor da viewModel) uma variável
            //do tipo necessário(no caso abaixo uma lista de item pedido).

            List<ItemPedido> itens = _pedidoRepository.GetPedido().Itens;

            //passando a viewModel que irá receber uma lita de intemPedido 
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return View(carrinhoViewModel);
        }
        public IActionResult Cadastro()
        {
            //obtendo o pedido para acessar o objeto cadastro 
           var pedido =  _pedidoRepository.GetPedido();


            //o cliente só pode acessar a página de cadastro através do pedido 
            if (pedido == null)
            {
                RedirectToAction("Principal");
            }

            //retornando a view de cadastro 
            return View(pedido.Cadastro);
        }
        public IActionResult Resumo()
        {
            Pedido pedido = _pedidoRepository.GetPedido();

            return View(pedido);
        }

        [HttpPost]
        public UpdateQtdResponse UpdateQtd([FromBody]ItemPedido itemPedido) //para enviar  as requisições, no parâmetro será enviado um objeto que conterá o id e a quantidade do item (nesse caso será passado no corpo da requisição [FromBody])
        {

            //irá retonar para o ajax o itemPedido alaterado 
           return _pedidoRepository.updateQtd(itemPedido);


        }

    }
}
