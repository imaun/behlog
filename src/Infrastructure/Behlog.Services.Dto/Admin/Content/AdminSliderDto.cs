using Behlog.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Services.Dto.Admin.Content
{
    public class AdminSliderResultDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public int LangId { get; set; }
        public bool Enabled { get; set; }
        public IEnumerable<AdminSliderResultItemDto> Items { get; set; }
    }

    public class AdminSliderResultItemDto
    {
        public long PostFileId { get; set; }
        public long FileId { get; set; }
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int OrderNum { get; set; }
    }

    public class AdminCreateSliderDto
    {
        public AdminCreateSliderDto() {
            Items = new List<AdminCreateSliderItemDto>();
        }

        public string Title { get; set; }
        public string Slug { get; set; }
        public int LangId { get; set; }
        public bool Enabled { get; set; }
        public IEnumerable<AdminCreateSliderItemDto> Items { get; set; }
    }

    public class AdminCreateSliderItemDto
    {
        public long? FileId { get; set; }
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int OrderNum { get; set; }
    }
}
