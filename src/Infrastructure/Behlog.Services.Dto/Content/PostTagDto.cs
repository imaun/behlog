using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Services.Dto.Content
{
    public class PostTagItemDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
    }
}
