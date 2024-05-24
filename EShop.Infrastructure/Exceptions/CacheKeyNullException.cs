using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Exceptions
{
    public class CacheKeyNullException: Exception
    {
        public CacheKeyNullException()
    : base($"Cache key cannot be null or empty.")
        {
        }
    }
}
