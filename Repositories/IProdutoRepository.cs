using System.Collections.Generic;

namespace mvc.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<ProdutoRepository.AtributosProdutos> produtos);
    }
}