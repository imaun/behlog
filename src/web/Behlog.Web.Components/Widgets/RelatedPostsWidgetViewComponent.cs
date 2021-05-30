using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Web.ViewModels.Content;
using Behlog.Services.Contracts.Content;
using Mapster;

namespace Behlog.Web.Components.Widgets {

    public class RelatedPostsWidgetViewComponent: ViewComponent {

        private readonly IPostService _postService;

        public RelatedPostsWidgetViewComponent(
            IPostService postService) {

            postService.CheckArgumentIsNull(nameof(postService));
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string postType,
            string lang = "fa",
            int pageSize = 10,
            string viewName = "") {

            var result = await _postService.GetLatestPostsAsync(
                postType,
                null,
                lang,
                pageSize);

            if (result.Items == null
               || !result.Items.Any())
                return await Task.FromResult(
                    Content(string.Empty)
                    );

            var model = result.Items.Adapt<List<PostItemViewModel>>();

            return await Task.FromResult(
                View(model)
                );
        }
    }
}
