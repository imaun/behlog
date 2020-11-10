using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Behlog.Web.Core.Settings;

namespace Behlog.Storage.SQLite
{
    public class SQLiteDbContextFactory: IDesignTimeDbContextFactory<SQLiteDbContext> {

        public SQLiteDbContext CreateDbContext(string[] args) 
        {
            var services = new ServiceCollection();
            services.AddOptions();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();

            var basePath = Directory.GetCurrentDirectory();
            Console.WriteLine($"Using `{basePath}` as the ContentRootPath");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            services.AddSingleton<IConfigurationRoot>(provider => configuration);
            services.Configure<BehlogSetting>(options => configuration.Bind(options));

            var siteSettings = services.BuildServiceProvider().GetRequiredService<IOptionsSnapshot<BehlogSetting>>();
            siteSettings.Value.DbType = AppDatabaseType.SQLite;
            services.AddEntityFrameworkSqlite(); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.Configure(siteSettings.Value, services.BuildServiceProvider());

            return new SQLiteDbContext(optionsBuilder.Options);
        }
    }
}
