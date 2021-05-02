using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Exceptions;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Behlog.Services.Contracts.Content;
using Behlog.Services.Dto.Content;
using Behlog.Services.Extensions;
using Behlog.Services.Dto.Core;
using Behlog.Services.Dto.System;
using Behlog.Core.Contracts;
using Mapster;

//PostService
//Front Related Methods

namespace Behlog.Services.Content
{
    public partial class PostService : IPostService {

        #region Get Post for showing on Views

        /// <inheritdoc/>
        public async Task<PostResultDto> GetPostForViewAsync(int id)
            => await getPostForViewAsync(_ => _.Id == id);

        /// <inheritdoc/>
        public async Task<PostResultDto> GetPostForViewAsync(string slug)
            => await getPostForViewAsync(_ => _.Slug.ToUpper() == slug.ToUpper());

        /// <inheritdoc/>
        public async Task<PostResultDto> GetPostForViewAsync(
            string langKey, 
            string slug)
            => await getPostForViewAsync(_ => _.Language.LangKey == langKey && 
                                                _.Slug.ToUpper() == slug.ToUpper());
        /// <inheritdoc/> 
        public async Task<PostResultDto> GetPostForViewAsync(
            string postType,
            string slug,
            string lang)
            => await getPostForViewAsync(_ => _.PostType.Slug == postType &&
                        _.Slug.ToUpper() == slug.ToUpper() &&
                        _.Language.LangKey.ToUpper() == lang.ToUpper());

        private async Task<PostResultDto> getPostForViewAsync(
            Expression<Func<Post, bool>> predicate) {
            
            var post = await buildResultQuery()
                .AddPublishedRules()
                .BelongsToWebsite(_websiteInfo.Id)
                .SingleOrDefaultAsync(predicate);

            if (post == null) return null;

            renderTemplateToBody(post);
            var result = post.Adapt<PostResultDto>();
            result.Tags = await getPostTagsAsync(post.Id);

            return await Task.FromResult(result);
        }

        #endregion

        #region Get Post details for showing on Views, Pages , etc

        public async Task<PostDetailDto> GetDetailAsync(int id)
            => await getDetailAsync(_ => _.Id == id);

        public async Task<PostDetailDto> GetDetailAsync(string slug)
            => await getDetailAsync(_ => _.Slug.ToUpper() == slug.ToUpper());

        public async Task<PostDetailDto> GetDetailAsync(string lang, string slug)
            => await getDetailAsync(_ => _.Language.LangKey == lang &&
                                          _.Slug == slug);

        public async Task<PostDetailDto> GetDetailAsync(
            string postTypeSlug,
            string lang,
            string slug) => await getDetailAsync(_ => _.PostType.Slug == postTypeSlug &&
                                                      _.Language.LangKey == lang &&
                                                      _.Slug == slug);

        private async Task<PostDetailDto> getDetailAsync(Expression<Func<Post, bool>> predicate) {
            var post = await buildGetDetailQuery()
                .AddPublishedRules()
                .BelongsToWebsite(_websiteInfo.Id)
                .FirstOrDefaultAsync(predicate);

            renderTemplateToBody(post);

            var postResult = post.Adapt<PostResultDto>();
            var result = new PostDetailDto();
            await addRelatedDataToPostDetailAsync(result, postResult);
            result.PostTypeSlug = postResult.PostTypeSlug;
            result.PostTypeTitle = postResult.PostTypeTitle;

            return await Task.FromResult(result);
        }

        #endregion

        #region Get Post to show in ViewComponents 
        public async Task<PostSummaryDto> GetPostSummaryAsync(
            string postType,
            string slug) {
            var post = await getPostSummaryQuery()
                .FirstOrDefaultAsync(_ => _.PostType.Slug == postType &&
                                          _.Slug.ToLower() == slug.ToLower());
            if (post == null) return null;

            return await Task.FromResult(
                post.Adapt<PostSummaryDto>()
            );
        }

