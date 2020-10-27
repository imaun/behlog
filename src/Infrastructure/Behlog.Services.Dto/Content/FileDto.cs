using Behlog.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Services.Dto.Content
{

    public class FileResultDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public PostFileType FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public FileStatus Status { get; set; }
        public int WebsiteId { get; set; }
    }

    public class CreateFileDto
    {
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string FileServerPath { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
