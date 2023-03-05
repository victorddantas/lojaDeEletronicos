using mvc.Models;
using mvc.Repositories.Interface;

namespace mvc.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {

        public PedidoRepository(mvcContext context) : base(context)
        {
        }
    }
}
