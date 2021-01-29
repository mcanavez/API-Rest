using RestWithASPNETMesaRadionica.Model;
using System.Collections.Generic;

namespace RestWithASPNETMesaRadionica.Repository.Generic
{
    public interface IConsulenteRepository : IRepository<Consulente>
    {
        Consulente Disable(long id);

        List<Consulente> FindByName(string nome, string sobrenome);
    }
}
