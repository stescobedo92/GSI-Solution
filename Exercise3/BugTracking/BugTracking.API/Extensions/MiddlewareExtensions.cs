using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BugTracking.API.Extensions
{
    public static class MiddlewareExtensions
    {
       public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BugTracking API",
                    Version = "v1",
                    Description = "Simple RESTful API built with Net5.",
                    Contact = new OpenApiContact
                    {
                        Name = "Sergio Triana Escobedo",
                        Url = new Uri("https://github.com/stescobedo92/GSI-Solution/tree/master/Exercise3/BugTracking")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                cfg.IncludeXmlComments(xmlPath);
            });
            return services;
        } 
    }
}