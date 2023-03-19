
class Carrinho {


    clickQtdIncremento(btn) {

        let data = this.getData(btn);
        data.Quantidade++;
        this.postCarrinho(data);
         window.location.reload(true);
       
       /* debugger;*/

    }
    clickQtdDecremento(btn) {

        let data = this.getData(btn);
        if (data.Quantidade > '0') {
            data.Quantidade--;
            this.postCarrinho(data);
        }
        else {

            alert("A quantidade mínima é 1")

        }
        window.location.reload(true);
       

    }


    updateTxtQtd(input) {

        let data = this.getData(input);

        this.postCarrinho(data);
        window.location.reload(true);
    }


    getData(element) {

        //definindo o objeto que conterá as informações enviadas
        var linhaDoItem = $(element).parents('[item-Id]')//acessando linha onde receberemos o id do produto ao clicar no botão (através da hierarquia - atributo pai) 
        var itemId = $(linhaDoItem).attr('item-Id')//obtendo o id do item através da hierarquia
        var novaQtde = $(linhaDoItem).find('input').val();//obtendo quantidade atual do item no input que está abaixo da hierarquia

        return  {
            Id: itemId,
            Quantidade: novaQtde
        };       

    }


    postCarrinho(data) {

         //criando ajax que será utilizado na requisição 

        $.ajax({

            url: '/pedido/UpdateQtd',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)

        }).done(function (response) {
            let itemPedido = response._itemPedido; //obtendo o itemPedido
            debugger
            let linhaDoItem = $('[item-Id=' + itemPedido.id + ']') //acessando linha onde receberemos o id do produto ao clicar no botão
            debugger
            linhaDoItem.find('input').val(itemPedido.quantidade);//obtendo quantidade atual do item no input que está abaixo da hierarquia
            linhaDoItem.find('[subtotal]').html((itemPedido.subtotal).duasCasas());//acessando linha onde está o subtotal e alterando html

            let carrinhoViewModel = response._carrinhoViewModel;
            $('[numero-itens]').html('Total: ' + carrinhoViewModel.itens.length + ' itens');//acessando linha onde está o numero-itens e alterando html 
            $('[total]').html((carrinhoViewModel.total).duasCasas());

            if (itemPedido.quantidade == 0) {
                linhaDoItem.remove();
                window.location.reload(true);
            }
        });
    }
    
}

var carrinho = new Carrinho();

//formatando número
Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.',',')
}