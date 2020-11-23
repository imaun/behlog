using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Core.Models.Content {

    /// <summary>
    /// Design Blocks for genereting custom <see cref="Post"/> contents.
    /// </summary>
    public class Block {

        public Block() {
            InnerBlocks = new HashSet<Block>();
            PostBlocks = new HashSet<PostBlock>();
            Samples = new HashSet<BlockSample>();
        }

        #region Properties

        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// An Unique Name that we will use to call the Block from Body
        /// </summary>
        public string Name { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Icon { get; set; }
        public string Author { get; set; }
        public string AuthorEmail { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// The HTML source for <see cref="Block"/>
        /// </summary>
        public string Src { get; set; }
        /// <summary>
        /// This property contains JSON body for <see cref="Block"/>'s properties.
        /// </summary>
        public string Attributes { get; set; }
        /// <summary>
        /// Determines that the text used in Block's content is in <see cref="PostBodyType.Html"/> or <see cref="PostBodyType.Markdown"/>
        /// </summary>
        public PostBodyType BodyType { get; set; }
        public string ImagePath { get; set; }
        public Guid? ParentId { get; set; }
        /// <summary>
        /// An array of keywords seperated by comma to represents <see cref="Block"/>'s applications.
        /// </summary>
        public string Keywords { get; set; }

        public Guid AddedByUserId { get; set; }
        #endregion

        #region Navigations

        public Block Parent { get; set; }
        public User AddedByUser { get; set; }
        public ICollection<Block> InnerBlocks { get; set; }
        public ICollection<PostBlock> PostBlocks { get; set; }
        public ICollection<BlockSample> Samples { get; set; }
        #endregion
    }
}
