using App.Src.Config.Environments;
using App.Src.Shared.Infra.CrossCutting.Ioc.Factorys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;

namespace App.Src.Shared.Infra.CrossCutting.Ioc
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.RegisterRepositories();
            services.RegisterServices();

            return services;
        }

        public static IServiceCollection RegisterConnectionServices(this IServiceCollection connections)
        {
            connections.RegisterDbConnections();

            return connections;
        }

        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services, 
            string title,
            string description)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = title,
                        Version = "v4",
                        Description = description,
                        Contact = new OpenApiContact
                        {
                            Name = "Setor desenvolvimento de sistemas",
                            Email = "gdesenvolvimento@pmenos.com.br",
                        },
                        License = new OpenApiLicense { Name = "Empreendimentos Pague Menos S.A.,All Rights Reserved." }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swagger.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IServiceCollection RegisterHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
               .AddSqlServer(connectionString: Constants.ConnectionString);
            return services;
        }

        public static IEndpointRouteBuilder MapHealthChecks(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecks("/api/health",
                new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = async (context, report) =>
                    {
                        var result = JsonConvert.SerializeObject(
                            new
                            {
                                statusApplication = report.Status.ToString(),
                                healthChecks = report.Entries.Select(e => new
                                {
                                    check = e.Key,
                                    ErrorMessage = e.Value.Exception?.Message,
                                    status = Enum.GetName(typeof(HealthStatus), e.Value.Status)
                                })
                            });
                        context.Response.ContentType = MediaTypeNames.Application.Json;
                        await context.Response.WriteAsync(result);
                    }
                });

            return endpoints;
        }
    }
}
