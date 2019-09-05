using Microsoft.Extensions.DependencyInjection;
using Rodolfo.Schmidt.Data.Repositories;
using Rodolfo.Schmidt.Data.UoW;
using Rodolfo.Schmidt.Domain.Interfaces.Repositories;
using Rodolfo.Schmidt.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rodolfo.Schmidt.CrossCutting.IoC.ScopeInjectors
{
    public static class RepositoryScopeInjector
    {
        public static void Add(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}
