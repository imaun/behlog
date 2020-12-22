using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Services.Dto.Content
{


    public class PostMetaListDto {
        public PostMetaListDto() {
            Items = new List<PostMetaItemDto>();
        }

        public string PostTitle { get; set; }
        public string PostSlug { get; set; }
        public string LangKey { get; set; }
        public IEnumerable<PostMetaItemDto> Items { get; set; }
    }

    public class PostMetaItemDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
        public string Category { get; set; }
        public string IconName { get; set; }
        public string CoverPhoto { get; set; }
        public int OrderNumber { get; set; }
    }

}
