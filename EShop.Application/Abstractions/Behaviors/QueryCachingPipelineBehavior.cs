using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Abstractions.Behaviors
{
    internal sealed class QueryCachingPipelineBehavior<TRequest, TResponse>(ICacheService cacheService) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICachedQuery
    {
        private readonly ICacheService _cacheService = cacheService;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            return await _cacheService.GetorCreateAsync(request.Key, _ => next(),cancellationToken);
        }
    }
}
