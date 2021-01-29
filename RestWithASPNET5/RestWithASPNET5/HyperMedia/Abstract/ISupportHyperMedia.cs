using System.Collections.Generic;

namespace RestWithASPNETMesaRadionica.HyperMedia.Abstract
{
    public interface ISupportHyperMedia
    {
        List<HyperMediaLink> Link { get; set; }
    }
}
