using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorizer.Data.Interfaces;
using Authorizer.Data.Repositories.Implementations;
using Authorizer.Data.Repositories.Interfaces;
using Authorizer.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Authorizer.Helpers
{
    public static class DependencyInjection
    {
        public static void RegisterComponents(IServiceCollection services)
        {
            //Services
            services.AddScoped<ITokenService, TokenService>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
