using System;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Security;

namespace Behlog.Core.Models.Content {
    
    public class Comment {
        public Comment() {

        }

        #region Properties
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
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public Guid? ModifierUserId { get; set; }
        #endregion

        #region Navigations
        public User User { get; set; }
        public User ModifierUser { get; set; }
        public Post Post { get; set; }

        #endregion
    }
}
