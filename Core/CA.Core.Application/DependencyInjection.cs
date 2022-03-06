using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Core.Application.Services;
using CA.Core.Application.Services.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}