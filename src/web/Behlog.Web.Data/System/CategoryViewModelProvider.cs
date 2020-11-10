using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Behlog.Factories.Contracts.System;
using Behlog.Services.Contracts.System;
using Behlog.Web.Admin.ViewModels.System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Behlog.Web.Data.System
{
    public class CategoryViewModelProvider {

        private readonly LanguageViewModelProvider _languageViewModelProvider;
        private readonly ICategoryService _categoryService;
        private readonly IPostTypeService _postTypeService;

        public CategoryViewModelProvider(
           LanguageViewModelProvider languageViewModelProvider,
           ICategoryService categoryService,
           IPostTypeService postTypeService
        ) {
            languageViewModelProvider.CheckArgumentIsNull();
            _languageViewModelProvider = languageViewModelProvider;

            categoryService.CheckArgumentIsNull();
            _categoryService = categoryService;

            postTypeService.CheckArgumentIsNull();
            _postTypeService = postTypeService;
        }

        public async Task<CategoryCreateViewModel> BuildCreateViewModelAsync(
            string postType, 
            int? parentId
        ) {

            var postTypeRes = await _postTypeService.GetBySlugAsync(postType);
            if(postTypeRes == null)
                throw new NullReferenceException(nameof(PostType));

            var model = new CategoryCreateViewModel {
                LanguageSelectList = await _languageViewModelProvider.GetSelectListAsync(),
                Status = EntityStatus.Enabled,
                PostTypeId = postTypeRes.Id,
                PostTypeTitle = postTypeRes.Title
            };

            if(parentId.HasValue) {
                var parent = await _categoryService.FindAsync(parentId.Value);
                model.ParentTitle = parent.Title;
            }
            else {
                model.ParentTitle = "[ریشه]";
            }
            
            return model;
        }

        public async Task<List<SelectListItem>> GetSelectListAsync(int postTypeId,
            int languageId,
            int? selectedCategoryId = null) {
            var categories = await _categoryService.GetAvailableItemsAsync(postTypeId, languageId);
            var result = categories.Select(cat => new SelectListItem(
                    cat.Title, 
                    cat.Id.ToString(), 
                    cat.Id == selectedCategoryId)
                ).ToList();

            return await Task.FromResult(result);
        }
    }
}
