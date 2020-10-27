using System.Linq;
using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Extensions;
using Behlog.Core.Security;
using Behlog.Services.Contracts.System;
using Behlog.Web.ViewModels.System;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Behlog.Web.Components.System
{
    public class WebsiteMenuViewComponent: ViewComponent {

        private readonly IMenuService _menuService;
        private readonly IWebsiteInfo _websiteInfo;
        private readonly IUserContext _userContext;

        public WebsiteMenuViewComponent(
            IMenuService menuService,
            IWebsiteInfo websiteInfo,
            IUserContext userContext) {

            menuService.CheckArgumentIsNull(nameof(menuService));
            _menuService = menuService;

            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;

            userContext.CheckArgumentIsNull(nameof(userContext));
            _userContext = userContext;
        }


        public async Task<IViewComponentResult> InvokeAsync() {
            var menu = await _menuService
                .GetWebsiteMenuAsync(_websiteInfo.Id);

            var result = menu.Adapt<WebsiteMenuViewModel>();
            var menuItems = result.Items.ToList();

            foreach(var item in menuItems) {
                var routeVlaues = new RouteValueDictionary();

                if (!string.IsNullOrWhiteSpace(item.Controller))
                    routeVlaues.Add("controller", item.Controller);
                if (!string.IsNullOrWhiteSpace(item.Action))
                    routeVlaues.Add("action", item.Action);

                foreach (var p in item.ParameterPairs) {
                    routeVlaues.Add(p.Key, p.Value);
                }

                item.FullActionUrl = Url.RouteUrl(
                    item.RouteName, routeVlaues
                    );
            }

            result.Items = menuItems;

            return View(result);
        }

    }
}
