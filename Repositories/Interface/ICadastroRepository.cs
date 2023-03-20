using mvc.Models;

namespace mvc.Repositories.Interface
{
    public interface ICadastroRepository
    {
        Cadastro Update(int cadastroId, Cadastro cadastro);
    }
}
