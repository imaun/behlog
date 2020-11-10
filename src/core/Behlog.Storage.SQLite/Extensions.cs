using System;
using Behlog.Core.Contracts;
using Behlog.Core.Utils.Persian;
using Behlog.Core.Utils.Web;
using Behlog.Storage.Core;
using Behlog.Web.Core.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Behlog.Storage.SQLite
{
    public static class Extensions
    {
        public static IServiceCollection AddConfiguredSQLiteDbContext(
            this IServiceCollection services,
            BehlogSetting setting) 
        {
            services.AddScoped<IBehlogContext>(serviceProvider =>
                serviceProvider.GetRequiredService<BehlogContext>());
            services.AddEntityFrameworkSqlite(); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            services.AddDbContextPool<BehlogContext, SQLiteDbContext>(
                (serviceProvider, optionsBuilder) => optionsBuilder.Configure(setting, serviceProvider));
            return services;
        }

        public static void Configure(
            this DbContextOptionsBuilder optionsBuilder, 
            BehlogSetting setting, 
            IServiceProvider serviceProvider) 
        {
            var connectionString = setting.GetSQLiteDbConnectionString();
            optionsBuilder.UseSqlite(
                connectionString,
                sqlServerOptionsBuilder => {
                    sqlServerOptionsBuilder.CommandTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    sqlServerOptionsBuilder.MigrationsAssembly(typeof(Extensions).Assembly
                        .FullName);
                });
            optionsBuilder
                .UseInternalServiceProvider(
                    serviceProvider); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            optionsBuilder.AddInterceptors(new PersianDataCommandInterceptor());
            optionsBuilder.ConfigureWarnings(warnings => {
                // ...
            });
        }

        public static string GetSQLiteDbConnectionString(this BehlogSetting siteSettingsValue) {
            if (siteSettingsValue == null) {
                throw new ArgumentNullException(nameof(siteSettingsValue));
            }

            switch (siteSettingsValue.DbType) {
                case AppDatabaseType.SQLite:
                    return siteSettingsValue.ConnectionStrings
                        .SQLite
                        .ReplaceDataDirectoryInConnectionString();

                default:
                    throw new NotSupportedException(
                        "Please set the ActiveDatabase in appsettings.json file to `SQLite`.");
            }
        }

        public static string ReplaceDataDirectoryInConnectionString(this string connectionString) {
            return connectionString.Replace("|DataDirectory|", ServerInfo.GetAppDataFolderPath());
        }
    }
}
