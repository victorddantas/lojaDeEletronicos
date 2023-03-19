using mvc.Models;

namespace mvc.Repositories.Interface
{
    public interface IItemPedidoRepository
    {
        ItemPedido GetItemPedido(int itemPedidodId);
        void RemoveItemPedido(int itemPedidoId);
    }
}
