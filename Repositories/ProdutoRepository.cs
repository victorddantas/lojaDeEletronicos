using mvc.Models;
using System.Collections.Generic;

namespace mvc.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly mvcContext context;

        //Ao inicializar o ProdutoRepository o contexto se torna obrigatório. A instancia do Objeto ProdutoRepository será resposabilidade do asp.net através da injeção de dependência 
        //(O mvcContext automáticamente é gerado pela injeção de dependência)
        public ProdutoRepository(mvcContext context)
        {
            this.context = context;
        }

        public void SaveProdutos(List<AtributosProdutos> produtos)
        {
            //percorrendo a lista de produtos para inserir no banco
            foreach (var item in produtos)
            {
                context.Set<Produto>().Add(new Produto(item.Codigo, item.Nome, item.Preco));

            }
            context.SaveChanges();
        }

        public class AtributosProdutos
        {
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }
        }
    }
}
