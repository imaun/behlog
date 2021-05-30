using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Services.Contracts.System;
using Behlog.Core.Models.System;
using Behlog.Web.ViewModels.System;
using Mapster;

namespace Behlog.Web.Components.Widgets
{
    public class CategoryListWidgetViewComponent: ViewComponent {

        private readonly ICategoryService _categoryService;

        public CategoryListWidgetViewComponent(
            ICategoryService categoryService) {
            categoryService.CheckArgumentIsNull(nameof(categoryService));
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string postType,
            string lang = Language.KEY_fa_IR,
            string viewName = "") {

            var result = await _categoryService.GetPostTypeCategoriesAsync(
                postType,
                lang);

            if (result == null
                || !result.Any())
                return await Task.FromResult(
                    Content(string.Empty)
                );

            var model = result.Adapt<List<CategoryItemViewModel>>();

            if (viewName.IsNotNullOrEmpty())
                return await Task.FromResult(
                    View(viewName, model)
                    );

            return await Task.FromResult(
                View(model)
            );
        }

    }
}
