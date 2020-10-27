using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Behlog.Core.Security;
using Behlog.Factories.Contracts.System;
using Behlog.Services.Contracts.System;
using Behlog.Services.Dto.Core;
using Behlog.Services.Dto.System;
using Behlog.Services.Extensions;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Behlog.Services.System
{
    public class CategoryService: ICategoryService {

        private readonly ICategoryRepository _repo;
        private readonly ICategoryFactory _factory;
        private readonly IUserContext _userContext;
        
        public CategoryService(
            ICategoryRepository repo,
            ICategoryFactory factory,
            IUserContext userContext
        ) {
            repo.CheckArgumentIsNull();
            _repo = repo;

            factory.CheckArgumentIsNull();
            _factory = factory;

            userContext.CheckArgumentIsNull();
            _userContext = userContext;
        }

        public async Task<int> CreateAsync(CategoryCreateDto model) {
            model.CheckArgumentIsNull();
            var entity = _factory.Make(model);
            await _repo.AddAndSaveAsync(entity);

            return entity.Id;
        }

        public async Task UpdateAsync(CategoryEditDto model) {
            model.CheckArgumentIsNull();
            var entity = _factory.Make(model);
            await _repo.UpdateAndSaveAsync(entity);
        }

        public async Task<CategoryResultDto> FindAsync(int id) {
            var category = await _repo.FindAsync(id);
            var result = category.Adapt<CategoryResultDto>();
            if(result.ParentId.HasValue) {
                var parent = await _repo.FindAsync(result.ParentId.Value);
                result.ParentTitle = parent.Title;
            }

            return await Task.FromResult(result);
        }

        
        public async Task<CategoryResultDto> GetResultAsync(int id) {
            return await FindAsync(id);
        }

        public async Task<DataGridDto<CategoryGridItemDto>> GetGridDataAsync(
            int postTypeId,
            CategoryGridOptions options) 
        {
            var result = new DataGridDto<CategoryGridItemDto>();
            var query = _repo.Query()
                .Where(_ => _.WebsiteId == _userContext.WebsiteId)
                .Where(_=> _.PostTypeId == postTypeId)
                .Include(_=> _.Language)
                .AsQueryable();

            result.TotalCount = query.Count();
            if(options.Filter != null) {
                query = query.SetFilter(options.Filter);
            }
            query = query.SetOrder(options.OrderByFieldName, options.OrderAsc);

            result.Items = query
                .Skip(options.StartIndex)
                .Take(options.PageSize)
                .SetOrder(options.OrderByFieldName, options.OrderAsc)
                .Select(_ => new CategoryGridItemDto {
                    Status = _.Status,
                    Title = _.Title,
                    LangId = _.LangId,
                    Slug = _.Slug,
                    Id = _.Id,
                    LanguageTitle = _.Language.Title,
                    CreateDate = _.CreateDate,
                    ModifyDate = _.ModifyDate
                }).ToList();

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<CategoryItemDto>> GetAvailableItemsAsync(
            int postTypeId, int languageId) {

            var query = _repo.Query()
                .Where(_ => _.WebsiteId == _userContext.WebsiteId)
                .Where(_ => _.PostTypeId == postTypeId)
                .Where(_=> _.LangId == languageId)
                .Where(_=> _.Status == EntityStatus.Enabled)
                .SetOrder("Id");

            var result = query.Select(_ => new CategoryItemDto {
                Title = _.Title,
                Id = _.Id,
                ParentId = _.ParentId
            }).ToList();

            return await Task.FromResult(result);
        }


        public async Task<IEnumerable<CategoryItemDto>> GetPostTypeCategoriesAsync(
            string postTypeSlug,
            string langKey = Language.KEY_fa_IR) {

            var categories = await _repo.GetEnabledByPostTypeAndLangAsync(
                postTypeSlug,
                langKey);

            var result = categories.Adapt<List<CategoryItemDto>>();

            return await Task.FromResult(result);
        }

        #region Private Methods

        

        #endregion
    }
}
