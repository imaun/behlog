using System;
using System.Collections.Generic;

namespace Behlog.Services.Dto.Content {

    public class FrontSearchResultDto {

        public FrontSearchResultDto() {
            Items = new List<SearchResultItemDto>();
        }

        public IEnumerable<SearchResultItemDto> Items { get; set; }
        public int TotalCount { get; set; }
    }

    public class SearchResultItemDto {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string AltTitle { get; set; }
        public string Slug { get; set; }
        public DateTime? PublishDate { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string CoverPhoto { get; set; }
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
