using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using Rodolfo.Schmidt.Data.Context;
using AutoMapper;
using Rodolfo.Schmidt.Application.Mapping;
using Microsoft.EntityFrameworkCore;
using Rodolfo.Schmidt.CrossCutting.IoC.ScopeInjectors;

namespace Rodolfo.Schmidt.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RodolfoSchmidtDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            RepositoryScopeInjector.Add(services);
            ServiceScopeInjector.Add(services);

            services.AddCors(o => o.AddPolicy("Cors", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddAuthorization()
            .AddJsonFormatters()
            .AddApiExplorer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("Cors");
            app.UseMvc();
        }
    }
}
