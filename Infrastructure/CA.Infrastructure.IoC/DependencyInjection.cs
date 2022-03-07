using CA.Core.Application.Services;
using CA.Core.Application.Services.IServices;
using CA.Core.Domain.IRepositories.Base;
using CA.Infrastructure.Persistence;
using CA.Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Persistence IoC
            //Infrastructure.Persistence
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region Service IoC
            //Core.Application
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IItemService, ItemService>();
            #endregion

            #region Repository IoC
            //Core.Domain.Interfaces | Infrastructure.Persistence.Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            #endregion

            #region UnitOfWork IoC
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            return services;
        }
    }
}