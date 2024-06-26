﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Workabroad.Presentation.Admin.Extensions.Services
{
    public static class SwaggerConfigurationExtensions
    {
        // services
        public static void AddSwaggerServices(this IServiceCollection services, params string[] options)
        {
            // Swagger-ის გენერატორის რეგისტრაცია, 1 ან მეტი Swagger დოკუმენტის განსაზღვრა
            services.AddSwaggerGen(s =>
            {
                foreach (var name in options)
                {
                    s.CustomSchemaIds(x => x.FullName.Substring(x.FullName.LastIndexOf('.') + 1).Replace('+', '.'));

                    s.SwaggerDoc(name: name, new OpenApiInfo
                    {
                        Title = "Project.Presentation.WebApi",
                        Version = "v1.0",
                        Description = "ASP.NET Core Web API Clean Architecture",
                        Contact = new OpenApiContact
                        {
                            Name = "test",
                            Email = "test@mail.com",
                            Url = new Uri("http://test.com/")
                        }
                    });

                    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer"
                    });

                    s.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
                }
            });
        }
        // middleware
        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app, params string[] options)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                foreach (var name in options)
                {
                    s.SwaggerEndpoint(
                        url: $"/swagger/{name}/swagger.json",
                        name: name);
                }
            });

            return app;
        }
    }
}