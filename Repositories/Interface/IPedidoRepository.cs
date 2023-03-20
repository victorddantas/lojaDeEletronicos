using mvc.Models;

namespace mvc.Repositories.Interface
{
    public interface IPedidoRepository
    {
        void AddItem(string codigo);
        Pedido GetPedido();
        public int? GetPedidoId();
        public void setPedidoId(int pedidoId);
        UpdateQtdResponse updateQtd(ItemPedido itemPedido);
        Pedido UpdateCadastro(Cadastro cadastro);
    }
}
