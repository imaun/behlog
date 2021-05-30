using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Exceptions;
using Behlog.Core.Extensions;
using Behlog.Services.Dto.System;
using Behlog.Services.Contracts.Content;
using Mapster;
using Behlog.Web.ViewModels.System;

namespace Behlog.Web.Components.Content
{
    public class CategoryPostListViewComponent: ViewComponent {
        private readonly IPostService _postService;

        public CategoryPostListViewComponent(IPostService postService) {
            postService.CheckArgumentIsNull(nameof(postService));
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string postTypeSlug,
            string lang,
            int pageSize,
            string viewName = "") {

            CategoryPostListDto result;
            try {
                result = await _postService.GetCategoryPostListAsync(
                    postTypeSlug,
                    lang,
                    pageSize);
            }
            catch (PostTypeNotFoundException e) {
                return await Task.FromResult(
                    Content(string.Empty)
                    );
            }
            catch(Exception e) {
                return await Task.FromResult(
                    Content(string.Empty)
                    );
            }

            var model = result.Adapt<CategoryPostListViewModel>();

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
