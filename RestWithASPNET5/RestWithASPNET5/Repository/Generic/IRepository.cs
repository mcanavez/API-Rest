using RestWithASPNETMesaRadionica.Model;
using RestWithASPNETMesaRadionica.Model.Base;
using System.Collections.Generic;

namespace RestWithASPNETMesaRadionica.Repository

{
    public interface IRepository<T> where T: BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        T Update(T item);
        void Delete(long id);
        List<T> ReturnAll();
        bool Exists(long id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);

    }
}
