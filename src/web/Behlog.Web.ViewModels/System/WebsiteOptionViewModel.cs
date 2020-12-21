using Behlog.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.ViewModels.System
{
    public class WebsiteOptionViewModel
    {
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
}
