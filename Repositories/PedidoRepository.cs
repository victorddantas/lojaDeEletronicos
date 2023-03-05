using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using mvc.Models;
using mvc.Repositories.Interface;
using System;
using System.Linq;

namespace mvc.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        //Criando campo para acessar o objeto da sessão para obter o id passado na sessão
        private readonly IHttpContextAccessor _contextAccessor;

        public PedidoRepository(mvcContext context, IHttpContextAccessor contextAccessor) : base(context)
        {
            this._contextAccessor = contextAccessor; 
        }


        //método para obter o id do pedido na seesão para adicionar o produto no carrinho
        public int? GetPedidoId()
        {
            return _contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        //método pra graver o ID

        public void setPedidoId(int pedidoId)
        {
            _contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }


        //Método para obter pedido
        public Pedido GetPedido()
        {
            //consulta a tabela de pedidos e verifica se o id consta lá, se não cria um novo pedido e retornar
            var pedidoId = GetPedidoId();
            var pedido = _produtos.Include(p => p.Itens).ThenInclude(i => i.Produto).Where(p => p.Id == pedidoId).SingleOrDefault(); //o SingleOrDefault irá trazer o dado caso exista, se não trará nulo sem dar erro
            
            if (pedido == null)
            {
                pedido = new Pedido();
                _produtos.Add(pedido);
                _context.SaveChanges();

                //gravando o id na sessão para evitar a crição de um novo pedido  
                setPedidoId(pedido.Id);

            }
            
            return pedido;
        
        }

        //Método para adicionar item no carrinho 

        public void AddItem(string codigo)
        {
            //verificando se o produto existe no banco 
          var produto =  _context.Set<Produto>().Where(p => p.Codigo == codigo).SingleOrDefault();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            //se existir adiciona como item de pedido 
            var pedido = GetPedido();

            //consultando se o item de pedido não existe 
            var itemPedido = _context.Set<ItemPedido>().Where(i => i.Produto.Codigo == codigo && i.Pedido == pedido).SingleOrDefault(); ;


            if (itemPedido == null)
            {
                //adicionando item pedido 
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                _context.Set<ItemPedido>().Add(itemPedido);

                _context.SaveChanges();
            }
        }
    }
}
