using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using RestWithASPNETMesaRadionica.HyperMedia.Abstract;
using RestWithASPNETMesaRadionica.HyperMedia.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETMesaRadionica.HyperMedia
{
    public abstract class ContentResonseEnricher<T> : IResponseEnricher where T : ISupportHyperMedia
    {

        protected abstract Task EnrichModel(T content, IUrlHelper urlHelper);

        public ContentResonseEnricher()
        { 

        }

        bool IResponseEnricher.CanEnrich(ResultExecutingContext response)
        {
            if (response.Result is OkObjectResult okObjectResult)
            {
                return CanEnrich(okObjectResult.Value.GetType());
            }

            return false;
        }
        public bool CanEnrich(Type contentType)
        {
            return contentType == typeof(T) || contentType == typeof(List<T>) || contentType ==typeof(PagedSearchVO<T>);
        }

        public async Task Enrich(ResultExecutingContext response)
        {
            var urlHelper = new UrlHelperFactory().GetUrlHelper(response);
            if (response.Result is OkObjectResult okObjectResult)
            {
                if (okObjectResult.Value is T model)
                {
                    await EnrichModel(model,urlHelper);
                }
                else if(okObjectResult.Value is List<T> collection)
                {
                    ConcurrentBag<T> bag = new ConcurrentBag<T>(collection);
                    Parallel.ForEach(bag, (element) =>
                    {
                        EnrichModel(element, urlHelper);
                    });
                }
                else if (okObjectResult.Value is PagedSearchVO<T> pagedSearchVO)
                {
                    
                    Parallel.ForEach(pagedSearchVO.List.ToList(), (element) =>
                    {
                        EnrichModel(element, urlHelper);
                    });
                }

                await Task.FromResult<object>(null);

            }
        }
    }
}
