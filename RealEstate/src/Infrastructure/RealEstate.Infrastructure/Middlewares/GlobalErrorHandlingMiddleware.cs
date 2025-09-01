using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RealEstate.Infrastructure.Commons;
using RealEstate.Infrastructure.Exceptions;
using RealEstate.Infrastructure.Middlewares;
using System.Diagnostics.Contracts;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace RealEstate.Infrastructure.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        async public Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {

                ApiResponse response = ex switch
                {
                    NotFoundException => ApiResponse.Fail("not_found", ex.Message, HttpStatusCode.NotFound),
                    DeleteFailureException => ApiResponse.Fail("delete_fail", ex.Message, HttpStatusCode.NotFound),
                    BadRequestException badEx => ApiResponse.Fail(badEx.Errors, "validation_error", ex.Message, HttpStatusCode.BadRequest),
                    ApiException => ApiResponse.Fail("server_error", ex.Message, HttpStatusCode.InternalServerError),
                    _ => ApiResponse.Fail("", ex.Message, HttpStatusCode.ServiceUnavailable)
                };

                var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy
                        {
                            ProcessDictionaryKeys = true,
                        }
                    },
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.None,
                });
                context.Response.StatusCode = (int)response.StatusCode;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                await context.Response.WriteAsync(json);
            }
        }

    }
}


public static class GlobalErrorHandlingMiddlewareExtension
{
    public static IApplicationBuilder UseGlobalErrorHandling(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<GlobalErrorHandlingMiddleware>();
        return builder;
    }
}
