using System;
using System.Collections.Generic;
using System.Text;
using Behlog.Web.Common.Extensions;
using Behlog.Web.ViewModels.Core;

namespace Behlog.Web.ViewModels.Content
{
    public class PostMetaListViewModel: BaseViewModel {
        public PostMetaListViewModel() {
            Items = new List<PostMetaItemViewModel>();
        }

        public string PostTitle { get; set; }
        public string PostSlug { get; set; }
        public string LangKey { get; set; }
        public IList<PostMetaItemViewModel> Items { get; set; }
    }

    public class PostMetaItemViewModel: BaseViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
        public string Category { get; set; }
        public string IconName { get; set; }
        public string CoverPhoto { get; set; }
        public string CoverPhotoPath => CoverPhoto.GetFullImagePath();
        public int OrderNumber { get; set; }
    }
}
