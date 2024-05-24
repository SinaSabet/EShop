using EShop.Application.Abstractions.Behaviors;
using EShop.Application.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EShop.Application
{
    public static class DependencyRegisterer
    {
        public static void ApplicationRegister(this IServiceCollection services)
        {
            #region MediatR
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
                cfg.AddOpenBehavior(typeof(QueryCachingPipelineBehavior<,>));
            });
            #endregion




        }
    }
}
