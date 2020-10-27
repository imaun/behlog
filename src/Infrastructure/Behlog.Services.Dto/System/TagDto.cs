using Behlog.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Services.Dto.System
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; }
    }
}
