using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.ViewModels.Content
{
    public class PostMetaListViewModel {
        public PostMetaListViewModel() {
            Items = new List<PostMetaItemViewModel>();
        }

        public string PostTitle { get; set; }
        public string PostSlug { get; set; }
        public string LangKey { get; set; }
        public IEnumerable<PostMetaItemViewModel> Items { get; set; }
    }

    public class PostMetaItemViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
        public string Category { get; set; }
    }
}
