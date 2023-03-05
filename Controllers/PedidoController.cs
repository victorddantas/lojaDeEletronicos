using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Principal()
        {
            return View();  
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