        public async Task<PostSummaryDto> GetPostSummaryAsync(
            string lang,
            string postType,
            string slug) {
            var post = await getPostSummaryQuery()
                .FirstOrDefaultAsync(_ => _.Language.LangKey == lang &&
                                          _.PostType.Slug.ToLower() == postType.ToLower() &&
                                          _.Slug.ToLower() == slug.ToLower());
            if (post == null) return null;

            return await Task.FromResult(
                post.Adapt<PostSummaryDto>()
            );
        }

        public async Task<PostSummaryDto> GetPostSummaryAsync(int id) {
            var post = await getPostSummaryQuery()
                .FirstOrDefaultAsync(_ => _.Id == id);

            if (post == null) return null;

            return await Task.FromResult(
                post.Adapt<PostSummaryDto>()
            );
        }

        public async Task<PostSummaryGroupDto> GetPostSummaryGroupAsync(
            string postTypeSlug,
            string categorySlug,
            string lang = Language.KEY_fa_IR,
            int take = 10) {

            var postType = await _postTypeRepository.GetBySlugAsync(postTypeSlug);
            if (postType == null)
                throw new PostTypeNotFoundException();

            var query = getPostSummaryQuery()
                .Where(_ => _.PostType.Slug == postTypeSlug)
                .Where(_ => _.Language.LangKey == lang)
                .Where(_ => _.Category.Slug == categorySlug);

            var result = new PostSummaryGroupDto {
                PostTypeSlug = postType.Slug,
                Title = postType.Title,
                TotalCount = await query.CountAsync(),
                Items = await query
                    .Select(_ => _.Adapt<PostSummaryDto>())
                    .Take(take)
                    .ToListAsync()
            };

            if (!result.Items.Any())
                return null;

            return await Task.FromResult(result);
        }

        #endregion

        #region Get Post collections data for showing on PostType Index pages, lists, etc.
        public async Task<PostIndexDto> GetIndexAsync(
            IndexParams<PostIndexFilter> param
        ) {
            param.CheckArgumentIsNull(nameof(param));

            var postType = await _postTypeRepository
                .GetBySlugAsync(param.Filter.PostTypeSlug);

            if (postType == null)
                throw new PostTypeNotFoundException();

            var lang = await _languageRepository.GetByLangKeyAsync(param.LangKey)
                       ?? await _languageRepository.GetDefaultLanguage();

            var query = _repository.Query();

            query = AddIndexFilter(query, param.Filter, lang);

            var result = new PostIndexDto {
                CategoryId = param.Filter.CategoryId,
                PostTypeId = postType.Id,
                PostTypeSlug = postType.Slug,
                LangKey = lang.LangKey,
                PageSize = param.PageSize,
                CurrentPageNumber = param.PageNumber,
                TotalCount = await query.CountAsync(),
                Categories = await getCategoryItemsAsync(postType.Id, lang.Id)
            };

            if (result.CategoryId.HasValue)
                result.CategoryTitle = (await _categoryRepository
                    .FindAsync(result.CategoryId.Value)
                ).Title;

            result.Items = await query
                .Include(_ => _.PostType)
                .Include(_=> _.Category)
                .Include(_=> _.Comments)
                .Include(_=> _.Likes)
                .Include(_=> _.PostTags)
                .ThenInclude(_=> _.Tag)
                .Skip(param.Skip)
                .Take(param.PageSize)
                .OrderByDescending(_ => _.Id)
                .ThenByDescending(_ => _.PublishDate)
                .Select(_ => new PostIndexItemDto {
                    CoverPhoto = _.CoverPhoto,
                    Slug = _.Slug,
                    PublishDate = _.PublishDate,
                    Status = _.Status,
                    Summary = _.Summary,
                    Title = _.Title,
                    UserId = _.CreatorUserId,
                    AltTitle = _.AltTitle,
                    Author = _.CreatorUser.Title,
                    Id = _.Id,
                    PostTypeSlug = _.PostType.Slug,
                    Body = _.Body,
                    CategoryTitle = _.Category != null ? _.Category.Title : string.Empty,
                    CommentCount = _.Comments.Count(),
                    IconName = _.IconName,
                    LikeCount = _.Likes.Count(),
                    Tags = _.PostTags.Select(_=> new PostTagItemDto {
                        Title = _.Tag.Title,
                        Id = _.Tag.Id,
                        Description = _.Tag.Description,
                        Slug = _.Tag.Slug
                    })
                }).ToListAsync();

            return await Task.FromResult(result);
        }

