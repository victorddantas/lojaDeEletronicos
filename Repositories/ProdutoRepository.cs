using Microsoft.EntityFrameworkCore;
using mvc.Models;
using mvc.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace mvc.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>,IProdutoRepository
    {
        //Irá passar o contexto para a classe base
        public ProdutoRepository(mvcContext context) : base(context)
        { 
        }

        #region Método Salvar 
        public void SaveProdutos(List<AtributosProdutos> produtos)
        {
            //percorrendo a lista de produtos para inserir no banco 
            foreach (var item in produtos)
            {
                //verificando se já existe os itens no banco
               
                if (!_produtos.Where(p => p.Codigo == item.Codigo).Any()) //se não obtver nenhum resultado na consulta dos produtos excuta a adição dos produtos
                {
                    _produtos.Add(new Produto(item.Codigo, item.Nome, item.Preco));
                }        

            }
            _context.SaveChanges();
        }
        #endregion

        #region Método Listar 
        public IList<Produto> GetProdutos()
        {
           return _produtos.ToList();
        }

        #endregion

        public class AtributosProdutos
        {
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }
        }
    }
}
