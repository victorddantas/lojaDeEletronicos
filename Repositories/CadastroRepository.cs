using Microsoft.EntityFrameworkCore;
using mvc.Models;
using mvc.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace mvc.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        //Irá passar o contexto para a classe base
        public CadastroRepository(mvcContext context) : base(context)
        { 

        }

        //metodo para atualizar o cadastro (será feito através do pedido)
        public Cadastro Update(int cadastroId, Cadastro novoCadastro)
        {
            //obtendo cadastro do banco
            var cadastroDb = _produtos.Where(c => c.Id == cadastroId).SingleOrDefault();


            if (cadastroDb == null)
            {
                throw new ArgumentNullException("cadastro");
            }

            cadastroDb.Update(novoCadastro);

            _context.SaveChanges();

            return cadastroDb;
        }
    }
}
