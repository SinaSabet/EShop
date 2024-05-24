using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Abstractions
{
    public interface ICacheService
    {
        Task<T> GetorCreateAsync<T>(string Key,Func<CancellationToken,Task<T>> factory,CancellationToken cancellationToken=default);

        void Add<T>(string Key,T Value);
    }
}
