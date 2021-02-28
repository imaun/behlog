using System;
using System.Collections.Generic;
using System.Text;
using Behlog.Core.Models.Enum;

namespace Behlog.Web.Admin.ViewModels.Content
{
    public class AdminSliderViewModel
    {

    }

    public class AdminSliderItemViewModel
    {

    }

    public class CreateSliderViewModel
    {
        public CreateSliderViewModel() {
            Items = new List<CreateSliderItemViewModel>();
        }

        public string Title { get; set; }
        public string Slug { get; set; }
        public int LangId { get; set; }
        public bool Enabled { get; set; }
        public IEnumerable<CreateSliderItemViewModel> Items { get; set; }
    }

    public class CreateSliderItemViewModel
    {
        public int? FileId { get; set; }
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int OrderNum { get; set; }
    }
}
