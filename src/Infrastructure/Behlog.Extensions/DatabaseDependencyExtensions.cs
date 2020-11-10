using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Behlog.Core.Contracts.Services.Database;
using Behlog.Services.Database;
using Behlog.Services.Security;
using Behlog.Storage.SqlServer;
using Behlog.Storage.InMemory;
using Behlog.Storage.SQLite;
using Behlog.Web.Core.Settings;

namespace Behlog.Extensions
{
    public static class DatabaseDependencyExtensions
    {

        public static IServiceCollection AddDatabaseCacheStores(
            this IServiceCollection services, 
            BehlogSetting setting
        ) {

            var cookieOptions = setting.CookieOptions;
            if (!cookieOptions.UseDistributedCacheTicketStore)
                return services;

            switch (setting.DbType) {

                case AppDatabaseType.InMemory:
                    services.AddMemoryCache();
                    services.AddScoped<ITicketStore, MemoryCacheTicketStore>();
                    break;

                case AppDatabaseType.LocalDb:
                case AppDatabaseType.SqlServer:
                    services.AddDistributedSqlServerCache(_ => {
                        var cachOptions = cookieOptions.DistributedSqlServerCacheOptions;
                        _.ConnectionString = string.IsNullOrWhiteSpace(cachOptions.ConnectionString)
                            ? setting.GetConnectionString()
                            : cachOptions.ConnectionString;
                        _.SchemaName = cachOptions.SchemaName;
                        _.TableName = cachOptions.TableName;
                    });
                    services.AddScoped<ITicketStore, DistributedCacheTicketStore>();
                    break;

                case AppDatabaseType.SQLite:
                    services.AddMemoryCache();
                    services.AddScoped<ITicketStore, MemoryCacheTicketStore>();
                    break;

                default:
                    throw new NotSupportedException("Please set the value of [DbType] property in appsettings.json file correctly.");
            }

            return services;
        }

        public static IServiceCollection AddDatabaseServices(
            this IServiceCollection services,
            BehlogSetting setting
        ) {
            services.AddScoped<IDbInitializer, DbInitializerService>();
            services.AddScoped<DbInitializerService, DbInitializerService>();
            switch (setting.DbType) {

                case AppDatabaseType.InMemory:
                    services.AddConfiguredInMemoryDbContext(setting);
                    break;

                case AppDatabaseType.LocalDb:
                case AppDatabaseType.SqlServer:
                    services.AddSqlServerDatabase(setting);
                    break;

                case AppDatabaseType.SQLite:
                    services.AddConfiguredSQLiteDbContext(setting);
                    break;

                default:
                    throw new NotSupportedException("Please set the ActiveDatabase in appsettings.json file.");
            }

            return services;
        }

        /// <summary>
        /// Creates and seeds the database.
        /// </summary>
        public static void InitializeDb(this IServiceProvider serviceProvider) {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var identityDbInitialize = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            identityDbInitialize.Initialize();
            identityDbInitialize.SeedData();
        }
    }
}
