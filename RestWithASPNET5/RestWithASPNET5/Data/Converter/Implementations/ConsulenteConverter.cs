using RestWithASPNETMesaRadionica.Data.Converter.Contract;
using RestWithASPNETMesaRadionica.Data.VO;
using RestWithASPNETMesaRadionica.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETMesaRadionica.Data.Converter.Implementations
{

    public class ConsulenteConverter : IParser<ConsulenteVO, Consulente>, IParser<Consulente, ConsulenteVO>
    {
        public ConsulenteVO Parser(Consulente origem)
        {

            if (origem == null) return null;

            return new ConsulenteVO
            {
                id = origem.Id,
                Nome = origem.Nome,
                Sobrenome = origem.Sobrenome,
                Endereco = origem.Endereco,
                telefone = origem.telefone,
                celular = origem.celular,
                DataNascimento = origem.DataNascimento,
                Emmail = origem.Email,
                Sexo = origem.Sexo,
                Enabled = origem.Enabled
                
            };
        }

        public List<Consulente> Parser(List<ConsulenteVO> origemList)
        {
            if (origemList == null) return null;
            return origemList.Select(item => Parser(item)).ToList();
        }

        public Consulente Parser(ConsulenteVO origem)
        {
            if (origem == null) return null;

            return new Consulente
            {
                Id = origem.id,
                Nome = origem.Nome,
                Sobrenome = origem.Sobrenome,
                Endereco = origem.Endereco,
                telefone = origem.telefone,
                celular = origem.celular,
                DataNascimento = origem.DataNascimento,
                Email = origem.Emmail,
                Sexo = origem.Sexo,
                Enabled = origem.Enabled

            };
        }

        public List<ConsulenteVO> Parser(List<Consulente> origemList)
        {
            if (origemList == null) return null;
            return origemList.Select(item => Parser(item)).ToList();
        }
    }
}
