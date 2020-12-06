using System;
using System.Collections.Generic;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Web.Admin.ViewModels.Core;
using Behlog.Web.Core.Extensions;
using DNTPersianUtils.Core;

namespace Behlog.Web.Admin.ViewModels.Content {
    
    public class AdminPostIndexViewModel {
        public AdminPostIndexViewModel() {
            DataSource = new DataGridViewModel<AdminPostIndexItemViewModel>();
        }

        public DataGridViewModel<AdminPostIndexItemViewModel> DataSource { get; set; }
        public string PostTypeTitle => PostTypeSlug.GetPostTypeDisplayName();
        public string PostTypeSlug { get; set; }
    }

    public class AdminPostIndexItemViewModel {

        public AdminPostIndexItemViewModel() {
            Tags = new List<string>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime? PublishDate { get; set; }
        public PostStatus Status { get; set; }
        public bool Commenting { get; set; }
        public int PostTypeId { get; set; }
        public string Password { get; set; }
        public int LangId { get; set; }
        public int CategoryId { get; set; }
        public int OrderNumber { get; set; }
        public string LanguageTitle { get; set; }
        public string LangKey { get; set; }
        public string CategoryTitle { get; set; }
        public string PublishDateDisplay => PublishDate?.ToPersianDateTextify();
        public string StatusDisplay => Status.ToDisplay();
        public Guid CreatorUserId { get; set; }
        public Guid ModifierUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string CreatorUserTitle { get; set; }
        public string ModifierUserTitle { get; set; }
        public string CreateDateDisplay => CreateDate.ToPersianDateTextify();
        public string ModifyDateDisplay => ModifyDate.ToPersianDateTextify();
        public IEnumerable<string> Tags { get; set; }
    }

}
