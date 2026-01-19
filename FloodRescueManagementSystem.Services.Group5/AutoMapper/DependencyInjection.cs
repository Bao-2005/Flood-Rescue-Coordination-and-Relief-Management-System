using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodRescueManagementSystem.Services.Group5.AutoMapper
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            var mapperConfigExpression = new MapperConfigurationExpression();
            //mapperConfigExpression.AddProfile<InstrumentProfile>(); => example

            var loggerFactory = services.BuildServiceProvider().GetService<ILoggerFactory>();

            var config = new MapperConfiguration(mapperConfigExpression);
            var mapper = config.CreateMapper();

            services.AddSingleton<IMapper>(mapper);

            return services;
        }
    }
}
