using EShop.Application.Abstractions;
using EShop.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Caching
{
    public class CacheService : ICacheService
    {
        private readonly TimeSpan DefaultTime=TimeSpan.FromSeconds(5);
        private readonly IMemoryCache _cache;
        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Add<T>(string Key, T Value)
        {
            if (string.IsNullOrWhiteSpace(Key))
            {
                throw new CacheKeyNullException();
            }
            _cache.Set<T>(Key, Value); 
        }

        public async Task<T> GetorCreateAsync<T>(string Key, Func<CancellationToken, Task<T>> factory, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(Key))
            {
                throw new CacheKeyNullException();
            }

            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            return await _cache.GetOrCreateAsync(Key, async entry =>
            {
                entry.SetAbsoluteExpiration(DefaultTime);
                return await factory(cancellationToken);
            });
        }
    }
}
