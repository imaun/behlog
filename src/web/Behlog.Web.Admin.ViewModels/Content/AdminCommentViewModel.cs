using System;
using DNTPersianUtils.Core;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Web.Admin.ViewModels.Core;

namespace Behlog.Web.Admin.ViewModels.Content {

    public class AdminCommentIndexViewModel {
        public AdminCommentIndexViewModel() {
            DataSource = new DataGridViewModel<AdminCommentIndexItemViewModel>();
            Filter = new AdminCommentFilterViewModel();
        }

        public DataGridViewModel<AdminCommentIndexItemViewModel> DataSource { get; set; }
        public AdminCommentFilterViewModel Filter { get; set; }
    }

    public class AdminCommentIndexItemViewModel {
        public long Id { get; set; }
        public string Title { get; set; }
        public int PostId { get; set; }
        public string Email { get; set; }
        public string WebUrl { get; set; }
        public string Body { get; set; }
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public CommentStatus Status { get; set; }
        public string StatusDisplay => Status.ToDisplay();
        public long? ParentId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateDateDisplay => CreateDate.ToPersianDateTextify();
        public DateTime? ModifyDate { get; set; }
        public string ModifyDateDisplay => ModifyDate?.ToPersianDateTextify();
        public Guid? ModifierUserId { get; set; }
        public string UserTitle { get; set; }
        public string ModifierUserTitle { get; set; }
        public string PostTitle { get; set; }
    }

    public class AdminCommentFilterViewModel: DataGridFilterViewModel
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public CommentStatus? Status { get; set; }
    }
}
