using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Behlog.Core.Extensions;
using Behlog.Web.Common.Extensions;
using Behlog.Services.Contracts.Http;

namespace Behlog.Web.ViewModels.System
{
    public class WebsiteMenuViewModel {

        private readonly ILinkBuilder _linkBuilder;

        public WebsiteMenuViewModel(ILinkBuilder linkBuilder) {
            Items = new List<MenuItemViewModel>();
            _linkBuilder = linkBuilder;
        }

        public string WebsiteTitle { get; set; }
        public int WebsiteId { get; set; }
        public string WebsiteLogo { get; set; }
        public string WebsiteLogoFullUrl => WebsiteLogo.GetFullUrl();
        public IEnumerable<MenuItemViewModel> Items { get; set; }
        public List<MenuItemViewModel> Root => GetSubItems();
        public List<MenuItemViewModel> GetSubItems(int? parentId = null)
            => Items.Where(_ => _.ParentId == parentId)
                .OrderBy(_=> _.OrderNumber)
                .ToList();

        public bool HasSubItems(int itemId) =>
            Items.Any(_ => _.ParentId == itemId);

        public void BuildMenuLinks() {
            var menuItems = Items.ToList();
            foreach(var item in menuItems) {
                if (item.Url.IsNotNullOrEmpty() && _linkBuilder.UrlIsValid(item.Url))
                    item.FullActionUrl = item.Url;
                if (item.RouteName.IsNotNullOrEmpty())
                    item.FullActionUrl = _linkBuilder
                        .BuildFromRoute(item.RouteName, item.RouteValues);
            }
            Items = menuItems;
        }
    }

    public class MenuItemViewModel {

        public MenuItemViewModel() {
            ParameterPairs = new Dictionary<string, string>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        private string _parameters;
        public string Parameters {
            get => _parameters;
            set {
                if(value != _parameters) {
                    _parameters = value;
                    loadParametersPairs();
                }
            }
        }
        public bool Active { get; set; }
        public string RouteName { get; set; }
        public string FullActionUrl { get; set; }
        //public string FullActionUrl {
        //    get {
        //        if (Url.IsNotNullOrEmpty())
        //            return Url;

        //        if (RouteName.IsNotNullOrEmpty())
        //            return _linkBuilder
        //                .BuildFromRoute(RouteName, getRouteValues());

        //        return string.Empty;
        //    }
        //}
        public int OrderNumber { get; set; }
        public Dictionary<string, string> ParameterPairs { get; set; }
        public RouteValueDictionary RouteValues => getRouteValues();
        
        private RouteValueDictionary getRouteValues() {
            var routeVlaues = new RouteValueDictionary();

            if (!string.IsNullOrWhiteSpace(Controller))
                routeVlaues.Add("controller", Controller);
            if (!string.IsNullOrWhiteSpace(Action))
                routeVlaues.Add("action", Action);

            foreach (var p in ParameterPairs) {
                routeVlaues.Add(p.Key, p.Value);
            }

            return routeVlaues;
        }

        private void loadParametersPairs() {
            if (string.IsNullOrWhiteSpace(_parameters))
                return;

            var queryStringSlices = _parameters.Split("&");
            foreach(var queryStr in queryStringSlices) {
                var key = queryStr.Split("=")[0];
                var value = queryStr.Split("=")[1];
                ParameterPairs.Add(key, value);
            }
        }
    }
}