        public async Task<CategoryPostListDto> GetCategoryPostListAsync(
            string postTypeSlug,
            string lang,
            int pageSize) {
            var postType = await _postTypeRepository
                .GetBySlugAsync(postTypeSlug);
            if (postType == null)
                throw new PostTypeNotFoundException();

            var result = new CategoryPostListDto {
                Title = postType.Title,
                PostTypeSlug = postType.Slug,
                Items = await _categoryRepository
                    .Query()
                    .Enabled()
                    .Include(_ => _.Posts)
                    .Where(_ => _.WebsiteId == _websiteInfo.Id)
                    .Where(_ => _.PostTypeId == postType.Id)
                    .Where(_ => _.Language.LangKey == lang)
                    .Take(pageSize)
                    .Select(_ => new CategoryPostListItemDto {
                        Id = _.Id,
                        Slug = _.Slug,
                        Title = _.Title,
                        Posts = _.Posts
                            .Where(post => post.Status == PostStatus.Published)
                            .Where(post => post.PublishDate <= _dateService.UtcNow())
                            .Select(p => p.Adapt<PostItemDto>())
                    })
                    .ToListAsync()
            };

            return await Task.FromResult(result);
        }

        public async Task<PostListDto> GetLatestPostsAsync(
           string postTypeSlug,
           int? categoryId = null,
           string lang = Language.KEY_fa_IR,
           int pageSize = 10
       ) {
            var postType = await _postTypeRepository
                .GetBySlugAsync(postTypeSlug);

            if (postType == null)
                throw new PostTypeNotFoundException();

            var query = _repository
                .Query()
                .Include(_ => _.PostType)
                .Include(_ => _.CreatorUser)
                .Include(_=> _.Category)
                .Include(_=> _.PostTags)
                .ThenInclude(_=> _.Tag)
                .AddPublishedRules()
                .BelongsToWebsite(_websiteInfo.Id)
                .WithPostType(postType.Id)
                .HasLanguage(lang);

            if (categoryId.HasValue)
                query = query.HasCategory(categoryId.Value);

            var result = new PostListDto {
                PostTypeSlug = postType.Slug,
                Title = postType.Title,
                Items = await query
                    .OrderByDescending(_ => _.PublishDate)
                    .ThenBy(_ => _.OrderNumber)
                    .Take(pageSize)
                    .Select(_ => _.Adapt<PostItemDto>())
                    .ToListAsync()
            };

            return await Task.FromResult(result);
        }
        #endregion

        #region Get Post for building pages
        public async Task<PageDetailDto> GetPageDetailAsync(int id) {
            var post = await _repository
                .Query()
                .Include(_ => _.PostType)
                .Include(_ => _.Language)
                .BelongsToWebsite(_websiteInfo.Id)
                .SingleOrDefaultAsync(_ => _.Id == id);

            return await getPageDetailAsync(post);
        }

        public async Task<PageDetailDto> GetPageDetailAsync(
            string slug,
            string lang = Language.KEY_fa_IR,
            string postTypeSlug = PostType.PAGE) {

            var post = await _repository
                .Query()
                .Include(_ => _.PostType)
                .Include(_ => _.Language)
                .AddPublishedRules()
                .BelongsToWebsite(_websiteInfo.Id)
                .FirstOrDefaultAsync(_ => _.PostType.Slug == postTypeSlug &&
                                          _.Slug == slug &&
                                          _.Language.LangKey == lang);
            renderTemplateToBody(post);

            return await getPageDetailAsync(post);
        }

