using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Core.Models.System;
using Behlog.Services.Contracts.Content;
using Behlog.Web.ViewModels.Content;
using Mapster;
using Microsoft.AspNetCore.Mvc;

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
            int take) {

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

            var result = post.Adapt<PostSummaryGroupViewModel>();

            return await Task.FromResult(
                View(result)
                );
        }

    }
}
