using System;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Security;

namespace Behlog.Core.Models.Shop
{
    /// <summary>
    /// Represents a <see cref="Shop.Customer"/>'s or anyone else's Review for a <see cref="Shop.Product"/>
    /// </summary>
    public class ProductReview {

        public ProductReview() {
        }

        #region Properties
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int Rating { get; set; }
        public int VoteYesCount { get; set; }
        public int VoteNoCount { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public PostBodyType BodyType { get; set; }
        public int? ParentId { get; set; }
        public ProductReviewStatus Status { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public string SessionId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public Guid? ModifierUserId { get; set; }
        #endregion

        #region Navigations
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public User ModifierUser { get; set; }
        #endregion
    }
}
