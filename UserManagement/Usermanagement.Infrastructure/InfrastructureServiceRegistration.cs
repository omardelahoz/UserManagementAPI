using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Contracts.Database;
using UserManagement.Infrastructure.Database;
using UserManagement.Infrastructure.Managers.Database;

namespace UserManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<UserManagementContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UserManagementConn"))
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

            

            return services;
        }

    }
}
