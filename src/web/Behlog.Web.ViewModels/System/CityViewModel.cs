using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.ViewModels.System
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ParentTitle { get; set; }
    }
}
