using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Core
{
    public interface IWebsiteInfo
    {
        int Id { get; set; }
        string Name { get; set; }
        string Title { get; set; }
        Guid OwnerId { get; set; }
        string LayoutName { get; set; }
        int DefaultLangId { get; set; }
        string DefaultLangKey { get; set; }
        string Keywords { get; set; }
        string Description { get; set; }
        string ContactEmail { get; set; }
        string ContactPhone { get; set; }
    }

    public class WebsiteInfo : IWebsiteInfo {
        public WebsiteInfo() {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public Guid OwnerId { get; set; }
        public string LayoutName { get; set; }
        public int DefaultLangId { get; set; }
        public string DefaultLangKey { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
    }
}
