using FloodRescueManagementSystem.Repositories.BaoDQ.Base;
using FloodRescueManagementSystem.Services.Group5.AutoMapper;

namespace FloodRescueManagementSystem.MVCWebApp.Group5.Extension
{
    public static class ServiceCollection
    {
        public static void Register(this IServiceCollection services)
        {
            services.RegisterInfrastructure();
        }
    }
}
