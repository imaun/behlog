using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Behlog.Web.Data.System;
using Behlog.Core.Extensions;
using Behlog.Web.ViewModels.System;
using Behlog.Services.Contracts.Http;
using Behlog.Services.Contracts.System;
using Mapster;

namespace Behlog.Web.Components.System
{
    public class WebsiteMenuViewComponent: ViewComponent {

        private readonly IMenuService _menuService;
        private readonly WebsiteOptionsProvider _websiteOptionsProvider;
        private readonly ILinkBuilder _linkBuilder;

        public WebsiteMenuViewComponent(
            IMenuService menuService,
            WebsiteOptionsProvider websiteOptionsProvider,
            ILinkBuilder linkBuilder) {

            menuService.CheckArgumentIsNull(nameof(menuService));
            _menuService = menuService;

            websiteOptionsProvider.CheckArgumentIsNull(nameof(websiteOptionsProvider));
            _websiteOptionsProvider = websiteOptionsProvider;

            linkBuilder.CheckArgumentIsNull(nameof(linkBuilder));
            _linkBuilder = linkBuilder;
        }


        public async Task<IViewComponentResult> InvokeAsync(
            string lang = null,
            string viewName = null
        ) {
            var menu = await _menuService.GetWebsiteMenuAsync(lang);

            var result = new WebsiteMenuViewModel(_linkBuilder) {
                Items = menu.Items.Adapt<IEnumerable<MenuItemViewModel>>(),
                WebsiteId = menu.WebsiteId,
                WebsiteLogo = menu.LogoPath,
                WebsiteTitle = menu.WebsiteTitle
            };
            //result.WebsiteTitle = _websiteInfo.Title;

            //if(logoData != null) {
            //    result.WebsiteLogo = logoData.Value;
            //}

            result.BuildMenuLinks();
            //var menuItems = result.Items.ToList();

            //foreach(var item in menuItems) {
            //    var routeVlaues = new RouteValueDictionary();

            //    if (!string.IsNullOrWhiteSpace(item.Controller))
            //        routeVlaues.Add("controller", item.Controller);
            //    if (!string.IsNullOrWhiteSpace(item.Action))
            //        routeVlaues.Add("action", item.Action);

            //    foreach (var p in item.ParameterPairs) {
            //        routeVlaues.Add(p.Key, p.Value);
            //    }

            //    item.FullActionUrl = Url.RouteUrl(
            //        item.RouteName, routeVlaues
            //        );
            //}

            //result.Items = menuItems;

            if (viewName.IsNotNullOrEmpty())
                return await Task.FromResult(
                    View(viewName, result)
                );

            return await Task.FromResult(
                View(result)
            );
        }

    }
}
