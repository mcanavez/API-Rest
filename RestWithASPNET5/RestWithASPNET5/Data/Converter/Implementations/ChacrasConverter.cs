using RestWithASPNETMesaRadionica.Data.Converter.Contract;
using RestWithASPNETMesaRadionica.Data.VO;
using RestWithASPNETMesaRadionica.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETMesaRadionica.Data.Converter.Implementations
{

    public class ChacrasConverter : IParser<ChacrasVO, Chacras>, IParser<Chacras, ChacrasVO>
    {
        public Chacras Parser(ChacrasVO origem)
        {

            if (origem == null) return null;

            return new Chacras
            {
                Id = origem.id,
                AtendenteId = origem.AtendenteId,
                ConsulenteID = origem.ConsulenteID,
                DataAtendimento = origem.DataAtendimento,
                Basico = origem.Basico,
                Cardiaco = origem.Cardiaco,
                PlexoSolar = origem.PlexoSolar,
                Coronario = origem.Coronario,
                Frontal = origem.Frontal,
                Laringeo = origem.Laringeo,
                Umbilical = origem.Umbilical,
                TipoAtendimento = origem.TipoAtendimento                
            };
        }

        public List<Chacras> Parser(List<ChacrasVO> origemList)
        {
            if (origemList == null) return null;
            return origemList.Select(item => Parser(item)).ToList();
        }

        public ChacrasVO Parser(Chacras origem)
        {
            if (origem == null) return null;

            return new ChacrasVO
       
               {
                    id = origem.Id,
                    AtendenteId = origem.AtendenteId,
                    ConsulenteID = origem.ConsulenteID,
                    DataAtendimento = origem.DataAtendimento,
                    Basico = origem.Basico,
                    Cardiaco = origem.Cardiaco,
                    PlexoSolar = origem.PlexoSolar,
                    Coronario = origem.Coronario,
                    Frontal = origem.Frontal,
                    Laringeo = origem.Laringeo,
                    Umbilical = origem.Umbilical,
                    TipoAtendimento = origem.TipoAtendimento
                };

        }

        public List<ChacrasVO> Parser(List<Chacras> origemList)
        {
            if (origemList == null) return null;
            return origemList.Select(item => Parser(item)).ToList();
        }
    }
}
