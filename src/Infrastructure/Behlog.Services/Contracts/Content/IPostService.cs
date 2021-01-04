using System.Threading.Tasks;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.System;
using Behlog.Services.Dto.Admin.Content;
using Behlog.Services.Dto.Content;
using Behlog.Services.Dto.Core;
using Behlog.Services.Dto.System;

namespace Behlog.Services.Contracts.Content {

    public interface IPostService {

        #region Admin Services

        Task<AdminPostIndexDto> GetAdminIndexAsync(
            AdminPostIndexFilter filter);

        Task<int> CreateAsync(PostCreateDto model);

        Task UpdateAsync(PostEditDto model);

        Task<int> GetNextOrderNumberAsync(int categoryId);

        Task SoftDeleteAsync(int id);


        #endregion

        /// <summary>
        /// Get <see cref="Post"/> by it's Id for showing on Website's Views.
        /// </summary>
        /// <param name="id">Id of Post</param>
        /// <returns>Post's data</returns>
        Task<PostResultDto> GetPostForViewAsync(int id);

        /// <summary>
        /// Get <see cref="Post"/> by it's Slug for shwoing on website's views.
        /// </summary>
        /// <param name="slug">Slug of post.</param>
        /// <returns>Post's data</returns>
        Task<PostResultDto> GetPostForViewAsync(string slug);

        /// <summary>
        /// Get <see cref="Post"/> by it's Slug and language for shwoing on website's views.
        /// </summary>
        /// <param name="slug">Slug of post.</param>
        /// <param name="langKey">LangKey of the language (ex: 'fa')</param>
        /// <returns>Post's data</returns>
        Task<PostResultDto> GetPostForViewAsync(string langKey, string slug);

        /// <summary>
        /// Get Post for showing on website's views.
        /// </summary>
        /// <param name="postType">PostType slug</param>
        /// <param name="slug">Slug of Post</param>
        /// <param name="lang">LangKey of Language</param>
        /// <returns>Post's data</returns>
        Task<PostResultDto> GetPostForViewAsync(
            string postType,
            string slug,
            string lang);

        Task<PostResultDto> GetResultByIdAsync(int id);

        Task<PostResultDto> GetResultAsync(string slug);

        Task<PostResultDto> GetResultAsync(
            string lang, 
            string slug);

        Task<PostResultDto> GetResultAsync(
            string postTypeSlug,
            string lang,
            string slug);

        
        Task<PostIndexDto> GetIndexAsync(
            IndexParams<PostIndexFilter> param);

        Task<PostDetailDto> GetDetailAsync(int id);

        Task<PostDetailDto> GetDetailAsync(string slug);

        Task<PostDetailDto> GetDetailAsync(
            string lang, 
            string slug);

        Task<PostDetailDto> GetDetailAsync(
            string postTypeSlug,
            string lang,
            string slug);

        Task<PostSummaryDto> GetPostSummaryAsync(
            string postType,
            string slug);

        Task<PostSummaryDto> GetPostSummaryAsync(
            string lang,
            string postType,
            string slug);

        Task<PostSummaryDto> GetPostSummaryAsync(int id);

        Task<PostSummaryGroupDto> GetPostSummaryGroupAsync(
            string postTypeSlug,
            string categorySlug,
            string lang = Language.KEY_fa_IR,
            int take = 10);

        Task<PostFileGalleryDto> GetPostFileGalleryAsync(int id);

        Task<PostFileGalleryDto> GetPostFileGalleryAsync(
            string lang,
            string postType,
            string slug,
            bool isComponent = false);

        Task<CategoryPostListDto> GetCategoryPostListAsync(
            string postTypeSlug,
            string lang,
            int pageSize);

        Task<PageDetailDto> GetPageDetailAsync(int id);

        Task<PageDetailDto> GetPageDetailAsync(
            string slug,
            string lang = Language.KEY_fa_IR,
            string postTypeSlug = PostType.PAGE);

        Task<GalleryDto> GetGalleryAsync(
            IndexParams param,
            int? categoryId = null,
            string lang = Language.KEY_fa_IR,
            bool isComponent = false);

        Task<PostListDto> GetLatestPostsAsync(
            string postTypeSlug,
            int? categoryId = null,
            string lang = Language.KEY_fa_IR,
            int pageSize = 10
        );

        Task UpdatePublishDateByPersianDateAsync(
            int postId,
            int year,
            int month,
            int day
        );

        Task<PostMetaListDto> GetPostMetaListAsync(
            Post post,
            int? langId = null,
            string category = null);

        Task<PostMetaListDto> GetPostMetaListAsync(
            int postId,
            int? langId = null,
            string category = null);
    }
}
