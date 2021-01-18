using Behlog.Core.Models.Enum;
using Behlog.Resources.Strings;

namespace Behlog.Core.Extensions
{
    public static class ModelExtensions
    {

        public static string ToDisplay(this PostStatus status) =>
            status switch {
                PostStatus.Deleted => AppTextDisplay.PostStatusDeleted,
                PostStatus.Draft => AppTextDisplay.PostStatusDraft,
                PostStatus.Planned => AppTextDisplay.PostStatusPlanned,
                PostStatus.Published => AppTextDisplay.PostStatusPublished,
                _ => AppTextDisplay.StatusUnknown,
            };


        public static string ToDisplay(this CommentStatus status) =>
            status switch {
                CommentStatus.Approved => AppTextDisplay.CommentStatusApproved,
                CommentStatus.Deleted => AppTextDisplay.CommentStatusDeleted,
                CommentStatus.Read => AppTextDisplay.CommentStatusRead,
                CommentStatus.Rejected => AppTextDisplay.CommentStatusRejected,
                CommentStatus.Spam => AppTextDisplay.CommentStatusSpam,
                CommentStatus.Viewed => AppTextDisplay.CommentStatusViewed,
                CommentStatus.Waiting => AppTextDisplay.CommentStatusWaiting,
                _ => AppTextDisplay.StatusUnknown
            };

        public static string ToDisplay(this ContactMessageStatus status) =>
            status switch {
                ContactMessageStatus.Deleted => AppTextDisplay.ContactMessageStatusDeleted,
                ContactMessageStatus.Read => AppTextDisplay.ContactMessageStatusRead,
                ContactMessageStatus.Sent => AppTextDisplay.ContactMessageStatusSent,
                ContactMessageStatus.Spam => AppTextDisplay.ContactMessageStatusSpam,
                ContactMessageStatus.Viewed => AppTextDisplay.ContactMessageStatusViewed,
                _ => AppTextDisplay.StatusUnknown
            };

        public static string ToDisplay(this EntityStatus status) =>
            status switch {
                EntityStatus.Deleted => AppTextDisplay.StatusDeleted,
                EntityStatus.Disabled => AppTextDisplay.StatusDisable,
                EntityStatus.Enabled => AppTextDisplay.StatusEnable,
                _ => AppTextDisplay.StatusUnknown
            };

        public static string ToDisplay(this FileStatus status) =>
            status switch { 
                FileStatus.AttachedToPost => AppTextDisplay.FileStatusAttachedToPost,
                FileStatus.Deleted => AppTextDisplay.FileStatusDeleted,
                FileStatus.Hidden => AppTextDisplay.FileStatusHidden,
                FileStatus.UnAttached => AppTextDisplay.FileStatusUnAttached,
                _=> AppTextDisplay.StatusUnknown
            };


        public static string ToDisplay(this FormFieldType fieldType) =>
            fieldType switch {
                FormFieldType.Date => AppTextDisplay.FormFieldTypeDate,
                FormFieldType.Decimal => AppTextDisplay.FormFieldTypeDecimal,
                FormFieldType.File => AppTextDisplay.FormFieldTypeFile,
                FormFieldType.Integer => AppTextDisplay.FormFieldTypeInteger,
                FormFieldType.MultiSelect => AppTextDisplay.FormFieldTypeMultiSelect,
                FormFieldType.Select => AppTextDisplay.FormFieldTypeSelect,
                FormFieldType.Text => AppTextDisplay.FormFieldTypeText,
                _=> AppTextDisplay.FormFieldTypeText
            };

        public static string ToDisplay(this PostBodyType bodyType) =>
            bodyType switch {
                PostBodyType.Html => AppTextDisplay.PostBodyTypeHtml,
                PostBodyType.Markdown => AppTextDisplay.PostBodyTypeMarkdown,
                PostBodyType.Text => AppTextDisplay.PostBodyTypeText,
                _=> AppTextDisplay.StatusUnknown
            };

        public static string ToDisplay(this SubscriberStatus status) =>
            status switch
            {
                SubscriberStatus.Deleted => AppTextDisplay.StatusDeleted,
                SubscriberStatus.Enabled => AppTextDisplay.StatusEnable,
                SubscriberStatus.Unsubscribed => AppTextDisplay.Unsubscribed,
                _=> AppTextDisplay.StatusUnknown
            };

        public static string ToDisplay(this UserStatus status) =>
            status switch
            {
                UserStatus.Blocked => AppTextDisplay.UserStatusBlocked,
                UserStatus.Deleted => AppTextDisplay.UserStatusDeleted,
                UserStatus.Disabled => AppTextDisplay.UserStatusDisabled,
                UserStatus.Enabled => AppTextDisplay.UserStatusEnabled,
                _=> AppTextDisplay.StatusUnknown
            };

        public static string ToDisplay(this ProductStatus status) =>
            status switch
            {
                ProductStatus.Deleted => AppTextDisplay.StatusDeleted,
                ProductStatus.Disbaled => AppTextDisplay.StatusDisable,
                ProductStatus.Enabled => AppTextDisplay.StatusEnable,
                ProductStatus.OutOfStock => AppTextDisplay.ProductStatusOurOfStock,
                ProductStatus.WaitingToProduce => AppTextDisplay.ProductStatusWaitingToProduce,
                ProductStatus.PreOrder => AppTextDisplay.ProductStatusPreOrder,
                _ => AppTextDisplay.StatusUnknown
            };

        public static string ToDisplay(this BasketStatus status) =>
            status switch
            {
                BasketStatus.Abandoned => "",
                BasketStatus.Active => "",
                BasketStatus.Completed => "",
                BasketStatus.Deleted => "",
                BasketStatus.Failed => "",
                _ => AppTextDisplay.StatusUnknown
            };

        public static string ToDisplay(this BasketItemStatus status) =>
            status switch
            {
                BasketItemStatus.Added => "",
                BasketItemStatus.Deleted => "",
                BasketItemStatus.Invoiced => "",
                _ => AppTextDisplay.StatusUnknown
            };

        public static string ToDisplay(this InvoiceStatus status)
            => status switch
            {
                InvoiceStatus.Deleted => AppTextDisplay.StatusDeleted,
                InvoiceStatus.Issued => AppTextDisplay.InvoiceStatusIssued,
                InvoiceStatus.Paid => AppTextDisplay.InvoiceStatusPaid,
                InvoiceStatus.PreOrder => AppTextDisplay.InvoiceStatusPreOrder,
                _ => AppTextDisplay.StatusUnknown
            };

        public static string ToDisplay(this InvoiceOrderStatus status)
            => status switch
            {
                InvoiceOrderStatus.Added => AppTextDisplay.OrderStatusAddedd,
                InvoiceOrderStatus.Deleted => AppTextDisplay.StatusDeleted,
                InvoiceOrderStatus.Paid => AppTextDisplay.OrderStatusPaid,
                _=> AppTextDisplay.OrderStatusAddedd
            };

        public static InvoiceOrderStatus GetOrderStatus(this InvoiceStatus status)
            => status switch
            {
                InvoiceStatus.Deleted => InvoiceOrderStatus.Deleted,
                InvoiceStatus.Issued => InvoiceOrderStatus.Added,
                InvoiceStatus.Paid => InvoiceOrderStatus.Paid,
                InvoiceStatus.PreOrder => InvoiceOrderStatus.Added,
                _ => InvoiceOrderStatus.Added
            };
    }
}
