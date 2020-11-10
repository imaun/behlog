using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.Admin.ViewModels.Content
{
    public class CreatePostFileViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int OrderNum { get; set; }
    }
}
