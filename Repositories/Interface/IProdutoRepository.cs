using mvc.Models;
using System.Collections.Generic;

namespace mvc.Repositories.Interface
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<ProdutoRepository.AtributosProdutos> produtos);
        IList<Produto> GetProdutos();
    }
}