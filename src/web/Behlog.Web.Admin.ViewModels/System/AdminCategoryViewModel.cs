using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Behlog.Resources.Strings;
using Behlog.Web.Core.Models;
using Behlog.Core.Models.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using Behlog.Web.Common.Extensions;
using Behlog.Core.Extensions;
using DNTPersianUtils.Core;
using Behlog.Web.Admin.ViewModels.Core;

namespace Behlog.Web.Admin.ViewModels.System
{
    public class CategoryCreateViewModel : ViewModelBase
    {

        [Display(ResourceType = typeof(ModelText), Name = "Title")]
        [MaxLength(250, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public string Title { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Description")]
        [MaxLength(2000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Description { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Slug")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Slug { get; set; }

        public int? ParentId { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Language_Select")]
        public int LangId { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Status")]
        public EntityStatus Status { get; set; }
        public IList<SelectListItem> LanguageSelectList { get; set; }
        public IList<SelectListItem> StatusSelectList => Status.ToSelectListItems();
        public string ParentTitle { get; set; }

        public int PostTypeId { get; set; }
        public string PostTypeTitle { get; set; }
    }

    public class CategoryEditViewModel : ViewModelBase
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Title")]
        [MaxLength(250, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public string Title { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Description")]
        [MaxLength(2000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Description { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Slug")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Slug { get; set; }

        public int? ParentId { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Language_Select")]
        public int LangId { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Status")]
        public IList<SelectListItem> LanguageSelectList { get; set; }
        public string ParentTitle { get; set; }
        public int PostTypeId { get; set; }
        public string PostTypeTitle { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Status")]
        public bool Enabled { get; set; }
    }

    public class CategoryListItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public int? ParentId { get; set; }
        public int? LangId { get; set; }
        public EntityStatus Status { get; set; }
        public string ParentTitle { get; set; }
        public string LanguageTitle { get; set; }
        public string Description { get; set; }
        public string StatusText => Status.ToText();
        public DateTime CreateDate { get; set; }
        public string CreateDateDisplay => CreateDate.ToFriendlyPersianDateTextify();
        public DateTime ModifyDate { get; set; }
        public string ModifyDateDisplay => ModifyDate.ToFriendlyPersianDateTextify();
        public IEnumerable<CategoryListItemViewModel> Children { get; set; }
    }

    public class CategoryDataTable : DataTableBaseViewModel
    {
        public CategoryDataTable() {
            Filter = new CategoryFilterData();
        }

        public CategoryFilterData Filter { get; set; }
    }

    public class CategoryFilterData
    {
        public int PostTypeId { get; set; }
    }

    public class CategoryAdminViewModel
    {
        public CategoryAdminViewModel() {
            Filter = new CategoryFilterData();
            Languages = new List<LanguageItemViewModel>();
            Items = new List<CategoryListItemViewModel>();
        }

        public string PostTypeSlug { get; set; }
        public int PostTypeId { get; set; }
        public string PostTypeTitle { get; set; }
        public IEnumerable<LanguageItemViewModel> Languages { get; set; }
        public IEnumerable<CategoryListItemViewModel> Items { get; set; }
        public CategoryFilterData Filter { get; set; }

    }


}
