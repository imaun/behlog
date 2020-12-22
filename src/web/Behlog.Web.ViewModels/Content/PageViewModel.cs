using System.Collections.Generic;
using Behlog.Core;
using Behlog.Web.Core.Extensions;
using Behlog.Web.Common.Extensions;
using Behlog.Web.ViewModels.Core;

namespace Behlog.Web.ViewModels.Content
{
    public class PageDetailViewModel: BaseViewModel
    {
        public PageDetailViewModel() {
            RelatedPages = new List<RelatedPageViewModel>();
        }

        public int Id { get; set; }
        public string Slug { get; set; }
        public int? CategoryId { get; set; }
        public int LangId { get; set; }
        public string LangKey { get; set; }
        public int PostTypeId { get; set; }
        public string PostTypeTitle => PostTypeSlug.GetPostTypeDisplayName();
        public string PostTypeSlug { get; set; }
        public string Title { get; set; }
        public string AltTitle { get; set; }
        public string Body { get; set; }
        public string Summary { get; set; }
        public string CoverPhoto { get; set; }
        public string CoverPhotoPath => CoverPhoto.GetFullImagePath();
        public string HeaderImage { get; set; }
        public string PagePathDisplay { get; set; }
        public int? ParentId { get; set; }
        public bool HasParent => ParentId.HasValue;
        public string ParentTitle { get; set; }
        public string IconName { get; set; }
        public int? RelatedPostId { get; set; }
        public string Template { get; set; }
        public IEnumerable<RelatedPageViewModel> RelatedPages { get; set; }
        public ParentPageViewModel Parent { get; set; }
        public bool Commented { get; set; }
    }

    public class RelatedPageViewModel: BaseViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AltTitle { get; set; }
        public int? ParentId { get; set; }
        public string ParentTitle { get; set; }
        public string Slug { get; set; }
        public string PostTypeSlug { get; set; }
        public string IconName { get; set; }
    }

    public class ParentPageViewModel: BaseViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
    }
    
}