        private async Task<PageDetailDto> getPageDetailAsync(Post post) {
            if (post == null)
                return null;

            string postTypeSlug = post.PostType.Slug;
            string lang = post.Language.LangKey;

            var result = post.Adapt<PageDetailDto>();
            //result.PostTypeSlug = PostType.PAGE;
            result.PostTypeTitle = post.PostType.Title;
            result.LangKey = post.Language.LangKey;

            if (post.ParentId.HasValue) {
                var parentPage = await _repository.FindAsync(post.ParentId.Value);
                result.ParentTitle = parentPage.Title;
                result.PagePathDisplay = $"{parentPage.Title}/{post.Title}";
                result.Parent = new ParentPageDto {
                    Slug = parentPage.Slug,
                    Title = parentPage.Title,
                    Id = parentPage.Id
                };
                result.RelatedPages = await _repository
                    .Query()
                    .Where(_ => _.ParentId == post.ParentId)
                    .Where(_ => _.PostType.Slug == PostType.PAGE)
                    .Where(_ => _.Language.LangKey == lang)
                    .AddPublishedRules()
                    .Select(p => new RelatedPageDto {
                        Title = p.Title,
                        AltTitle = p.AltTitle,
                        ParentId = p.ParentId,
                        Id = p.Id,
                        ParentTitle = post.Title,
                        IconName = p.IconName,
                        PostTypeSlug = postTypeSlug,
                        Slug = post.Slug
                    }).ToListAsync();
            }
            else {
                var hasSubPages = await _repository
                    .Query()
                    .AnyAsync(_ => _.ParentId == post.Id);
                if (hasSubPages) {
                    result.RelatedPages = await _repository
                        .Query()
                        .Where(_ => _.ParentId == post.Id)
                        .Where(_ => _.PostType.Slug == PostType.PAGE)
                        .Where(_ => _.Language.LangKey == lang)
                        .AddPublishedRules()
                        .Select(p => new RelatedPageDto {
                            Title = p.Title,
                            AltTitle = p.AltTitle,
                            ParentId = p.ParentId,
                            Id = p.Id,
                            ParentTitle = post.Title,
                            IconName = p.IconName,
                            PostTypeSlug = postTypeSlug,
                            Slug = post.Slug
                        }).ToListAsync();
                }
            }

            var headerImageMeta = await _metaRepository
                .GetPostMetaAsync(
                    post.Id,
                    "headerImage"
                );

            if (headerImageMeta != null)
                result.HeaderImage = headerImageMeta.MetaValue;

            return await Task.FromResult(result);
        }

        #endregion

        #region Get Post to build Galleries

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<GalleryDto> GetGalleryAsync(
            IndexParams param,
            int? categoryId = null,
            string lang = Language.KEY_fa_IR,
            bool isComponent = false) {

            param.CheckArgumentIsNull(nameof(param));
            var postType = await _postTypeRepository
                .GetBySlugAsync(PostType.GALLERY);

            if (postType == null)
                throw new PostTypeNotFoundException();

            var query = _repository
                .Query()
                .IncludeFiles()
                .Where(_ => _.PostTypeId == postType.Id)
                .Where(_ => _.Status == PostStatus.Published)
                .Where(_ => _.PublishDate <= _dateService.UtcNow())
                .Where(_ => _.Language.LangKey == lang)
                .Where(_ => _.IsComponent == isComponent);

            if (categoryId.HasValue)
                query = query.Where(_ => _.CategoryId == categoryId);

            query = query.SetOrder(param.OrderBy, !param.OrderDesc);

            if (param.HasPaging)
                query = query
                    .Skip(param.Skip)
                    .Take(param.Take);

            var queryResult = await query.ToListAsync();

            var result = new GalleryDto {
                Posts = queryResult.Adapt<List<PostFileGalleryDto>>()
            };

            foreach (var post in result.Posts) {
                post.Files = queryResult.FirstOrDefault(_ => _.Id == post.Id)
                    .PostFiles.OrderBy(_ => _.OrderNum)
                    .Select(_ => _.File)
                    .Adapt<List<PostFileGalleryItemDto>>();
            }

            return await Task.FromResult(result);
        }

