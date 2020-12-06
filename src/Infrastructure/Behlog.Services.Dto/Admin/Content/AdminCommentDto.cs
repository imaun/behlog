using System;
using Behlog.Core.Models.Enum;
using Behlog.Services.Dto.Core;

namespace Behlog.Services.Dto.Admin.Content
{
    public class AdminCommentIndexDto
    {
        public AdminCommentIndexDto() {
            DataSource = new DataGridDto<AdminCommentIndexItemDto>();
        }

        public DataGridDto<AdminCommentIndexItemDto> DataSource { get; set; }
    }

    public class AdminCommentIndexItemDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int PostId { get; set; }
        public string Email { get; set; }
        public string WebUrl { get; set; }
        public string Body { get; set; }
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public CommentStatus Status { get; set; }
        public long? ParentId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public Guid? ModifierUserId { get; set; }
        public string UserTitle { get; set; }
        public string ModifierUserTitle { get; set; }
        public string PostTitle { get; set; }
    }

    public class AdminCommentIndexFilter: DataGridFilter
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public CommentStatus? Status { get; set; }
    }
}
