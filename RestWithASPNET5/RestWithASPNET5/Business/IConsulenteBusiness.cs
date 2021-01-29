using System.Collections.Generic;
using RestWithASPNETMesaRadionica.Data.VO;
using RestWithASPNETMesaRadionica.HyperMedia.Utils;
using RestWithASPNETMesaRadionica.Model;

namespace RestWithASPNETMesaRadionica.Business
{
    public interface IConsulenteBusiness
    {
        ConsulenteVO Create(ConsulenteVO person);
        ConsulenteVO FindById(long id);
        ConsulenteVO Update(ConsulenteVO person);
        void Delete(long id);
        List<ConsulenteVO> ReturnAll();
        ConsulenteVO Disable(long id);
        List<ConsulenteVO> FindByName(string nome, string sobrenome);

        PagedSearchVO<ConsulenteVO> FindWithPagedSearch(
            string name, string sortDirection, int pageSize, int page);
    }
}
