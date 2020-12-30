using System;
using System.Collections.Generic;
using Behlog.Core.Models.Base;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Feature;
using Behlog.Core.Models.Security;
using Behlog.Core.Models.Shop;
using Behlog.Core.Models.System;

namespace Behlog.Core.Models.Content {
    
    public class Post: HasMetaData {

        public Post() {
            Comments = new HashSet<Comment>();
            PostFiles = new HashSet<PostFile>();
            Likes = new HashSet<PostLike>();
            Meta= new HashSet<PostMeta>();
            PostTags = new HashSet<PostTag>();
            Visits = new HashSet<PostVisit>();
            RelatedSections = new HashSet<Section>();
        }

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public PostBodyType BodyType { get; set; }
        public string Summary { get; set; }
        public DateTime? PublishDate { get; set; }
        public PostStatus Status { get; set; }
        public bool Commenting { get; set; }
        public int PostTypeId { get; set; }
        public string Password { get; set; }
        public int LangId { get; set; }
        public int? CategoryId { get; set; }
        public string CoverPhoto { get; set; }
        public int? ParentId { get; set; }
        public string CategoryPath { get; set; }
        public string AltTitle { get; set; }
        public int? LayoutId { get; set; }
        public int OrderNumber { get; set; }
        public int WebsiteId { get; set; }
        /// <summary>
        /// Determines that this Post will be used as a ViewComponent.
        /// </summary>
        public bool IsComponent { get; set; }
        public string IconName { get; set; }
        public int? RelatedPostId { get; set; }
        /// <summary>
        /// An Html or Markdown template which contains fields that will be replaced by it's data and display instead of the <see cref="Body"/>.
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// Path of the View
        /// </summary>
        public string ViewPath { get; set; }

        #endregion

        #region Shopping 

        public int? ProductId { get; set; }

        #endregion

        #region SEO Related

        public string MetaDescription { get; set; }
        public string MetaRobots { get; set; }

        #endregion

        #region Navigations
        public Website Website { get; set; }
        public User CreatorUser { get; set; }
        public User ModifierUser { get; set; }
        public PostType PostType { get; set; }
        public Language Language { get; set; }
        public Category Category { get; set; }
        public Layout Layout { get; set; }
        public Product Product { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostFile> PostFiles { get; set; }
        public ICollection<PostLike> Likes { get; set; }
        public ICollection<PostMeta> Meta { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
        public ICollection<PostVisit> Visits { get; set; }
        public ICollection<Section> RelatedSections { get; set; }
        #endregion
    }
}
