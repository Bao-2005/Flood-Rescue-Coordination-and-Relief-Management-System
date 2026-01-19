using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodRescueManagementSystem.Repositories.Group5.EntitiesConfiguration
{
    public class FloodRescueDbContextFactory : IDesignTimeDbContextFactory<FloodRescueDbContext>
    {
        public FloodRescueDbContext CreateDbContext(string[] args)
        {
            // trỏ về MVCWebApp – nơi có appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../FloodRescueManagementSystem.MVCWebApp.Group5"))
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<FloodRescueDbContext>();
            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));

            return new FloodRescueDbContext(optionsBuilder.Options);
        }
    }
}
