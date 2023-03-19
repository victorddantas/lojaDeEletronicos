using System.Collections.Generic;
using System.Linq;

namespace mvc.Models.ViewModels
{
    //A view model permite a criação de uma classe de modelo específica para cada view, onde não é necessário que essa classe seja persistida, ela será responsável apenas pela 
    //exibição dos conteúdo. Isso permite criarmos uma classe de modelo para exbir na view apenas os dados que quisermos sem realizar qualquer alteração nas entidades de modelo da aplicação.

    public class CarrinhoViewModel
    {
        //propriedade para fornecer a lista de intesns de pedido a view 

        public IList<ItemPedido> Itens { get; }
        public ItemPedido PrecoUnitario;


        public CarrinhoViewModel(IList<ItemPedido> itens)
        {
            Itens = itens;
        }



        //método para calcular o total na view
        
        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);

    }
}
