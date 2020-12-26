using System;
using System.Collections.Generic;
using Behlog.Core.Models.Enum;

namespace Behlog.Services.Dto.Content
{
    public class PageDetailDto
    {
        public PageDetailDto() {
            RelatedPages = new List<RelatedPageDto>();
        }

        public int Id { get; set; }
        public string Slug { get; set; }
        public int? CategoryId { get; set; }
        public int LangId { get; set; }
        public string LangKey { get; set; }
        public int PostTypeId { get; set; }
        public string PostTypeTitle { get; set; }
        public string PostTypeSlug { get; set; }
        public string CoverPhoto { get; set; }
        public string Title { get; set; }
        public string AltTitle { get; set; }
        public string Body { get; set; }
        public PostBodyType BodyType { get; set; }
        public string Summary { get; set; }
        public string HeaderImage { get; set; }
        public string PagePathDisplay { get; set; }
        public int? ParentId { get; set; }
        public string ParentTitle { get; set; }
        public string IconName { get; set; }
        public int? RelatedPostId { get; set; }
        public string Template { get; set; }
        public IEnumerable<RelatedPageDto> RelatedPages { get; set; }
        public ParentPageDto Parent { get; set; }
        public string TemplateResult { get; set; }
    }

    public class RelatedPageDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AltTitle { get; set; }
        public int? ParentId { get; set; }
        public string ParentTitle { get; set; }
        public string IconName { get; set; }
        public string Slug { get; set; }
        public string PostTypeSlug { get; set; }
        public string LangKey { get; set; }
    }

    public class ParentPageDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string IconName { get; set; }

    }
}
