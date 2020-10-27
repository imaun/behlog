using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Behlog.Core.Models.Enum;
using Behlog.Resources.Strings;
using Behlog.Web.ViewModels.Core;
using Behlog.Web.ViewModels.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Behlog.Core.Extensions;
using Behlog.Web.ViewModels.Content;
using DNTPersianUtils.Core;

namespace Behlog.Web.ViewModels.System
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int PostTypeId { get; set; }
        public int? ParentId { get; set; }
        public int LangId { get; set; }
        public string TreePath { get; set; }
        public int WebsiteId { get; set; }
        public EntityStatus Status { get; set; }
    }

    public class CategoryCreateViewModel: ViewModelBase {

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

    public class CategoryEditViewModel: ViewModelBase {
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

    public class CategoryDataTable: DataTableBaseViewModel
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

    public class CategoryItemViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int? ParentId { get; set; }
    }

    public class CategoryPostListViewModel {
        public CategoryPostListViewModel() {
            Items = new List<CategoryPostListItemViewModel>();

        }
        public string Title { get; set; }
        public string PostTypeSlug { get; set; }
        public IEnumerable<CategoryPostListItemViewModel> Items { get; set; }
    }

    public class CategoryPostListItemViewModel {
        public CategoryPostListItemViewModel() {
            Posts = new List<PostItemViewModel>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string AltTitle { get; set; }
        public string Slug { get; set; }
        public IEnumerable<PostItemViewModel> Posts { get; set; }
    }
}
