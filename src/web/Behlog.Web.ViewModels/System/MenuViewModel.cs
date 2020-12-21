using System.Collections.Generic;
using System.Linq;
using Behlog.Web.Common.Extensions;

namespace Behlog.Web.ViewModels.System
{
    public class WebsiteMenuViewModel
    {
        public WebsiteMenuViewModel() {
            Items = new List<MenuItemViewModel>();
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
        public string StyleClassName { get; set; }
        //public string FullActionUrl {
        //    get {
        //        if (!string.IsNullOrWhiteSpace(Url))
        //            return Url;
        //        var rootUrl = AppHttpContext.BaseUrl;
        //        var result = $"{rootUrl}/{Controller}/{Action}/";
                
        //        return result;
        //    }
        //}
        public string RouteName { get; set; }
        public string FullActionUrl { get; set; }
        public int OrderNumber { get; set; }
        public Dictionary<string, string> ParameterPairs { get; set; }
     
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
