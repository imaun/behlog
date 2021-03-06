using System;
using System.Collections.Generic;
using Behlog.Core.Models.Enum;
using Behlog.Services.Dto.Core;
using Behlog.Services.Dto.System;

namespace Behlog.Services.Dto.Content
{
    public class PostResultDto {
        
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
        public int? CategoryId { get; set; }
        public string CoverPhoto { get; set; }
        public int? ParentId { get; set; }
        public string CategoryPath { get; set; }
        public string AltTitle { get; set; }
        public int? LayoutId { get; set; }
        public int OrderNumber { get; set; }
        public int WebsiteId { get; set; }
        public bool IsComponent { get; set; }
        public string IconName { get; set; }
        public int? RelatedPostId { get; set; }
        public string Template { get; set; }
        public string ViewPath { get; set; }
        public int? ProductId { get; set; }
        public string MetaDescription { get; set; }
        public string MetaRobots { get; set; }
        #endregion

        #region Navigation's Data
        public string PostTypeTitle { get; set; }
        public string PostTypeSlug { get; set; }
        public string LanguageTitle { get; set; }
        public string LangKey { get; set; }
        public string CategoryTitle { get; set; }
        public string CategorySlug { get; set; }
        public int CommentCount { get; set; }
        public int LikeCount { get; set; }
        public string Author { get; set; }
        public string PorductTitle { get; set; }
        public IEnumerable<PostTagItemDto> Tags { get; set; }
        #endregion
    }

    public class PostIndexFilter {
        public string PostTypeSlug { get; set; }
        public int? CategoryId { get; set; }
    }

    public class PostIndexDto: IndexBaseDto {
        public PostIndexDto() {
            Items = new List<PostIndexItemDto>();
            RelatedPosts = new List<PostItemDto>();
            Categories = new List<CategoryItemDto>();
        }

        public string Title { get; set; }
        public int PostTypeId { get; set; }
        public string PostTypeSlug { get; set; }
        public string CategoryTitle { get; set; }
        public string LangKey { get; set; }
        public int? CategoryId { get; set; }
        public IEnumerable<PostIndexItemDto> Items { get; set; }
        public IEnumerable<PostItemDto> RelatedPosts { get; set; }
        public IEnumerable<CategoryItemDto> Categories { get; set; }
    }

    public class PostIndexItemDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AltTitle { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public string Summary { get; set; }
        public DateTime? PublishDate { get; set; }
        public PostStatus Status { get; set; }
        public Guid UserId { get; set; }
        public string Author { get; set; }
        public string CoverPhoto { get; set; }
        public int CommentCount { get; set; }
        public int LikeCount { get; set; }
        public string IconName { get; set; }
        public string PostTypeSlug { get; set; }
        public string CategoryTitle { get; set; }
        public IEnumerable<PostTagItemDto> Tags { get; set; }
    }

    public class PostCreateDto
    {

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
        public int? CategoryId { get; set; }
        public string CoverPhoto { get; set; }
        public int? ParentId { get; set; }
        public string AltTitle { get; set; }
        public int? LayoutId { get; set; }
        public int OrderNumber { get; set; }
        public string IconName { get; set; }
        public int? RelatedPostId { get; set; }
        public string Template { get; set; }
        public string Tags { get; set; }
    }

    public class PostEditDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public PostBodyType BodyType { get; set; }
        public string Summary { get; set; }
        public DateTime? PublishDate { get; set; }
        public PostStatus Status { get; set; }
        public bool Commenting { get; set; }
        public string Password { get; set; }
        public int LangId { get; set; }
        public int? CategoryId { get; set; }
        public string CoverPhoto { get; set; }
        public int? ParentId { get; set; }
        public string AltTitle { get; set; }
        public int? LayoutId { get; set; }
        public int OrderNumber { get; set; }
        public string IconName { get; set; }
        public int? RelatedPostId { get; set; }
        public string Template { get; set; }
    }

    public class PostDetailDto {
        public PostDetailDto() {
            RelatedPosts = new List<PostItemDto>();
            Categories = new List<CategoryItemDto>();
            Tags = new List<PostTagItemDto>();
        }
        public IEnumerable<PostItemDto> RelatedPosts { get; set; }
        public IEnumerable<CategoryItemDto> Categories { get; set; }
        public IEnumerable<PostTagItemDto> Tags { get; set; }
        public PostResultDto Post { get; set; }
        public PostMetaListDto Meta { get; set; }
        public string PostTypeTitle { get; set; }
        public string PostTypeSlug { get; set; }
        public string HeaderImage { get; set; }
    }

    public class PostListDto {
        public PostListDto() {
            Items = new List<PostItemDto>();
        }

        public string Title { get; set; }
        public string PostTypeSlug { get; set; }
        public IEnumerable<PostItemDto> Items { get; set; }
    }

    public class PostItemDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AltTitle { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string PostTypeSlug { get; set; }
        public DateTime? PublishDate { get; set; }
        public string IconName { get; set; }
        public string CoverPhoto { get; set; }
        public string Author { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategorySlug { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public IEnumerable<PostTagItemDto> Tags { get; set; }
    }

    public class PostSummaryDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AltTitle { get; set; }
        public string Slug { get; set; }
        public string PostTypeSlug { get; set; }
        public string PostTypeTitle { get; set; }
        public string Summary { get; set; }
        public string CoverPhoto { get; set; }
        public Guid UserId { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public string IconName { get; set; }
        public string ViewPath { get; set; }
    }

    public class PostSummaryGroupDto {
        public PostSummaryGroupDto() {
            Items = new List<PostSummaryDto>();
        }
        public string Title { get; set; }
        public string AltTitle { get; set; }
        public string PostTypeSlug { get; set; }
        public IEnumerable<PostSummaryDto> Items { get; set; }
        public int TotalCount { get; set; }
    }

    
}
