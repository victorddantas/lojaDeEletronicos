using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Repositories
{
    //criando uma classe genérica que será utilizada por todos o repositórios 
    public class BaseRepository<T> where T : BaseModel 
    {
        //O campo que irá representar o contexto para acesso manipulação de dados
        protected  readonly mvcContext _context;

        //Um campo que vai representar o conjunto de objetos definidos na classe (equivale a tabela no banco)
        protected readonly DbSet<T> _produtos;

        //Ao inicializar o Repository o contexto se torna obrigatório. A instancia do Objeto Repository será responsabilidade do asp.net através da injeção de dependência 
        //(O mvcContext automáticamente é gerado pela injeção de dependência)
        public BaseRepository(mvcContext context)
        {
            this._context = context;
            this. _produtos = context.Set<T>();
        }
    }
}
