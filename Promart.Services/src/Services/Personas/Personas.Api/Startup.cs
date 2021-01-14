using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persona.Persistence.Database;
using Personas.Service.Querys;
using MediatR;
using System.Reflection;
using Common.Logging;
using Swashbuckle;
using System.IO;
namespace Personas.Api
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


            //Configuracion del contexto
            services.AddDbContext<ApplicationDbContext>(opts => opts.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            //Registro de comandos
            services.AddMediatR(Assembly.Load("Personas.Service.EventHandlers"));

            //Registro dependencias
            services.AddTransient<IPersonaQueryService, PersonaQueryService>();

            services.AddControllers();


            //Configuracion swagger
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "PROMART Api",
                        Description = "Api solicitado por PROMART en Swagger",
                        Version = "v1.0.1"
                    });
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                opt.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                IWebHostEnvironment env,
                ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ////Estableciendo el log con Papertrail
            //loggerFactory.AddSyslog(
            //     Configuration.GetValue<string>("Papertrail:host"),
            //     Configuration.GetValue<int>("Papertrail:port"));



            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(opciones =>
            {
                opciones.SwaggerEndpoint("/swagger/v1/swagger.json", "PROMART Api");
                opciones.RoutePrefix = "";
            });
        }
    }
}
