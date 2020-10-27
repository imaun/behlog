using System;
using System.Collections.Generic;
using Behlog.Core.Models.Enum;
using Behlog.Services.Dto.Core;

namespace Behlog.Services.Dto.Admin.Content {

    public class AdminPostIndexDto
    {
        public AdminPostIndexDto() {
            DataSource = new DataGridDto<AdminPostIndexItemDto>();
        }

        public DataGridDto<AdminPostIndexItemDto> DataSource { get; set; }
        public string PostTypeTitle { get; set; }
        public string PostTypeSlug { get; set; }
    }


    public class AdminPostIndexItemDto {

        public AdminPostIndexItemDto() {
            Tags = new List<string>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime? PublishDate { get; set; }
        public PostStatus Status { get; set; }
        public bool Commenting { get; set; }
        public int PostTypeId { get; set; }
        public string Password { get; set; }
        public int LangId { get; set; }
        public int CategoryId { get; set; }
        public int OrderNumber { get; set; }
        public string LanguageTitle { get; set; }
        public string LangKey { get; set; }
        public string CategoryTitle { get; set; }
        public Guid CreatorUserId { get; set; }
        public Guid ModifierUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string CreatorUserTitle { get; set; }
        public string ModifierUserTitle { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }

    public class AdminPostIndexFilter : DataGridFilter
    {
        public string PostTypeSlug { get; set; }
        public string LangKey { get; set; }
        public string Title { get; set; }
        public int? CategoryId { get; set; }
        public PostStatus? Status { get; set; }
        public Guid? UserId { get; set; }
    }
}
