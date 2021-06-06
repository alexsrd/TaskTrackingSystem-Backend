using Microsoft.Extensions.DependencyInjection;
using TaskTrackingSystem.BLL.Services;
using TaskTrackingSystem.BLL.Services.Interfaces;
using TaskTrackingSystem.BLL.Services.SmtpService;
using TaskTrackingSystem.DAL;

namespace TaskTrackingSystem.Web.AppStart
{
    public static class ConfigureDependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmailService, EmailService>();   
        }
    }
}