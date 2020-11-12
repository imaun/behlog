using System;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Behlog.Core;
using Behlog.Core.Extensions;
using Behlog.Web.Common.Routing;
using DNTCommon.Web.Core;

namespace Behlog.Web {
    
    public class Startup {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) {
            configuration.CheckArgumentIsNull();
            env.CheckArgumentIsNull();

            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)  {
            services.AddBehlogServices(Configuration);
            services.AddMvc(_ => {
                _.UseYeKeModelBinder();
            });
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true;
            });
            services.AddDNTCommonWeb();
            IMvcBuilder mvc = services.AddControllersWithViews();
            mvc = services.AddRazorPages();
            
            mvc.AddApplicationPart(typeof(
                Admin.Controllers.PostController)
                .Assembly);
            mvc.AddApplicationPart(typeof(
                Identity.Controllers.LoginController)
                .Assembly);

            services.Configure<RouteOptions>(_ => {
                _.ConstraintMap.Add("reserved", typeof(BehlogReservedRouteConstraint));
            });
#if DEBUG
            if (Env.IsDevelopment()) {
                mvc.AddRazorRuntimeCompilation();
            }
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app) {
            if (Env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.MapWhen(context => {
                var path = context.Request.Path.Value.ToLower();
                return
                    path.StartsWith("/assets") ||
                    path.StartsWith("/lib") ||
                    path.StartsWith("/themes") ||
                    path.StartsWith("/app_data") ||
                    path.StartsWith("/images") ||
                    path.StartsWith("/uploads") ||
                    path.StartsWith("/favicon") ||
                    path.StartsWith("/fonts") ||
                    path.StartsWith("/js") ||
                    path.EndsWith("html") ||
                    path.EndsWith("htm") ||
                    path.StartsWith("/css");
            }, config => config.UseStaticFiles());

            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseAppHttpContext();

            Behlog.Web.Common.CommonHelper
                .Configure(app.ApplicationServices);

            app.UseEndpoints(endpoints => {

                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "Areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                //endpoints.MapControllerRoute(
                //    name: "AdminArea",
                //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                //);

                endpoints.MapControllerRoute(
                    name: "Error",
                    pattern: "Error",
                    defaults: new { controller = "Error", action = "Index" }
                );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                
                endpoints.MapRazorPages();
            });
        }
    }
}
