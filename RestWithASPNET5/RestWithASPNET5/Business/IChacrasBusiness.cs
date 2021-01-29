using RestWithASPNETMesaRadionica.Model;
using System;
using System.Collections.Generic;

namespace RestWithASPNETMesaRadionica.Business
{
    public interface IChacrasBusiness
    {
        Chacras Create(Chacras chacras);
        Chacras Update(Chacras chacras);
        void Delete(long id);
        List<Chacras> ReturnAll();
        bool Exists(long id);
        Chacras FindById(long id);
    }
}
