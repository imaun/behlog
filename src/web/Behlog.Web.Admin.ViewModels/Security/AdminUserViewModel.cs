using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Web.Admin.ViewModels.Core;
using Behlog.Web.Common.Extensions;
using DNTPersianUtils.Core;
using Behlog.Resources.Strings;
using Behlog.Web.Admin.ViewModels.Extensions;

namespace Behlog.Web.Admin.ViewModels.Security {
    
    public class AdminUserIndexViewModel {

        public AdminUserIndexViewModel() {
            Filter = new AdminUserFilterViewModel();
            DataSource = new DataGridViewModel<AdminUserIndexItemViewModel>();
        }

        public AdminUserFilterViewModel Filter { get; set; }
        public DataGridViewModel<AdminUserIndexItemViewModel> DataSource { get; set; }
        public string CheckedItems { get; set; }
    }

    public class AdminUserIndexItemViewModel {
        public Guid Id { get; set; }
        public bool Checked { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public UserStatus Status { get; set; }
        public string StatusDisplay => Status.ToDisplay();
        public string WebUrl { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string UserName { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterDateDisplay => RegisterDate.ToFriendlyPersianDateTextify();
        public string Description { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }

    public class AdminUserFilterViewModel: DataGridFilterViewModel {

        public string Title { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserStatus? Status => StatusValue.ToUserStatus();
        public string StatusValue { get; set; }
        public string UserName { get; set; }
        public IList<SelectListItem> StatusSource {
            get {
                var result = new List<SelectListItem> {
                    new SelectListItem(
                        AppTextDisplay.DropDownNoSelect,
                        "", selected: true)
                };
                result.AddRange(Status.ToSelectListItems());
                return result;
            }
        }
    }

    public class AdminCreateUserViewModel {
        public string Title { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }
        public string WebUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    }

}
