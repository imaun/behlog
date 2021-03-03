using System.Collections.Generic;

namespace Behlog.Services.Dto.System
{
    public class WebsiteMenuDto
    {
        public WebsiteMenuDto() {
            Items = new List<MenuItemDto>();
        }

        public int WebsiteId { get; set; }
        public string WebsiteTitle { get; set; }
        public string LogoPath { get; set; }
        public IEnumerable<MenuItemDto> Items { get; set; }
    }

    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Parameters { get; set; }
        public string RouteName { get; set; }
        public int OrderNumber { get; set; }
    }
}
