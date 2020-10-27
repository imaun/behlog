using System;
using Behlog.Core.Models.Enum;

namespace Behlog.Services.Dto.System  {
    public class WebsiteCreateDto {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Url { get; set; }
        public Guid OwnerId { get; set; }
        public int DefaultLangId { get; set; }
        public int LayoutId { get; set; }
    }

    public class WebsiteResultDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Url { get; set; }
        public EntityStatus Status { get; set; }
        public Guid OwnerId { get; set; }
        public int DefaultLangId { get; set; }
        public int LayoutId { get; set; }
    }
}
