using System;
using System.Collections.Generic;
using System.Text;
using Behlog.Core.Models.Enum;

namespace Behlog.Services.Dto.System
{
    public class LayoutCreateDto {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorWebUrl { get; set; }
        public string Path { get; set; }
        public int OrderNumber { get; set; }
        public EntityStatus Status { get; set; }
        public bool IsRtl { get; set; }
    }

    public class LayoutResultDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorWebUrl { get; set; }
        public string Path { get; set; }
        public int OrderNumber { get; set; }
        public EntityStatus Status { get; set; }
        public bool IsRtl { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
