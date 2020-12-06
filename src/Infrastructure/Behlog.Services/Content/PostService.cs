using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Behlog.Core;
using Behlog.Core.Contracts.Repository.Content;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Exceptions;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Services.Contracts.Content;
using Behlog.Services.Dto.Content;
using Behlog.Factories.Contracts.Content;
using Behlog.Services.Extensions;
using Mapster;
using System.Globalization;
using Behlog.Services.Dto.Admin.Content;

//PostService
//Admin related Methods

namespace Behlog.Services.Content
{


    public partial class PostService: IPostService {

        private readonly IPostRepository _repository;
        private readonly IPostTypeRepository _postTypeRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostMetaRepository _metaRepository;
        private readonly IPostFactory _factory;
        private readonly IDateService _dateService;
        private readonly IWebsiteInfo _websiteInfo;
        public PostService(IPostRepository repository,
            IPostTypeRepository postTypeRepository,
            ILanguageRepository languageRepository,
            ICategoryRepository categoryRepository,
            IPostMetaRepository metaRepository,
            IPostFactory factory,
            IDateService dateService,
            IWebsiteInfo websiteInfo
        ) {
            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            postTypeRepository.CheckArgumentIsNull(nameof(postTypeRepository));
            _postTypeRepository = postTypeRepository;

            languageRepository.CheckArgumentIsNull(nameof(languageRepository));
            _languageRepository = languageRepository;

            categoryRepository.CheckArgumentIsNull(nameof(categoryRepository));
            _categoryRepository = categoryRepository;

            metaRepository.CheckArgumentIsNull(nameof(metaRepository));
            _metaRepository = metaRepository;

            factory.CheckArgumentIsNull();
            _factory = factory;

            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;

            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;
        }


        public async Task<AdminPostIndexDto> GetAdminIndexAsync(
            AdminPostIndexFilter filter) {

            var postType = await _postTypeRepository
                .GetBySlugAsync(filter.PostTypeSlug);

            if (postType == null)
                throw new PostTypeNotFoundException();

            var result = new AdminPostIndexDto {
                PostTypeSlug = postType.Slug,
                PostTypeTitle = postType.Title
            };

            var query = _repository
                .Query()
                .Include(_ => _.Language)
                .Include(_ => _.CreatorUser)
                .Include(_ => _.ModifierUser)
                .Include(_ => _.Category)
                .Include(_ => _.PostTags)
                .ThenInclude(_ => _.Tag)
                .Where(_ => _.PostTypeId == postType.Id)
                .Where(_ => !_.IsComponent);

            result.DataSource.TotalCount = await query.CountAsync();
            result.DataSource.PageIndex = filter.PageIndex;
            result.DataSource.PageSize = filter.PageSize;

            query = query.SetFilter(filter)
                .Skip(filter.StartIndex)
                .Take(filter.PageSize);

            result.DataSource.Items = await query
                .Select(_ => _.Adapt<AdminPostIndexItemDto>())
                .ToListAsync();

            return await Task.FromResult(result);
        } 


        public async Task<int> CreateAsync(PostCreateDto model) {
            var entity = await _factory.MakeAsync(model);
            await _repository.AddAndSaveAsync(entity);

            return await Task.FromResult(entity.Id);
        }

        public async Task UpdateAsync(PostEditDto model) {
            var entity = await _factory.MakeAsync(model);
            await _repository.UpdateAndSaveAsync(entity);
        }

        public async Task<PostResultDto> GetResultByIdAsync(int id) {
            var query = buildResultQuery();
            var entity = await query
                .FirstOrDefaultAsync(_ => _.Id == id);

            if (entity == null)
                return null;

            return await Task.FromResult(
                entity.Adapt<PostResultDto>()
            );
        }

        public async Task<PostResultDto> GetResultAsync(string slug) {
            var query = buildResultQuery();
            var entity = await query
                .FirstOrDefaultAsync(_ => _.Slug.ToLower() == slug.ToLower());

            if (entity == null)
                return null;

            return await Task.FromResult(
                entity.Adapt<PostResultDto>()
            );
        }

        public async Task<PostResultDto> GetResultAsync(string lang, string slug) {
            var query = buildResultQuery();
            var entity = await query
                .FirstOrDefaultAsync(_ => _.Slug.ToLower() == slug.ToLower() &&
                                          _.Language.LangKey == lang);

            if (entity == null)
                return null;

            return await Task.FromResult(
                entity.Adapt<PostResultDto>()
            );
        }

        public async Task<PostResultDto> GetResultAsync(
            string postTypeSlug,
            string lang,
            string slug) {
            var query = buildResultQuery();
            var entity = await query
                .FirstOrDefaultAsync(_ => _.PostType.Slug == postTypeSlug &&
                                        _.Slug.ToLower() == slug.ToLower() &&
                                        _.Language.LangKey == lang);

            if (entity == null) return null;

            return await Task.FromResult(
                entity.Adapt<PostResultDto>()
            );
        }

        public async Task<int> GetNextOrderNumberAsync(int categoryId) {
            int result;
            try {
                result = await _repository.GetMaxOrderNumberAsync(categoryId) + 1;
            }
            catch (Exception e) {
                return 1;
            }

            return await Task.FromResult(result);
        }

        public async Task SoftDeleteAsync(int id) {
            var entity = await _factory.MarkAsDeletedAsync(postId: id);
            _repository.MarkForUpdate(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdatePublishDateByPersianDateAsync(
            int postId, 
            int year, 
            int month, 
            int day
        ) {
            var post = await _repository.FindAsync(postId);
            post.CheckReferenceIsNull(nameof(post));

            var pc = new PersianCalendar();
            var pubDate = pc.ToDateTime(year, month, day, 0, 0, 0, 0);

            post.Status = PostStatus.Published;
            post.PublishDate = pubDate;

            await _repository.UpdateAndSaveAsync(post);
        }
    }
}
