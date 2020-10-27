using System;
using Behlog.Core.Models.Security;

namespace Behlog.Core.Models.Content {
    
    public class PostLike {
        public PostLike() {

        }

        #region Properties
        public long Id { get; set; }
        public int PostId { get; set; }
        public string SessionId { get; set; }
        public Guid? UserId { get; set; }
        public string IP { get; set; }
        public DateTime CreateDate { get; set; }

        #endregion

        #region Navigations
        public Post Post { get; set; }
        public User User { get; set; }

        #endregion

    }
}
