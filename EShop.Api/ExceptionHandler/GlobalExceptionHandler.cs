﻿using EShop.Api.Meters;
using EShop.Api.Model;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace EShop.Api.ExceptionHandler
{
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly CustomExceptionMeter _exceptionMeter;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _exceptionMeter = new CustomExceptionMeter();
            _logger = logger;

        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            //Log


            // Handle specific exceptions based on the HTTP status code
            if (httpContext.Response.StatusCode == (int)HttpStatusCode.BadRequest)
            {

                await BuildBadRequestResponse(httpContext, exception);
            }
            else if (httpContext.Response.StatusCode == (int)HttpStatusCode.InternalServerError)
            {
                await BuildInternalResponse(httpContext, exception);
            }
          

            return true; // Indicate that the exception has been handled
        }

     

        private Task BuildBadRequestResponse(HttpContext context, Exception ex)
        {
            _exceptionMeter.TrackApiException(context.Request.Path,ex);
            context.Response.ContentType = "Application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            _logger.LogError(ex, "BadRequest response built for path: {RequestPath}", context.Request.Path);
            return context.Response.WriteAsync(new Response { Succeeded = false, Message = "خطا در داده های ورودی", Errors = ex.Message.Split('-').ToList() }.ToString());
        }

        private Task BuildInternalResponse(HttpContext context, Exception ex)
        {
            _exceptionMeter.TrackApiException(context.Request.Path, ex);
            context.Response.ContentType = "Application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            _logger.LogError(ex, "Internal server error response built for path: {RequestPath}", context.Request.Path);
            return context.Response.WriteAsync(new Response { Succeeded = false, Message = " خطایی در سمت سرور رخ داده است", Errors = new List<string> { ex.Message } }.ToString());
        }
    }
}
