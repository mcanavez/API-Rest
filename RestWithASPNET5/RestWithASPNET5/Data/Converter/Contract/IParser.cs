using System.Collections.Generic;

namespace RestWithASPNETMesaRadionica.Data.Converter.Contract
{
    public interface IParser<O,D>
    {
        D Parser(O origem);

        List<D> Parser(List<O> origemList);

    }
}
