using EShop.Application.Abstractions;
using EShop.Domain.Contract;
using EShop.Domain.Contract.Context;
using EShop.Infrastructure.Caching;
using EShop.Infrastructure.Persistence.Context;
using EShop.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure
{
    public static class DependencyRegisterer
    {
        public static void InfraRegister(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IOrderLineRepository, OrderLineRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddMemoryCache();
            services.AddScoped<ICacheService, CacheService>();

            services.AddDbContext<IAppDbContext, AppDbContext>(options =>
          options.UseSqlServer(configuration.GetSection("AppSetting:ConnectionString").Value));

        }
    }
}
