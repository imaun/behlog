using Behlog.Web.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.ViewModels.Content {

    public class LinkViewModel: BaseViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryText { get; set; }
        public string Target { get; set; }
        public string Description { get; set; }
    }

    public class LinkCategoryViewModel: BaseViewModel {
        public LinkCategoryViewModel() {
            Links = new List<LinkViewModel>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public IEnumerable<LinkViewModel> Links { get; set; }
    }
}
