using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserManagement.Application.Validators;
using DTO = UserManagement.Domain.DTO;
using Entity = UserManagement.Domain.Entities;

namespace UserManagement.Application
{
    public static class ApplicationServiceRegistration
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(m => m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            #region Validators
            services.AddScoped<IValidator<DTO.Login>, LoginValidator>();
            services.AddScoped<IValidator<Entity.User>, UsersValidator>();
            services.AddScoped<IValidator<Entity.Role>, RolesValidator>();
            #endregion

            return services;
        }

    }
}
