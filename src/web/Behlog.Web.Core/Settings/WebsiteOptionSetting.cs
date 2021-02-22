using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.Core.Settings
{
    public class WebsiteOptionSetting
    {
        public int WebsiteId { get; set; }
        public string LangKey { get; set; }
        public string LogoPath { get; set; }
        public string FavIconPath { get; set; }
        public WebsiteContactSetting Contact { get; set; }
        public WebsiteSocialNetworksSetting SocialNetworks { get; set; }
    }

    public class WebsiteContactSetting {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phones { get; set; }
        public string Email { get; set; }
        public string Copyright { get; set; }
    }

    public class WebsiteSocialNetworksSetting {
        public string Telegram { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
        public string Whatsapp { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string YouTube { get; set; }
    }


}
