using System;
using DNTPersianUtils.Core;
using Behlog.Core.Models.Enum;
using Behlog.Web.Admin.ViewModels.Core;

namespace Behlog.Web.Admin.ViewModels.Feature
{
    public class AdminContactIndexViewModel
    {
        public AdminContactIndexViewModel() {
            DataSource = new DataGridViewModel<AdminContactIndexItemViewModel>();
            Filter = new AdminContactFilterViewModel();
        }

        public DataGridViewModel<AdminContactIndexItemViewModel> DataSource { get; set; }
        public AdminContactFilterViewModel Filter { get; set; }
    }

    public class AdminContactIndexItemViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public string SessionId { get; set; }
        public DateTime SentDate { get; set; }
        public string SentDateDisplay => SentDate.ToFriendlyPersianDateTextify();
        public ContactMessageStatus Status { get; set; }
        public DateTime? ReadDate { get; set; }
        public string ReadDateDisplay => ReadDate?.ToFriendlyPersianDateTextify();
    }

    public class AdminContactFilterViewModel: DataGridFilterViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
