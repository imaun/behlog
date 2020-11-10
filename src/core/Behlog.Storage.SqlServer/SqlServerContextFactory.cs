using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Behlog.Storage.Core;
using Behlog.Web.Core.Settings;

namespace Behlog.Storage.SqlServer {
    public class SqlServerContextFactory: IDesignTimeDbContextFactory<SqlServerDbContext> {

        public SqlServerDbContext CreateDbContext(string[] args) {
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
                //.SetBasePath(basePath)
                //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.Build();

            services.AddSingleton<IConfigurationRoot>(provider => configuration);
            services.Configure<BehlogSetting>(options => configuration.Bind(options));

            var siteSettings = services.BuildServiceProvider().GetRequiredService<IOptionsSnapshot<BehlogSetting>>();
            siteSettings.Value.DbType = AppDatabaseType.SqlServer;

            services.AddEntityFrameworkSqlServer(); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            var optionsBuilder = new DbContextOptionsBuilder<BehlogContext>();
            optionsBuilder.Configure(siteSettings.Value, services.BuildServiceProvider());

            return new SqlServerDbContext(optionsBuilder.Options);
        }

    }
}
