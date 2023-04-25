using ChatRealTime.Application.Interfaces;
using ChatRealTime.Application.Services;
using ChatRealTime.Domain.Core.Interfaces;
using ChatRealTime.Domain.Models;
using ChatRealTime.Domain.Services.Services;
using ChatRealTime.Repository.Interfaces;
using ChatRealTime.Repository.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ChatRealTime.Infrastructure.CrossCutting.Ioc
{
    public static class DependencyInjectionExtensions
    {
        public static void RegisterServicesInjection(this IServiceCollection services)
        {
           // services.UseIdentity();
            services.UseApplications();
            services.UseServices();
            services.UseRepositories();
        }

        public static void UseApplications(this IServiceCollection services) 
        {
            services.AddScoped<IUserAppService, UserAppService>();
        }

        public static void UseServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        public static void UseRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void UseIdentity(this IServiceCollection services)
        {
            services.AddScoped<UserManager<AppUserModel>>();
            services.AddDefaultIdentity<AppUserModel>();
        }
    }
}
