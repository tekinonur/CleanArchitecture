using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Core.Application.Repositories.Base;
using CA.Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlite(configuration.GetConnectionString("Connection"),
               b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)), ServiceLifetime.Transient);
            //services.AddScoped<IApplicationDBContext>(provider => provider.GetService<ApplicationDBContext>());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}