using ChatRealTime.Application.Interfaces;
using ChatRealTime.Application.Mappers;
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
            services.UserMappers();
        }

        public static void UseApplications(this IServiceCollection services) 
        {
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IUploadAppService, UploadAppService>();
            services.AddScoped<IRoomAppService, RoomAppService>();
            services.AddScoped<IMessageAppService, MessageAppService>();
            services.AddScoped<IMessageMapper, MessageMapper>();
            services.AddScoped<IRoomMapper, RoomMapper>();
            services.AddScoped<IUserMapper, UserMapper>();
        }

        public static void UseServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IMessageService, MessageService>();
        }

        public static void UseRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
        }

        public static void UserMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MessageMapper));
            services.AddAutoMapper(typeof(RoomMapper));
            services.AddAutoMapper(typeof(UserMapper));
        }

        public static void UseIdentity(this IServiceCollection services)
        {
            services.AddScoped<UserManager<AppUser>>();
            services.AddDefaultIdentity<AppUser>();
        }
    }
}
