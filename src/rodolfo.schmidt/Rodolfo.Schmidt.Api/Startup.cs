using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rodolfo.Schmidt.CrossCutting.IoC;

namespace Rodolfo.Schmidt.Api
{
    public class Startup : NativeInjectorBootStrapper
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

    }
}
