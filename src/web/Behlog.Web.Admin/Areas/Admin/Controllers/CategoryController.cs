using System.Linq;
using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Factories.Contracts.System;
using Behlog.Services.Contracts.System;
using Behlog.Services.Dto.System;
using Behlog.Services.Security;
using Behlog.Web.Admin.ViewModels.System;
using Behlog.Web.Common;
using Behlog.Web.Core.Models;
using Behlog.Web.Data.System;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Behlog.Web.Admin.Controllers {

    [Area(AreaNames.AdminArea)]
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [Route("[area]/[controller]")]
    public class CategoryController : Controller {

        private readonly CategoryViewModelProvider _viewModelProvider;
        private readonly ICategoryService _categoryService;
        private readonly IPostTypeService _postTypeService;
        private readonly ILanguageService _languageService;

        private readonly LanguageViewModelProvider _languageProvider;

        public CategoryController(
            CategoryViewModelProvider viewModelProvider,
            ICategoryService categoryService,
            LanguageViewModelProvider languageProvider,
            IPostTypeService postTypeService,
            ILanguageService languageService
        ) {
            viewModelProvider.CheckArgumentIsNull();
            _viewModelProvider = viewModelProvider;

            categoryService.CheckArgumentIsNull();
            _categoryService = categoryService;

            languageProvider.CheckArgumentIsNull();
            _languageProvider = languageProvider;

            postTypeService.CheckArgumentIsNull();
            _postTypeService = postTypeService;

            languageService.CheckArgumentIsNull();
            _languageService = languageService;
        }

        [HttpGet("{postType}")]
        public async Task<IActionResult> Index(string postType = "page")
        {
            var _postType = await _postTypeService.GetBySlugAsync(postType);
            var model = new CategoryAdminViewModel {
                PostTypeId = _postType.Id
            };

            var result = await _categoryService.GetGridDataAsync(
                _postType.Id, new CategoryGridOptions {
                    PageSize = 10,
                    StartIndex = 0
                });

            var langs = await _languageService.GetAllAsync();

            model.Languages = langs.Select(_ => _.Adapt<LanguageItemViewModel>());

            model.Items = result.Items
                .Select(_ => _.Adapt<CategoryListItemViewModel>());

            return View(model);
        }

        
        [HttpGet("[action]/{postType}")]
        public async Task<IActionResult> New(string postType = "page") {
            var model = await _viewModelProvider
                .BuildCreateViewModelAsync(postType, null);

            return View(model);
        }

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(CategoryCreateViewModel model) {
            var data = model.Adapt<CategoryCreateDto>();
            data.Status = EntityStatus.Enabled;
            int id = await _categoryService.CreateAsync(data);
            
            return RedirectToAction("Edit", new { @id = id, @notify = true }); 
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Edit(int id, bool notify = false) {
            var result = await _categoryService.GetResultAsync(id);
            var model = result.Adapt<CategoryEditViewModel>();
            model.LanguageSelectList = await _languageProvider.GetSelectListAsync(model.LangId);
            model.ShowNotification = notify;

            return View(model);
        }


        [HttpPost("[action]/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryEditViewModel model) {
            var data = model.Adapt<CategoryEditDto>();
            data.Id = id;
            await _categoryService.UpdateAsync(data);
            model.ShowNotification = true;

            return View(model);
        }

                                             

    }
}