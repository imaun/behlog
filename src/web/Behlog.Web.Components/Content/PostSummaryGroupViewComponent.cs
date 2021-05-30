using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Web.ViewModels.Content;
using Behlog.Services.Contracts.Content;

namespace Behlog.Web.Components.Content
{
    public class PostSummaryGroupViewComponent: ViewComponent {
        
        private readonly IPostService _postService;

        public PostSummaryGroupViewComponent(IPostService postService) {
            postService.CheckArgumentIsNull(nameof(postService));
            _postService = postService;
        }


        public async Task<IViewComponentResult> InvokeAsync(
            string postType,
            string categorySlug,
            string lang,
            int take,
            string viewName = "") {

            var post = await _postService
                .GetPostSummaryGroupAsync(
                    postType,
                    categorySlug,
                    lang,
                    take);

            if (post == null)
                return await Task.FromResult(
                    Content(string.Empty)
                    );

            var model = post.Adapt<PostSummaryGroupViewModel>();

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
