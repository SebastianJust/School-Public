using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FilesFetcherRestService.DatabaseContext;
using FilesFetcherRestService.Handlers;
using FilesFetcherRestService.Utilities.Authentication;
using FilesModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace FilesFetcherRestService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<FilesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Files")));
            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();


            //Issues: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/1295
            //Cannot run in swagger UI.
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Title = "FilesFetcherRestService", Version = "v1",
                            Contact = new OpenApiContact() {Name = "Sebastian Just Mikkelsen"}
                        });
                    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme()
                    {
                        Type = SecuritySchemeType.Http,
                        Name = "Authorization",
                        Scheme = "basic",
                        Description = "basic authentication for API",
                        In = ParameterLocation.Header,
                        
                    });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ApplicationServices.GetService<IFilesFetcherHandler>();
            app.UseSwagger();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FilesFetcherRestApi");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
