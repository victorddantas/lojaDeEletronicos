using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace mvc.Models
{
    [DataContract]
    public class ItemPedido : BaseModel
    {
        [Required]
        [DataMember]
        public Pedido Pedido { get; private set; }
       
        [Required]
        [DataMember]
        public Produto Produto { get; private set; }
    
        [Required]
        [DataMember]
        public int Quantidade { get; private set; }
        
        [Required]
        [DataMember]
        public decimal PrecoUnitario { get; private set; }

        public ItemPedido()
        {

        }

        public ItemPedido(Pedido pedido, Produto produto, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        //método para atualizar o valor do campo Quantidade 
        internal void UpdateQtdItem(int quantidade)
        {
            Quantidade = quantidade;
        }
    }

}
