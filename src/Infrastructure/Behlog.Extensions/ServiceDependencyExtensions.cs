using System;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Behlog.Core;
using Behlog.Storage.Core;
using Behlog.Core.Services;
using Behlog.Services.Security;
using Behlog.Core.Models.Security;
using Behlog.Services.Contracts.Security;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Contracts.Repository.Shop;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Contracts.Repository.Security;
using Behlog.Factories.Content;
using Behlog.Factories.Contracts.Content;
using Behlog.Factories.Contracts.Feature;
using Behlog.Factories.Contracts.System;
using Behlog.Factories.Contracts.Security;
using Behlog.Factories.Feature;
using Behlog.Services.Contracts.System;
using Behlog.Factories.System;
using Behlog.Core.Contracts.Repository.Content;
using Behlog.Core.Contracts.Repository.Feature;
using Behlog.Repository.Content;
using Behlog.Repository.Feature;
using Behlog.Repository.System;
using Behlog.Repository.Security;
using Behlog.Repository.Shop;
using Behlog.Services.Content;
using Behlog.Services.Contracts.Content;
using Behlog.Services.Contracts.Feature;
using Behlog.Services.Contracts.Http;
using Behlog.Services.System;
using Behlog.Web.Data.Content;
using Behlog.Web.Data.System;
using Behlog.Services.Dto;
using Behlog.Services.Feature;
using Behlog.Extensions;
using Behlog.Web.Common.Filters;
using Behlog.Web.Common.Middlewares;
using Behlog.Validation.Contracts.Feature;
using Behlog.Validation.Feature;
using Behlog.Web.Common.Tools;
using Behlog.Web.Admin.Core;
using Behlog.Web.Core.Settings;
using Behlog.Factories.Security;
using Behlog.Services.Http;
using Microsoft.AspNetCore.Routing;
using Behlog.Web.Common.Routing;
using Behlog.Services.Contracts.Admin;
using Behlog.Services.Admin;

namespace Microsoft.Extensions.DependencyInjection {

    public static class ServiceDependencyExtensions {

        public static void AddBehlogServices(
            this IServiceCollection services,
            IConfiguration configuration) {

            services.Configure<BehlogSetting>(configuration.Bind);
            var appSetting = GetAppSetting(services);
            var websiteOptions = appSetting.WebsiteSeedInfo.Options;

            services.AddSingleton<BehlogSetting>(appSetting);
            services.AddSingleton<WebsiteOptionSetting>(websiteOptions);
            services.AddSingleton<GlobalViewData>(appSetting.ViewData);
            services.AddScoped<IDateService, DateService>();
            services.AddIdentityOptions(appSetting);
            services.AddSecurityServices();
            services.AddDatabaseServices(appSetting);
            services.AddHttpServices();
            services.AddDatabaseCacheStores(appSetting);
            services.AddDynamicPermissions();
            services.AddFactories();
            services.AddRepositories();
            services.AddValidators();
            services.AddServices();
            services.AddAdminServices();
            services.AddViewModelProviders();
            services.AddExtensions();
            services.AddScoped<IWebsiteInfo>(_ => {
                var service = _.GetService<IWebsiteService>();
                var result = service.GetWebsiteInfo(appSetting.WebsiteId).Result;
                return result != null ? result : null;
            });

            MappingConfig.AddDtoMappingConfig();
            Behlog.Web.Mapping.MappingConfig.AddViewModelMappingConfig();
        }


