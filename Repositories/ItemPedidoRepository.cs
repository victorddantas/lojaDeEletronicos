using Microsoft.EntityFrameworkCore;
using mvc.Models;
using mvc.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace mvc.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>,IItemPedidoRepository
    {
       
        //Irá passar o contexto para a classe base
        public ItemPedidoRepository(mvcContext context) : base(context)
        { 
        }

        //método para atualizar a quantidade no banco 

        public void updateQtd(ItemPedido itemPedido)
        {
            var itemPedidoDB = 
            _produtos.Where(ip => ip.Id == itemPedido.Id).SingleOrDefault();


            if (itemPedidoDB != null && itemPedido.Quantidade > 0)
            {
                itemPedidoDB.UpdateQtdItem(itemPedido.Quantidade);

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("A quantidade não pode ser menor ou igual a 0");
                
            }
        }
    }
}
