using RestWithASPNETMesaRadionica.Model;
using RestWithASPNETMesaRadionica.Model.Context;
using RestWithASPNETMesaRadionica.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETMesaRadionica.Repository
{
    public class ConsulenteRepository : GenericRepository<Consulente>, IConsulenteRepository
    {
        public ConsulenteRepository(MySqlContext context) : base(context)   {}

        public Consulente Disable(long id)
        {
            if (!_context.Consulentes.Any(p => p.Id.Equals(id))) return null;

            var consulente = _context.Consulentes.SingleOrDefault(p => p.Id.Equals(id));

            if(consulente!=null)
            {
                consulente.Enabled = false;
                try
                {
                    _context.Entry(consulente).CurrentValues.SetValues(consulente);
                    _context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
            }

            return consulente;
           
        }

        public List<Consulente> FindByName(string nome, string sobrenome)
        {
            if (!string.IsNullOrWhiteSpace(nome) && !string.IsNullOrWhiteSpace(sobrenome))
            {
                return _context.Consulentes.Where(p => p.Nome.Contains(nome)  && p.Sobrenome.Contains(sobrenome)).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(nome) && string.IsNullOrWhiteSpace(sobrenome))
            {
                return _context.Consulentes.Where(p => p.Nome.Contains(nome)).ToList();
            }
            else if (string.IsNullOrWhiteSpace(nome) && !string.IsNullOrWhiteSpace(sobrenome))
            {
                return _context.Consulentes.Where(p => p.Sobrenome.Contains(sobrenome)).ToList();

            }

            return null;

        }
    }
}
