using Microsoft.EntityFrameworkCore;
using mvc.Models;
using mvc.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace mvc.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>,IItemPedidoRepository
    {
       
        //Irá passar o contexto para a classe base
        public ItemPedidoRepository(mvcContext context) : base(context)
        { 

        }

        //busacndo itemPedido por id e retornando para o método de atualização de quantidade 
        public ItemPedido GetItemPedido(int itemPedidodId)
        {
            return _produtos.Where(ip => ip.Id == itemPedidodId).SingleOrDefault();
        }

        public void RemoveItemPedido(int itemPedidoId)
        {
            _produtos.Remove(GetItemPedido(itemPedidoId));
        }
    }
}
