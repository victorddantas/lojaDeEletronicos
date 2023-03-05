using Microsoft.EntityFrameworkCore;
using mvc.Models;
using mvc.Repositories.Interface;
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
    }
}
