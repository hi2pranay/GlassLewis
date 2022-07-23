using GlassLewis.API.CustomExceptionMiddleware;
using GlassLewis.Core.GlassLewis.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace GlassLewis.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
