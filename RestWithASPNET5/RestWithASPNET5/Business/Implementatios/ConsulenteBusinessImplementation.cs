using RestWithASPNETMesaRadionica.Data.Converter.Implementations;
using RestWithASPNETMesaRadionica.Data.VO;
using RestWithASPNETMesaRadionica.HyperMedia.Utils;
using RestWithASPNETMesaRadionica.Model;
using RestWithASPNETMesaRadionica.Repository;
using RestWithASPNETMesaRadionica.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETMesaRadionica.Business.Implementatios
{
    public class ConsulenteBusinessImplementation : IConsulenteBusiness
    {

        private readonly IConsulenteRepository _repository;
        private readonly ConsulenteConverter _converter;

        public ConsulenteBusinessImplementation(IConsulenteRepository repository) {
            _repository = repository;
            _converter = new ConsulenteConverter();
        }

        public ConsulenteVO Create(ConsulenteVO consulente)
        {
            var personEntity = _converter.Parser(consulente);            
            personEntity = _repository.Create(personEntity);
            return _converter.Parser(personEntity);
                      
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public ConsulenteVO Disable(long id)
        {
             var consulenteEntity =  _repository.Disable(id);
             return _converter.Parser(consulenteEntity);
        }

        public ConsulenteVO FindById(long id)
        {
            return _converter.Parser(_repository.FindById(id));
        }

        public List<ConsulenteVO> FindByName(string nome, string sobrenome)
        {
            return _converter.Parser(_repository.FindByName(nome, sobrenome));
        }

        public PagedSearchVO<ConsulenteVO> FindWithPagedSearch(string nome, string sortDirection, int pageSize, int page)
        {
                var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
                var size = (pageSize < 1) ? 10 : pageSize;
                var offset = page > 0 ? (page - 1) * size : 0;

                string query = @"select * from consulente p where 1 = 1 ";
                if (!string.IsNullOrWhiteSpace(nome)) query = query + $" and p.nome like '%{nome}%' ";
                query += $" order by p.nome {sort} limit {size} offset {offset}";

                string countQuery = @"select count(*) from consulente p where 1 = 1 ";
                if (!string.IsNullOrWhiteSpace(nome)) countQuery = countQuery + $" and p.nome like '%{nome}%' ";

                var consulentes = _repository.FindWithPagedSearch(query);
                int totalResults = _repository.GetCount(countQuery);

                return new PagedSearchVO<ConsulenteVO>
                {
                    CurrentPage = page,
                    List = _converter.Parser(consulentes),
                    PageSize = size,
                    SortDirections = sort,
                    TotalResults = totalResults
                };
            }
        

        public List<ConsulenteVO> ReturnAll()
        {
            return _converter.Parser(_repository.ReturnAll());
        }

        public ConsulenteVO Update(ConsulenteVO consulente)
        {

            var consulenteEntity = _converter.Parser(consulente);
            consulenteEntity = _repository.Update(consulenteEntity);
            return _converter.Parser(consulenteEntity);
        }


    }
}
