using EShop.Api.Exceptions;
using EShop.Api.Filters;
using EShop.Api.Meters;
using EShop.Api.Setting;
using EShop.Domain.Contract.Setting;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Metrics;

namespace EShop.Api
{
    public static class DependencyRegisterer
    {
        public static void PeresentationRegister(this IServiceCollection services)
        {
            services.AddControllers(option =>
            option.Filters.Add<SuccessfulApiRequestTrackingFilter>())
                 .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        new CustomBadRequest(context);
                        return null;
                    };
                });

            services.AddScoped<SuccessfulApiRequestTrackingFilter>();


            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "EShop", Version = "v1" });

            });
            services.AddSingleton<IAppSetting, AppSetting>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

            services.AddScoped<SuccessfulApiMeter>();
            services.AddScoped<CustomExceptionMeter>();

            services.AddOpenTelemetry()
              .WithMetrics(builder =>
              {
                  builder.AddAspNetCoreInstrumentation();
                  builder.AddMeter("Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Server.Kestrel", CustomExceptionMeter.ServiceName,SuccessfulApiMeter.ServiceName);
                  builder.AddView("http.server.request.duration", new ExplicitBucketHistogramConfiguration
                  {
                      Boundaries = new double[] {  1, 2.5, 5, 7.5, 10 }
                  });
                  builder.AddPrometheusExporter();
                  builder.AddOtlpExporter();
              });

            ;

        }

    }
}
