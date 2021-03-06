using System;
using System.Collections.Generic;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Web.ViewModels.Core;
using Behlog.Web.ViewModels.System;
using DNTPersianUtils.Core;
using Behlog.Web.Common.Extensions;
using Behlog.Web.Core.Extensions;

namespace Behlog.Web.ViewModels.Content {

    public class PostViewModel {

        public PostViewModel() {
            Meta = new PostMetaListViewModel();
            Tags = new List<PostTagItemViewModel>();
        }

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
        public string CoverPhotoPath => CoverPhoto.GetFullImagePath();
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
        public string MetaDescription { get; set; }
        public string MetaRobots { get; set; }
        #endregion

        #region Navigation's Data
        /// <summary>
        /// <see cref="Behlog.Core.Models.Security.User"/>'s Title
        /// </summary>
        public string Author { get; set; }
        public string PostTypeTitle => PostTypeSlug.GetPostTypeDisplayName();
        public string PostTypeSlug { get; set; }
        public string LanguageTitle { get; set; }
        public string LangKey { get; set; }
        public string CategoryTitle { get; set; }
        public string CategorySlug { get; set; }
        public string ParentTitle { get; set; }
        public string PorductTitle { get; set; }
        #endregion

        #region Calculated Properties

        public string PublishDateDisplay => PublishDate?.ToPersianDateTextify();
        public string StatusDisplay => Status.ToDisplay();
        public bool HasParent => ParentId.HasValue;

        #endregion

        public IEnumerable<PostTagItemViewModel> Tags { get; set; }
        public PostMetaListViewModel Meta { get; set; }
    }

    public abstract class PostItemBaseViewModel: BaseViewModel {
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
        public string Summary { get; set; }
        public string SummaryStripped => Summary.StripHtmlTags();
        public string LimitedSummary(int len) => SummaryStripped.GetLimitedSummary(len);
        public DateTime? PublishDate { get; set; }
        public string PublishDateDisplay => PublishDate?.ToPersianDateTextify();
        public string CoverPhoto { get; set; }
        public string CoverPhotoPath => CoverPhoto.GetFullImagePath();
        public string Author { get; set; }
        public string IconName { get; set; }
        public string PostTypeSlug { get; set; }
        public string LangKey { get; set; }
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
        public int CommentCount { get; set; }
        public int LikeCount { get; set; }
        public string CategoryTitle { get; set; }
        public IEnumerable<PostTagItemViewModel> Tags { get; set; }
    }

    public class PostItemViewModel: PostItemBaseViewModel {
    }

    public class PostSummaryViewModel: PostItemBaseViewModel {
        public string AltTitle { get; set; }
        public string PostTypeTitle => PostTypeSlug.GetPostTypeDisplayName();
        public Guid UserId { get; set; }
    }

    public class PostSummaryGroupViewModel: BaseViewModel {
        public PostSummaryGroupViewModel() {
            Items = new List<PostSummaryViewModel>();
        }

        public string Title { get; set; }
        public string AltTitle { get; set; }
        public string PostTypeSlug { get; set; }
        public IEnumerable<PostSummaryViewModel> Items { get; set; }
        public int TotalCount { get; set; }
    }

    public class PostDetailViewModel: BaseViewModel {

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
        public IEnumerable<PostCommentItemViewModel> Comments { get; set; }
        public PostViewModel Post { get; set; }
        public PostMetaListViewModel Meta { get; set; }
        public bool Commented { get; set; }
    }

    public class LatestPostsViewModel: BaseViewModel {
        
        public LatestPostsViewModel() {
            Items = new List<LatestPostsItemViewModel>();
        }

        public string Title { get; set; }
        public string PostTypeSlug { get; set; }
        public IEnumerable<LatestPostsItemViewModel> Items { get; set; }
    }

    public class LatestPostsItemViewModel: PostItemBaseViewModel {
        public int? CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategorySlug { get; set; }
        public IEnumerable<PostTagItemViewModel> Tags { get; set; }
    }
}
