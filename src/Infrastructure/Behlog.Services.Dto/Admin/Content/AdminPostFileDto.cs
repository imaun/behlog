using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Services.Dto.Admin.Content
{
    public class CreatePostFileDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int OrderNum { get; set; }
        public long? FileId { get; set; }
    }
}
