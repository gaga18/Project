using Project.Core.Application;
using Project.Core.Application.Interfaces.Contracts;
using Project.Infrastructure.Files;
using Project.Infrastructure.Persistence;
using Project.Presentation.WebApi.Extensions.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Workabroad.Presentation.Admin.Extensions.Middlewares;
using Workabroad.Presentation.Admin.Extensions.Services;

namespace Project.Presentation.WebApi
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup(IConfiguration configuration) => this.configuration = configuration;


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation();
            services.AddScoped<IActiveUserService, ActiveUserService>();

            services.AddSwaggerServices("Project v1");

            services.AddApplicatonLayer(configuration);
            services.AddFilesLayer(configuration);
            services.AddPersistenceLayer(configuration);

            services.ConfigureCors();

            services.AddJwtAuthenticationConfigs(configuration);
            services.AddJwtAuthorizationConfigs();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            if (env.IsDevelopment())
            {
                context.Database.EnsureCreated();
                app.UseDeveloperExceptionPage();
                app.UseSwaggerMiddleware("Project v1");
            }

            app.UseMiddleware<ExceptionHandler>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
