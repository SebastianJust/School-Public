using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PasswordGenerator.Middleware;
using PasswordHandler;

namespace PasswordGenerator
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
            services.AddSingleton<IPasswordGenerator, PasswordHandler.PasswordGenerator>(t => new PasswordHandler.PasswordGenerator(Configuration.GetSection("PasswordAppSettings")["ValidCharacters"]));
            
            //Let's set up Swagger UI
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PasswordGenerator", Version = "v1" });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "ApiKey",
                    In = ParameterLocation.Header,
                    Name = Configuration.GetSection("PasswordAppSettings")["ApiKey_Name"],
                    Description = "Please provide an api key in the header",
                    Reference = new OpenApiReference { Id = "ApiKey", Type = ReferenceType.SecurityScheme }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);


                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PasswordGenerator"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<ApiKeyMiddleware>(Configuration.GetSection("PasswordAppSettings")["ApiKey_Name"], Configuration.GetSection("PasswordAppSettings")["ApiKey_Value"]);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
