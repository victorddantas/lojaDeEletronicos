using Microsoft.AspNetCore.Mvc;
using mvc.Repositories.Interface;

namespace mvc.Controllers
{
    public class PedidoController : Controller
    {
        //criandocampo para acessar o repositório
        private readonly IProdutoRepository _produtoRepository;

        //construtor para utilização dos métodos 
        public PedidoController(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public IActionResult Principal()
        {
            //utilizando o método get proutos para listar os produtos
            return View(_produtoRepository.GetProdutos());  
        }
        public IActionResult Carrinho()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Resumo()
        {
            return View();
        }
    }
}
