using Microsoft.AspNetCore.Mvc;
using RestWithASPNETMesaRadionica.Data.VO;
using RestWithASPNETMesaRadionica.HyperMedia.Constants;
using System.Text;
using System.Threading.Tasks;

namespace RestWithASPNETMesaRadionica.HyperMedia.Enricher
{
    public class ConsulenteEnricher : ContentResonseEnricher<ConsulenteVO>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(ConsulenteVO content, IUrlHelper urlHelper)
        {
            var path = "api/consulente/v1";
            string link = GetLink(content.id, urlHelper, path);

            content.Link.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET ,
                Href = link ,
                Type = ResponseTypeFormat.DefaultGet,
                Rel = RelationType.self
            });

            content.Link.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Type = ResponseTypeFormat.DefaultPost,
                Rel = RelationType.post
            });

            content.Link.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Type = ResponseTypeFormat.DefaultPut,
                Rel = RelationType.put
            });

            content.Link.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Type = "int",
                Rel = RelationType.self
            });

            content.Link.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PATCH,
                Href = link,
                Type = ResponseTypeFormat.DefaultPatch,
                Rel = RelationType.self
            });


            return null;
        }

        private string GetLink(long id , IUrlHelper urlHelper , string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url).Replace("%2F", "/")).ToString() ;
            }
        }
    }
}
