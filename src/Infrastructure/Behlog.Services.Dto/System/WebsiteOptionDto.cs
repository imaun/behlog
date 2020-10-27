using System;
using System.Collections.Generic;
using System.Text;
using Behlog.Core.Models.Enum;

namespace Behlog.Services.Dto.System
{
    public class WebsiteOptionResultDto
    {
        public int Id { get; set; }
        public int WebsiteId { get; set; }
        public string Title { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Category { get; set; }
        public int OrderNum { get; set; }
        public EntityStatus Status { get; set; }
        public string Description { get; set; }
        public int? LangId { get; set; }
    }

    public class WebsiteOptionCategoryDto {
        public WebsiteOptionCategoryDto() {
            Items = new List<WebsiteOptionCategoryItemDto>();
        }
        public string Category { get; set; }
        public int? LangId { get; set; }
        public IEnumerable<WebsiteOptionCategoryItemDto> Items { get; set; }
    }

    public class WebsiteOptionCategoryItemDto {
        public string Title { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int OrderNum { get; set; }
    }

    public class CreateWebsiteOptionDto {
        public string Title { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Category { get; set; }
        public int OrderNum { get; set; }
        public EntityStatus Status { get; set; }
        public string Description { get; set; }
        public int? LangId { get; set; }
    }

    public class UpdateWebsiteOptionDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Category { get; set; }
        public int OrderNum { get; set; }
        public EntityStatus Status { get; set; }
        public string Description { get; set; }
        public int? LangId { get; set; }
    }

    public class WebsiteContactInfoDto {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phones { get; set; }
        public string Email { get; set; }
        public string Copyright { get; set; }
    }

    public class WebsiteSocialNetworkDto {
        public string Telegram { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
        public string Whatsapp { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string YouTube { get; set; }
    }


}