        public async Task<PostFileGalleryDto> GetPostFileGalleryAsync(int id) {
            //var files = await _repository.GetFilesAsync()
            //var query = _repository.Query();
            //includeFiles(query);
            //query = addPublishedRules(query);
            var post = await _repository
                .Query()
                .IncludeFiles()
                .AddPublishedRules()
                .FirstOrDefaultAsync(_ => _.Id == id);

            if (post == null) return null;

            var result = post.Adapt<PostFileGalleryDto>();
            result.Files = post.PostFiles
                .Select(_ => _.File)
                .Adapt<List<PostFileGalleryItemDto>>();

            return await Task.FromResult(result);
        }

        public async Task<PostFileGalleryDto> GetPostFileGalleryAsync(
            string lang,
            string postType,
            string slug,
            bool isComponent = false) {

            var post = await _repository
                .Query()
                .Include(_ => _.Language)
                .Include(_ => _.PostType)
                .IncludeFiles()
                .AddPublishedRules()
                .FirstOrDefaultAsync(_ => _.Language.LangKey == lang &&
                                        _.PostType.Slug == postType &&
                                        _.Slug == slug &&
                                        _.IsComponent == isComponent);

            if (post == null) return null;

            var result = post.Adapt<PostFileGalleryDto>();
            result.Files = post.PostFiles
                .Select(_ => new PostFileGalleryItemDto {
                    Id = _.Id,
                    Extension = _.File.Extension,
                    Description = _.Title,
                    FilePath = _.File.FilePath,
                    FileType = _.File.FileType,
                    Title = _.Title,
                    Url = _.File.Url
                });

            return await Task.FromResult(result);
        }

        #endregion

        #region Get PostMeta data 
        public async Task<PostMetaListDto> GetPostMetaListAsync(
            Post post,
            int? langId = null,
            string category = null) {
            var meta = await _metaRepository
                .GetPostMetaWithPostAsync(post.Id, langId, category);

            var result = new PostMetaListDto {
                Items = meta.Select(_ => _.Adapt<PostMetaItemDto>()).ToList(),
                PostSlug = post.Slug,
                PostTitle = post.Title
            };

            return await Task.FromResult(result);
        }

        public async Task<PostMetaListDto> GetPostMetaListAsync(
            int postId,
            int? langId = null,
            string category = null) {
            var meta = await _metaRepository
                .GetPostMetaWithPostAsync(postId, langId, category);
            string postTitle = string.Empty, postSlug = string.Empty;
            if (meta.Any()) {
                var post = meta.ToList()[0].Post;
                postTitle = post.Title;
                postSlug = post.Slug;
            }

            var result = new PostMetaListDto {
                Items = meta.Select(_ => _.Adapt<PostMetaItemDto>()).ToList(),
                PostSlug = postSlug,
                PostTitle = postTitle
            };

            return await Task.FromResult(result);
        }



        #endregion

        #region Private Methods

        private IQueryable<Post> buildResultQuery() =>
            _repository.Query()
                .Include(_ => _.PostType)
                .Include(_ => _.Language)
                .Include(_ => _.Category)
                .Include(_ => _.CreatorUser)
                .Include(_ => _.PostFiles)
                .Include(_ => _.PostTags)
                .ThenInclude(_ => _.Tag);

