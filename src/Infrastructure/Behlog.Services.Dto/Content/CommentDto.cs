using Behlog.Core.Models.Enum;
using System;

namespace Behlog.Services.Dto.Content
{
    public class CommentResultDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int PostId { get; set; }
        public string Email { get; set; }
        public string WebUrl { get; set; }
        public string Body { get; set; }
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public string SessionId { get; set; }
        public CommentStatus Status { get; set; }
        public long? ParentId { get; set; }
        public Guid? UserId { get; set; }
        public string UserTitle { get; set; }
        public string PostTitle { get; set; }
    }

    public class CreateCommentDto
    {
        public string Title { get; set; }
        public int PostId { get; set; }
        public string Email { get; set; }
        public string WebUrl { get; set; }
        public string Body { get; set; }
        public long? ParentId { get; set; }
    }
}
