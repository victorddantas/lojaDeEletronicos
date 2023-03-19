
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
        if (data.Quantidade > '1') {
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

    }
    getData(element) {

        //definindo o objeto que conterá as informações enviadas
        var linhaDoItem = $(element).parents('[item-Id]')//acessando linha onde receberemos o id do produto ao clicar no botão (através da hierarquia - atributo pai) 
        var itemId = $(linhaDoItem).attr('item-Id')//obtendo o id do item através da hierarquia
        var novaQtde = $(linhaDoItem).find('input').val();//obtendo quantidade atual do item que está abaixo da hierarquia

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

        });
    }
    
}

var carrinho = new Carrinho();
 