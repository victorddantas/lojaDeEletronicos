using mvc.Models.ViewModels;

namespace mvc.Models
{
    //classe resposável por retornae as resposta item de pedido que foi alterado no método UpdateQtd, pois no ajax a tela não atualiza a tela quando clicamos no botão de incremento
    //ou decremento. Nesse caso o ajax precisa receber a informação contendo o item que foi alterado.
    public class UpdateQtdResponse
    {
        //propriedade responsável por retornar o itemPedido 
        public ItemPedido _itemPedido { get;}

        //propriedade responsável por retornar o carrinho com os totais
        public CarrinhoViewModel _carrinhoViewModel{ get;}

        public UpdateQtdResponse(ItemPedido itemPedido, CarrinhoViewModel carrinhoViewModel)
        {
            _itemPedido = itemPedido;
            _carrinhoViewModel = carrinhoViewModel;
        }
    }
}
