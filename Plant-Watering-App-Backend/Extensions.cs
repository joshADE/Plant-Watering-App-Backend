using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plant_Watering_App_Backend.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Watering_App_Backend
{
    public static class Extensions
    {
        public static IHost MigrateDatabase(this IHost webHost)
        {
            // Manually run any pending migrations if configured to do so.
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (env == "Production")
            {
                var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var dbContext = services.GetRequiredService<ApplicationDBContext>();
                    dbContext.Database.Migrate();
                }
            }
            return webHost;
        }
    }
}
