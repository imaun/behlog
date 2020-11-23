using System;
using Behlog.Core.Models.Security;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.Content {

    public class PostBlock {

        public PostBlock() { }

        #region Properties
        public long Id { get; set; }
        public int PostId { get; set; }
        public Guid BlockId { get; set; }
        public Guid UserId { get; set; }
        public int OrderNumber { get; set; }
        public PostBlockStatus Status { get; set; }
        public string OutputSrc { get; set; } //Rendered HTML src for this Block
        #endregion

        #region Navigations

        public Post Post { get; set; }
        public Block Block { get; set; }
        public User User { get; set; }

        #endregion
    }
}
