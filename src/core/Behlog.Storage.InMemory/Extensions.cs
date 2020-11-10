using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Behlog.Storage.Core;
using Behlog.Core.Contracts;
using Behlog.Core.Utils.Persian;
using Behlog.Web.Core.Settings;

namespace Behlog.Storage.InMemory
{
    public static class Extensions
    {
        public static IServiceCollection AddConfiguredInMemoryDbContext(
            this IServiceCollection services, 
            BehlogSetting setting) 
        {
            services.AddScoped<IBehlogContext>(_ => _.GetRequiredService<BehlogContext>());
            services.AddEntityFrameworkInMemoryDatabase(); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            services.AddDbContextPool<BehlogContext, InMemoryDbContext>(
                (serviceProvider, optionsBuilder) => optionsBuilder
                    .UseConfiguredInMemoryDatabase(setting, serviceProvider));
            return services;
        }

        public static void UseConfiguredInMemoryDatabase(
            this DbContextOptionsBuilder optionsBuilder, 
            BehlogSetting setting, 
            IServiceProvider services) 
        {
            optionsBuilder.UseInMemoryDatabase(setting.ConnectionStrings.LocalDb.InitialCatalog);
            optionsBuilder.UseInternalServiceProvider(services); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            optionsBuilder.AddInterceptors(new PersianDataCommandInterceptor());
            optionsBuilder.ConfigureWarnings(_ => {
                // ...
            });
        }
    }
}