        private static void AddHttpServices(
            this IServiceCollection services) {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        private static void AddSecurityServices(
            this IServiceCollection services) 
        {
            services.AddScoped<IPrincipal>(_ =>
                _.GetRequiredService<IHttpContextAccessor>()
                    ?.HttpContext?.User 
                    ?? ClaimsPrincipal.Current);

            services.AddScoped<ILookupNormalizer, CustomNormalizer>();
            services.AddScoped<IPasswordValidator<User>, CustomPasswordValidator>();
            services.AddScoped<PasswordValidator<User>, CustomPasswordValidator>();
            services.AddScoped<IUserValidator<User>, CustomUserValidator>();
            services.AddScoped<UserValidator<User>, CustomUserValidator>();
            services.AddScoped<IUserClaimsPrincipalFactory<User>, AppClaimsPrincipalFactory>();
            services.AddScoped<UserClaimsPrincipalFactory<User>, AppClaimsPrincipalFactory>();
            services.AddScoped<IdentityErrorDescriber, CustomIdentityErrorDescriber>();
            services.AddScoped<IAppUserStore, AppUserStore>();
            services.AddScoped<UserStore<User, Role, BehlogContext, Guid, UserClaim, 
                UserRole, UserLogin, UserToken, RoleClaim>, AppUserStore>();
            services.AddScoped<IAppRoleManager, AppRoleManager>();
            services.AddScoped<RoleManager<Role>, AppRoleManager>();
            services.AddScoped<IAppSignInManager, AppSignInManager>();
            services.AddScoped<SignInManager<User>, AppSignInManager>();
            services.AddScoped<IAppRoleStore, AppRoleStore>();
            services.AddScoped<RoleStore<Role, BehlogContext, Guid, UserRole, RoleClaim>, AppRoleStore>();
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<AppUserManager, AppUserManager>();

            services.AddScoped<IUserProfileImageService, UserProfileImageService>();
            services.AddScoped<ISecurityAccessService, SecurityAccessService>(); 
            
        }

        private static void AddDynamicPermissions(
            this IServiceCollection services) 
        {
            services.AddScoped<IAuthorizationHandler, 
                DynamicPermissionsAuthorizationHandler>();

            services.AddAuthorization(_ => {
                _.AddPolicy(
                    name: ConstantPolicies.DynamicPermission,
                    configurePolicy: policy => {
                        policy.RequireAuthenticatedUser();
                        policy.Requirements.Add(new DynamicPermissionRequirement());
                    }
                );
            });
        }

        private static void AddFactories(this IServiceCollection services) {
            //Content
            services.AddScoped<IPostFactory, PostFactory>();
            services.AddScoped<ICommentFactory, CommentFactory>();
            services.AddScoped<IFileFactory, FileFactory>();
            services.AddScoped<IPostFileFactory, PostFileFactory>();

            //Feature
            services.AddScoped<IContactFactory, ContactFactory>();
            services.AddScoped<IPostVisitFactory, PostVisitFactory>();
            services.AddScoped<IWebsiteVisitFactory, WebsiteVisitFactory>();
            services.AddScoped<ISubscriberFactory, SubscriberFactory>();

            //System
            services.AddScoped<ILanguageFactory, LanguageFactory>();
            services.AddScoped<ILayoutFactory, LayoutFactory>();
            services.AddScoped<IWebsiteFactory, WebsiteFactory>();
            services.AddScoped<ICategoryFactory, CategoryFactory>();
            services.AddScoped<IErrorLogFactory, ErrorLogFactory>();
            services.AddScoped<IWebsiteOptionFactory, WebsiteOptionFactory>();
            services.AddScoped<ITagFactory, TagFactory>();

            //Security
            services.AddScoped<IUserFactory, UserFactory>();
        }

        private static void AddRepositories(
            this IServiceCollection services) {

            //Content
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<ILinkRepository, LinkRepository>();
            services.AddScoped<IPostFileRepository, PostFileRepository>();
            services.AddScoped<IPostLikeRepository, PostLikeRepository>();
            services.AddScoped<IPostMetaRepository, PostMetaRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            //Feature
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IFormFieldRepository, FormFieldRepository>();
            services.AddScoped<IFormFieldItemRepository, FormFieldItemRepository>();
            services.AddScoped<IFormFieldValueRepository, FormFieldValueRepository>();
            services.AddScoped<IPostVisitRepository, PostVisitRepository>();
            services.AddScoped<IWebsiteVisitRepository, WebsiteVisitRepository>();
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();

            //Shop
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductMetaRepository, ProductMetaRepository>();
            services.AddScoped<IProductModelRepository, ProductModelRepository>();
            services.AddScoped<IProductPriceRepository, ProductPriceRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductReviewRepository, ProductReviewRepository>();
            services.AddScoped<IShippingAddressRepository, ShippingAddressRepository>();
            services.AddScoped<IShippingRepository, ShippingRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();

            //System
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILayoutRepository, LayoutRepository>();
            services.AddScoped<IWebsiteRepository, WebsiteRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostTypeRepository, PostTypeRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IWebsiteOptionRepository, WebsiteOptionRepository>();
            services.AddScoped<IErrorLogRepository, ErrorLogRepository>();
            
            //Security
            services.AddScoped<IUserRepository, UserRepository>();
        }


        private static void AddAdminServices(this IServiceCollection services) {
            services.AddScoped<IAdminSliderService, AdminSliderService>();
        }

        private static void AddServices(this IServiceCollection services) {
            //Content
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ISearchService, SearchService>();

            //Feature
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IPostVisitService, PostVisitService>();
            services.AddScoped<IWebsiteVisitService, WebsiteVisitService>();
            services.AddScoped<ISubscriberService, SubscriberService>();

            //System
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ILayoutService, LayoutService>();
            services.AddScoped<IWebsiteService, WebsiteService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPostTypeService, PostTypeService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IWebsiteOptionService, WebsiteOptionService>();
            services.AddScoped<IErrorLogService, ErrorLogService>();
            services.AddScoped<ITagService, TagService>();

            //Security
            services.AddScoped<IUserService, UserService>();

            //Http
            services.AddScoped<ILinkBuilder, LinkBuilder>();
        }

        private static void AddValidators(this IServiceCollection services) {

            //Feature
            services.AddScoped<ISubscriberValidator, SubscriberValidator>();
        }

        private static void AddViewModelProviders(this IServiceCollection services) {
            services.AddScoped<CategoryViewModelProvider>();
            services.AddScoped<CityViewModelProvider>();
            services.AddScoped<LanguageViewModelProvider>();
            services.AddScoped<PostViewModelProvider>();
            services.AddScoped<WebsiteOptionsProvider>();

        }

        private static void AddExtensions(this IServiceCollection services) {
            services.AddScoped<FileUploadHelper>();
            services.AddScoped<CountPostVisitFilter>();
            services.AddScoped<TagsLoader>();
        }

        
        public static void ConfigureBehlogReservedRoutes(this IServiceCollection services) {
            services.Configure<RouteOptions>(_ => {
                _.ConstraintMap.Add("reserved", typeof(BehlogReservedRouteConstraint));
            });
        }


        public static void ConfigureBehlogHelpers(this IApplicationBuilder app) {
            Behlog.Web.Common.CommonHelper.Configure(app.ApplicationServices);
        }

        public static BehlogSetting GetAppSetting(this IServiceCollection services) {
            var provider = services.BuildServiceProvider();
            var options = provider.GetRequiredService<IOptionsSnapshot<BehlogSetting>>();
            var appSetting = options.Value;

            if(appSetting == null)
                throw new ArgumentNullException(nameof(appSetting));

            return appSetting;
        }


        public static IApplicationBuilder UseWebsiteVisitCounterMiddleware(
            this IApplicationBuilder app) 
                => app.UseMiddleware<WebsiteVisitCounterMiddleware>();

        /// <summary>
        /// Map Behlog static paths to serve as static files in application pipeline.
        /// </summary>
        /// <param name="app">ApplicationBuilder</param>
        /// <returns></returns>
        public static IApplicationBuilder MapBehlogStaticPaths(this IApplicationBuilder app) 
            => app.MapWhen(context => {
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
                        path.EndsWith("robots.txt") ||
                        path.StartsWith("/css");
                }, config => config.UseStaticFiles());
    }
}
