using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Behlog.Resources.Strings;
using Behlog.Core.Models.Enum;
using Behlog.Web.Common.Extensions;
using Behlog.Web.Core.Models;
using DNTPersianUtils.Core;
using Behlog.Web.Core.Extensions;
using Behlog.Core;
using Behlog.Web.Common;
using Behlog.Web.Admin.ViewModels.Components;

namespace Behlog.Web.Admin.ViewModels.Content
{
    public class PostCreateViewModel : ViewModelBase
    {
        public PostCreateViewModel() {
            PublishDateValue = DateTime.Now.ToShortPersianDateTimeString();
            PublishDateModel = new PersianDateViewModel();
        }

        [Display(ResourceType = typeof(ModelText), Name = "Title")]
        [MaxLength(2000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public string Title { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Slug")]
        [MaxLength(2000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Slug { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "PostBody")]
        public string Body { get; set; }

        public PostBodyType BodyType { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Summary")]
        [MaxLength(2000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Summary { get; set; }

        public DateTime? PublishDate => PublishDateValue.ToGregorianDateTime();

        [Display(ResourceType = typeof(ModelText), Name = "PublishDate")]
        public string PublishDateValue { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Status")]
        public PostStatus Status { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "PostCommenting")]
        public bool Commenting { get; set; }
        public int PostTypeId { get; set; }
        public string PostTypeTitle => PostTypeSlug.GetPostTypeDisplayName();
        public string PostTypeSlug { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "PostPassword")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Language_Select")]
        [DataType(DataType.Password)]
        public int LangId { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "SelectCategory")]
        public int CategoryId { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "CoverPhoto")]
        [MaxLength(2000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string CoverPhoto { get; set; }
        public IFormFile CoverPhotoFile { get; set; }
        public int? ParentId { get; set; }
        public string CategoryPath { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "PostAltTitle")]
        public string AltTitle { get; set; }
        public int? LayoutId { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "OrderNumber")]
        public int OrderNumber { get; set; }
        public string IconName { get; set; }
        public int? RelatedPostId { get; set; }
        public string Template { get; set; }
        public string Tags { get; set; }
        public PersianDateViewModel PublishDateModel { get; set; }

        #region Collections

        public IList<SelectListItem> StatusSelectList => Status.ToSelectListItems();
        public IList<SelectListItem> CategorySelectList { get; set; }
        public IList<SelectListItem> LanguageSelectList { get; set; }
        public string TagsSource { get; set; }

        #endregion
    }

    public class PostEditViewModel : ViewModelBase
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Title")]
        [MaxLength(2000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public string Title { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Slug")]
        [MaxLength(2000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Slug { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "PostBody")]
        public string Body { get; set; }

        public PostBodyType BodyType { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Summary")]
        [MaxLength(2000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Summary { get; set; }

        public DateTime? PublishDate => PublishDateValue.ToGregorianDateTime();

        [Display(ResourceType = typeof(ModelText), Name = "PublishDate")]
        public string PublishDateValue { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Status")]
        public PostStatus Status { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "PostCommenting")]
        public bool Commenting { get; set; }
        public int PostTypeId { get; set; }
        public string PostTypeTitle => PostTypeSlug.GetPostTypeDisplayName();
        public string PostTypeSlug { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "PostPassword")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Language_Select")]
        public int LangId { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "SelectCategory")]
        public int CategoryId { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "CoverPhoto")]
        [MaxLength(2000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string CoverPhoto { get; set; }
        public IFormFile CoverPhotoFile { get; set; }
        public string CoverPhotoPath => CoverPhoto != null
            ? CoverPhoto.Replace("~", AppHttpContext.BaseUrl)
            : CommonHelper.GetDefaultImagePath();
        public int? ParentId { get; set; }
        public string CategoryPath { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "PostAltTitle")]
        public string AltTitle { get; set; }
        public int? LayoutId { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "OrderNumber")]
        public int OrderNumber { get; set; }
        public string IconName { get; set; }
        public int? RelatedPostId { get; set; }
        public string Template { get; set; }
        public string Tags { get; set; }
        public string CurrentTags { get; set; }
        public PersianDateViewModel PublishDateModel { get; set; }

        #region Collections

        public IList<SelectListItem> StatusSelectList => Status.ToSelectListItems();
        public IList<SelectListItem> CategorySelectList { get; set; }
        public IList<SelectListItem> LanguageSelectList { get; set; }
        public string TagsSource { get; set; }

        #endregion
    }

}
