using System;
using Behlog.Core.Models.Enum;
using System.Collections.Generic;

namespace Behlog.Services.Dto.Content
{

    public class GalleryDto
    {
        public GalleryDto() {
            Posts = new List<PostFileGalleryDto>();
            Categories = new List<GalleryCategoryItemDto>();
        }

        public string Title { get; set; }
        public IEnumerable<PostFileGalleryDto> Posts { get; set; }
        public IEnumerable<GalleryCategoryItemDto> Categories { get; set; }
    }

    public class PostFileGalleryDto
    {
        public PostFileGalleryDto() {
            Files = new List<PostFileGalleryItemDto>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string AltTitle { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public DateTime? PublishDate { get; set; }
        public int PostTypeId { get; set; }
        public int LangId { get; set; }
        public string CoverPhoto { get; set; }
        public int? CategoryId { get; set; }
        public string IconName { get; set; }
        public string ViewPath { get; set; }
        public IEnumerable<PostFileGalleryItemDto> Files { get; set; }
    }

    public class PostFileGalleryItemDto {
        public long Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public PostFileType FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }

    public class GalleryCategoryItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
    }
}
