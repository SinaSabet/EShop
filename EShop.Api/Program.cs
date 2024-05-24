using EShop.Api;
using EShop.Api.ExceptionHandler;
using EShop.Application;
using EShop.Infrastructure;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Prometheus;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.UseHttpClientMetrics();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
#region dependencyRegisterer

builder.Services.PeresentationRegister();
builder.Services.ApplicationRegister();
builder.Services.InfraRegister(configuration);

#endregion;
#region docker desktop
builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 80, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
    });
});

#endregion



var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI();


//app.UseCustomExceptionHandler(metrics);
app.UseExceptionHandler();
app.UseRouting();
app.UseMetricServer();
app.UseAuthorization();
app.MapControllers();
app.MapPrometheusScrapingEndpoint();
app.Run();


