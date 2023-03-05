using Microsoft.EntityFrameworkCore;
using mvc.Models;
using mvc.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using static mvc.Repositories.ProdutoRepository;

namespace mvc
{
    class DataService : IDataService
    {

        //propriedade para acessar o contexto para criar o banco 
        private readonly mvcContext _context;

        //Propriedade para acessar o reposítorio(classe especializada em realizar alterações dos dados) 
        private readonly IProdutoRepository _produtoRepository;


        //Ao inicializar o Dataservice o contexto e o Repsitório se torna obrigatório. A instancia do Objeto DataService e IProdutoRepository será resposabilidade do asp.net através da injeção de dependência 
        //(O mvcContext automáticamente é gerado pela injeção de dependência)
        public DataService(mvcContext context, IProdutoRepository produtoRepository)
        {
            this._context = context;
            this._produtoRepository = produtoRepository;

        }

        #region Método para carregar os dados do catálogo inicial de produtos

        public void InicializaDb()
        {
            _context.Database.Migrate();

            List<AtributosProdutos> produtos = GetProdutos();
            _produtoRepository.SaveProdutos(produtos);
        }
        #endregion

        #region lendo os dados de produto.json pra incluir no banco
        private static List<AtributosProdutos> GetProdutos()
        {
            var json = File.ReadAllText("produtos.json");

            //convertendo um json em uma lista de objetos
            var produtos = JsonConvert.DeserializeObject<List<AtributosProdutos>>(json);
            return produtos;
        }

        #endregion

    }



}