        private IQueryable<Post> buildGetDetailQuery() =>
            buildResultQuery()
                .Include(_ => _.PostType)
                .Include(_ => _.Meta);

        private IQueryable<Post> AddIndexFilter(
            IQueryable<Post> query,
            PostIndexFilter filter,
            Language language) {

            //Add Mandatory filters
            query = query
                .Where(_ => _.WebsiteId == _websiteInfo.Id)
                .Where(_ => _.LangId == language.Id)
                .Where(_ => _.Status == PostStatus.Published);
            //.Where(_ => _.PublishDate <= _dateService.UtcNow()); //TODO : fix publishDate issue

            if (!string.IsNullOrWhiteSpace(filter.PostTypeSlug))
                query = query.Where(_ => _.PostType.Slug.ToLower()
                                         == filter.PostTypeSlug.ToLower());

            if (filter.CategoryId.HasValue)
                query = query.Where(_ => _.CategoryId == filter.CategoryId.Value);

            return query;
        }

        private async Task<IEnumerable<CategoryItemDto>> getCategoryItemsAsync(
            int postTypeId, int langId) => (await
                _categoryRepository
                    .GetEnabledByPostTypeAndLangAsync(postTypeId, langId)
                ).Select(_ => new CategoryItemDto {
                    Slug = _.Slug,
                    Title = _.Title,
                    ParentId = _.ParentId,
                    Description = _.Description,
                    Id = _.Id
                }).ToList();

        private async Task<IEnumerable<PostTagItemDto>> getPostTagsAsync(int postId) {
            var result = await _repository.GetTagsAsync(postId);
            return result == null
                ? new List<PostTagItemDto>()
                : result.Adapt<List<PostTagItemDto>>();
        }

        private IQueryable<Post> getPostSummaryQuery() {
            //var query = _repository.Query();
            //query = addPublishedRules(query);
            return _repository
                .Query()
                .AddPublishedRules() //TODO : Add Published Rules
                .Include(_ => _.PostType)
                .Include(_ => _.CreatorUser);
        }

        private bool isItOkToGetDetails(PostResultDto post) {
            if (post.WebsiteId != _websiteInfo.Id)
                return false;

            if (post.Status != PostStatus.Published)
                return false;

            if (post.Status == PostStatus.Published &&
                post.PublishDate < _dateService.UtcNow())
                return false;

            return true;
        }

        private async Task addRelatedDataToPostDetailAsync(
            PostDetailDto detail,
            PostResultDto post
        ) {

            detail.Post = post;
            detail.Categories = await getCategoryItemsAsync(
                post.PostTypeId,
                post.LangId);
            detail.Tags = await getPostTagsAsync(post.Id);
            //detail.Meta = new PostMetaListDto {
            //    LangKey = post.LangKey,
            //    PostSlug = post.Slug,
            //    PostTitle = post.Title,
            //    Items = await getPostMetaAsync(postId, )
            //}
        }

        private async Task<PostDetailDto> getPostDetailAsync(PostResultDto post) {
            if (post == null) return null;

            if (!isItOkToGetDetails(post)) return null;

            var result = new PostDetailDto();
            await addRelatedDataToPostDetailAsync(result, post);

            return await Task.FromResult(result);
        }

        private IQueryable<Post> includeFiles(IQueryable<Post> query) {
            return query.Include(_ => _.PostFiles)
                    .ThenInclude(_ => _.File);
        }

        private void renderTemplateToBody(Post post) {
            if (string.IsNullOrWhiteSpace(post.Template))
                return;

            string result = string.Empty;
            if(post.Template.Contains(PostTemplateFieldNames.Title)) {
                result = post.Template
                    .Replace(PostTemplateFieldNames.Title, post.Title);
            }

            if(post.Template.Contains(PostTemplateFieldNames.Body)) {
                result = result.Replace(PostTemplateFieldNames.Body, post.Body);
            }

            post.Body = result;
        }

        #endregion

    }
}
