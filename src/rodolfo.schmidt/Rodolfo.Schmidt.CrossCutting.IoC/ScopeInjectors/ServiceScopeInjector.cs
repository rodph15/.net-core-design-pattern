using Microsoft.Extensions.DependencyInjection;
using Rodolfo.Schmidt.Application.Interfaces;
using Rodolfo.Schmidt.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rodolfo.Schmidt.CrossCutting.IoC.ScopeInjectors
{
    public static class ServiceScopeInjector
    {
        public static void Add(IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
