using Behlog.Core.Exceptions;
using Behlog.Core.Extensions;
using Behlog.Core.Models.System;
using Behlog.Services.Contracts.Content;
using Behlog.Services.Dto.Content;
using Behlog.Web.ViewModels.Content;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Behlog.Web.Components.Content {

    public class LatestPostsViewComponent: ViewComponent {

        private readonly IPostService _postService;

        public LatestPostsViewComponent(IPostService postService) {

            postService.CheckArgumentIsNull(nameof(postService));
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string postTypeSlug,
            int? categoryId = null,
            string lang = Language.KEY_fa_IR,
            int pageSize = 10,
            string viewName = null
        ) {

            PostListDto result;
            try {
                result = await _postService.GetLatestPostsAsync(
                    postTypeSlug,
                    categoryId,
                    lang,
                    pageSize);
            }
            catch(PostTypeNotFoundException e) {
                return await Task.FromResult(
                    Content(string.Empty)
                    );
            }
            catch(Exception e) {
                return await Task.FromResult(
                    Content(string.Empty)
                    );
            }

            var model = result.Adapt<LatestPostsViewModel>();

            if (viewName.IsNotNullOrEmpty())
                return View(viewName, model);

            return await Task.FromResult(
                View(model)
                );
        }
    }
}
