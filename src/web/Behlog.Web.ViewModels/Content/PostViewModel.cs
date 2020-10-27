using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Behlog.Core;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Resources.Strings;
using Behlog.Web.ViewModels.Core;
using Behlog.Web.ViewModels.Extensions;
using Behlog.Web.ViewModels.System;
using DNTPersianUtils.Core;

namespace Behlog.Web.ViewModels.Content {

    public class PostCreateViewModel: ViewModelBase {
        public PostCreateViewModel() {
            PublishDateValue = DateTime.Now.ToShortPersianDateTimeString();
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

        #region Collections

        public IList<SelectListItem> StatusSelectList => Status.ToSelectListItems();
        public IList<SelectListItem> CategorySelectList { get; set; }
        public IList<SelectListItem> LanguageSelectList { get; set; }

        #endregion
    }

    public class PostEditViewModel: ViewModelBase {
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

        #region Collections

        public IList<SelectListItem> StatusSelectList => Status.ToSelectListItems();
        public IList<SelectListItem> CategorySelectList { get; set; }
        public IList<SelectListItem> LanguageSelectList { get; set; }

        #endregion
    }

    public class PostViewModel {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public PostBodyType BodyType { get; set; }
        public string Summary { get; set; }
        public DateTime? PublishDate { get; set; }
        public PostStatus Status { get; set; }
        public bool Commenting { get; set; }
        public int PostTypeId { get; set; }
        public string Password { get; set; }
        public int LangId { get; set; }
        public int CategoryId { get; set; }
        public string CoverPhoto { get; set; }
        public string CoverPhotoPath => CoverPhoto != null
            ? CoverPhoto.Replace("~", AppHttpContext.BaseUrl)
            : Extensions.Extensions.GetDefaultImagePath();
        public int? ParentId { get; set; }
        public string CategoryPath { get; set; }
        public string AltTitle { get; set; }
        public int? LayoutId { get; set; }
        public int OrderNumber { get; set; }
        public int WebsiteId { get; set; }
        public string IconName { get; set; }
        public int? RelatedPostId { get; set; }
        public string Template { get; set; }
        public string ViewPath { get; set; }

        #endregion

        #region Navigation's Data
        /// <summary>
        /// <see cref="User"/>'s Title
        /// </summary>
        public string Author { get; set; }
        public string PostTypeTitle => PostTypeSlug.GetPostTypeDisplayName();
        public string PostTypeSlug { get; set; }
        public string LanguageTitle { get; set; }
        public string LangKey { get; set; }
        public string CategoryTitle { get; set; }
        public string CategorySlug { get; set; }

        #endregion

        #region Calculated Properties

        public string PublishDateDisplay => PublishDate?.ToPersianDateTextify();
        public string StatusDisplay => Status.ToDisplay();


        #endregion
    }

    public abstract class PostItemBaseViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LimitedTitle(int len) {
            if (string.IsNullOrWhiteSpace(Title))
                return string.Empty;

            if (Title.Length < len)
                len = Title.Length;

            return Title.Substring(0, len) + "...";
        }
        public string Slug { get; set; }
        private string _summary;
        public string Summary {
            get => _summary.StripHtmlTags();
            set => _summary = value;
        }

        public string LimitedSummary(int len) {
            if (string.IsNullOrWhiteSpace(Summary))
                return string.Empty;

            if (Summary.Length < len)
                len = Summary.Length;

            return Summary.Substring(0, len) + "...";
        }
            
        public DateTime? PublishDate { get; set; }
        public string PublishDateDisplay => PublishDate?.ToPersianDateTextify();
        public string CoverPhoto { get; set; }
        public string CoverPhotoPath => CoverPhoto != null
            ? CoverPhoto.Replace("~", AppHttpContext.BaseUrl)
            : Extensions.Extensions.GetDefaultImagePath();
        public string Author { get; set; }
        public string IconName { get; set; }
        public string PostTypeSlug { get; set; }
    }

    public class PostIndexViewModel: IndexBaseViewModel {

        public PostIndexViewModel() {
            RelatedPosts = new List<PostItemViewModel>();
            Categories = new List<CategoryItemViewModel>();
        }

        public string Title { get; set; }
        public string PostTypeSlug { get; set; }
        public string CategoryTitle { get; set; }
        public int PostTypeId { get; set; }
        public string LangKey { get; set; }
        public int? CategoryId { get; set; }
        public IEnumerable<PostIndexItemViewModel> Items { get; set; }
        public IEnumerable<PostItemViewModel> RelatedPosts { get; set; }
        public IEnumerable<CategoryItemViewModel> Categories { get; set; }
    }

    public class PostIndexItemViewModel: PostItemBaseViewModel {
        public string AltTitle { get; set; }
        public string Body { get; set; }
        public PostStatus Status { get; set; }
        public string StatusDisplay => Status.ToDisplay();
        public Guid UserId { get; set; }
    }

    public class PostItemViewModel: PostItemBaseViewModel {
    }

    public class PostSummaryViewModel: PostItemBaseViewModel {
        public string AltTitle { get; set; }
        public string PostTypeTitle => PostTypeSlug.GetPostTypeDisplayName();
        public Guid UserId { get; set; }
    }

    public class PostSummaryGroupViewModel {
        public PostSummaryGroupViewModel() {
            Items = new List<PostSummaryViewModel>();
        }

        public string Title { get; set; }
        public string AltTitle { get; set; }
        public string PostTypeSlug { get; set; }
        public IEnumerable<PostSummaryViewModel> Items { get; set; }
        public int TotalCount { get; set; }
    }

    public class PostDetailViewModel {

        public PostDetailViewModel() {
            Categories = new List<CategoryItemViewModel>();
            RelatedPosts = new List<PostItemViewModel>();
            Tags = new List<PostTagItemViewModel>();
        }

        public string PostTypeTitle => PostTypeSlug.GetPostTypeDisplayName();
        public string PostTypeSlug { get; set; }
        public string HeaderImage { get; set; }
        public IEnumerable<PostItemViewModel> RelatedPosts { get; set; }
        public IEnumerable<CategoryItemViewModel> Categories { get; set; }
        public IEnumerable<PostTagItemViewModel> Tags { get; set; }
        public PostViewModel Post { get; set; }
        public PostMetaListViewModel Meta { get; set; }
        public bool Commented { get; set; }
    }

    public class LatestPostsViewModel {
        
        public LatestPostsViewModel() {
            Items = new List<LatestPostsItemViewModel>();
        }

        public string Title { get; set; }
        public string PostTypeSlug { get; set; }
        public IEnumerable<LatestPostsItemViewModel> Items { get; set; }
    }

    public class LatestPostsItemViewModel: PostItemBaseViewModel {

    }
}
