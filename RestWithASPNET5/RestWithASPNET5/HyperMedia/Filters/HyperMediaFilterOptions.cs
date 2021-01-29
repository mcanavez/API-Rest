using RestWithASPNETMesaRadionica.HyperMedia.Abstract;
using System.Collections.Generic;

namespace RestWithASPNETMesaRadionica.HyperMedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
