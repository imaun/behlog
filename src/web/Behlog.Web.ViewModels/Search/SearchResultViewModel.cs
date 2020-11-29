using Behlog.Core;
using Behlog.Web.Common.Extensions;
using DNTPersianUtils.Core;
using System;
using System.Collections.Generic;

namespace Behlog.Web.ViewModels.Search {
    
    public class SearchPostResultViewModel {
        
        public SearchPostResultViewModel() {
            Items = new List<SearchPostItemViewModel>();
        }

        public IEnumerable<SearchPostItemViewModel> Items { get; set; }
        public string SearchPhrase { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class SearchPostItemViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string LimitedTitle(int len) => Title.GetLimitedSummary(len);
        public string AltTitle { get; set; }
        public string Slug { get; set; }
        public DateTime? PublishDate { get; set; }
        public string PublishDateDisplay => PublishDate?.ToPersianDateTextify();
        public string Summary { get; set; }
        public string LimitedSummary(int len) => Summary.GetLimitedSummary(len);
        public string Body { get; set; }
        public string CoverPhoto { get; set; }
        public string CoverPhotoPath => CoverPhoto.GetFullImagePath();
        public int PostTypeId { get; set; }
        public string PostTypeSlug { get; set; }
        public string PostTypeTitle { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public int LangId { get; set; }
        public string LangKey { get; set; }
        public string LangTitle { get; set; }
        public int OrderNumber { get; set; }
        public string CreatorUserTitle { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
