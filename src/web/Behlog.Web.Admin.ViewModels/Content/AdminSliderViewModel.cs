using System;
using System.Collections.Generic;
using System.Text;
using Behlog.Core.Models.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IEnumerable<SelectListItem> LanguageSelectList { get; set; }
    }

    public class EditSliderViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public int LangId { get; set; }
        public bool Enabled { get; set; }
        public IEnumerable<EditSliderItemViewModel> Items { get; set; }
        public IEnumerable<SelectListItem> LanguageSelectList { get; set; }
    }

    public class EditSliderItemViewModel {
        public long PostFileId { get; set; }
        public long? FileId { get; set; }
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int OrderNum { get; set; }
    }

    public class CreateSliderItemViewModel
    {
        public long? FileId { get; set; }
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int OrderNum { get; set; }
    }
}
