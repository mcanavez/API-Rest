using RestWithASPNETMesaRadionica.Model;
using RestWithASPNETMesaRadionica.Repository;
using System;
using System.Collections.Generic;

namespace RestWithASPNETMesaRadionica.Business.Implementatios
{
    public class ChacrasBusinessImplementation : IChacrasBusiness
    {
        private readonly IRepository<Chacras> _repository;

        public ChacrasBusinessImplementation(IRepository<Chacras> repository)
        {
            _repository = repository;
        }

        public Chacras Create(Chacras chacras)
        {
           return  _repository.Create(chacras);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public bool Exists(long id)
        {
           return  _repository.Exists(id);
        }

        public Chacras FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Chacras> ReturnAll()
        {
            return _repository.ReturnAll();
        }

        public Chacras Update(Chacras chacras)
        {
            return _repository.Update(chacras);
        }
    }
}
