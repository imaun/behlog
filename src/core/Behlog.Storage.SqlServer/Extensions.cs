using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Behlog.Core.Contracts;
using Behlog.Core.Utils.Persian;
using Behlog.Storage.Core;
using Behlog.Web.Core.Settings;

namespace Behlog.Storage.SqlServer {
    public static class Extensions {

        public static IServiceCollection AddSqlServerDatabase(this IServiceCollection services,
            BehlogSetting settings) {

            services.AddTransient<IBehlogContext>(provider 
                => provider.GetRequiredService<BehlogContext>());
            services.AddEntityFrameworkSqlServer();
            services.AddDbContextPool<BehlogContext, SqlServerDbContext>(
                (provider, optionsBuilder) 
                    => optionsBuilder.Configure(settings, provider));

            return services;
        }

        public static void Configure(this DbContextOptionsBuilder optionsBuilder,
            BehlogSetting setting,
            IServiceProvider provider) {

            optionsBuilder.UseSqlServer(setting.GetConnectionString(),
                __ => {
                    __.CommandTimeout((int) TimeSpan.FromMinutes(3).TotalSeconds);
                    __.EnableRetryOnFailure();
                    __.MigrationsAssembly(typeof(SqlServerContextFactory).Assembly.FullName);
                });
            optionsBuilder.UseInternalServiceProvider(provider);
            optionsBuilder.AddInterceptors(new PersianDataCommandInterceptor());
        }




        

    }
}
