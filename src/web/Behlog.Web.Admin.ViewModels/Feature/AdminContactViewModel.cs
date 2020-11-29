using System;
using System.Collections.Generic;
using System.Text;
using DNTPersianUtils.Core;
using Behlog.Web.Admin.ViewModels.Core;

namespace Behlog.Web.Admin.ViewModels.Feature
{
    public class AdminContactIndexViewModel
    {
        public AdminContactIndexViewModel() {
            DataSource = new DataGridViewModel<AdminContactIndexItemViewModel>();
        }

        public DataGridViewModel<AdminContactIndexItemViewModel> DataSource { get; set; }
    }

    public class AdminContactIndexItemViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public string SessionId { get; set; }
        public DateTime SentDate { get; set; }
        public string SentDateDisplay => SentDate.ToFriendlyPersianDateTextify();
    }
}
