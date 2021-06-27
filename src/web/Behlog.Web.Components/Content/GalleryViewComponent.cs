using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Behlog.Core.Models.System;
using Behlog.Services.Contracts.Content;
using Behlog.Web.ViewModels.Content;
using Mapster;
using Behlog.Core.Extensions;
using Behlog.Services.Dto.Core;

namespace Behlog.Web.Components.Content {

    public class GalleryViewComponent: ViewComponent {

        private readonly IPostService _postService;

        public GalleryViewComponent(IPostService postService) {
            postService.CheckArgumentIsNull(nameof(postService));
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            int? categoryId, 
            string lang = Language.KEY_fa_IR,
            bool isComponent = false,
            int pageSize = 3,
            string viewName = "") {

            var indexParam = new IndexParams {
                PageNumber = 1,
                PageSize = pageSize,
                OrderBy = "ordernum"
            };

            var gallery = await _postService.GetGalleryAsync(
                indexParam,
                categoryId, 
                lang, 
                isComponent);

            if(gallery == null) {
                return await Task.FromResult(
                    Content(string.Empty));
            }

            var model = gallery.Adapt<GalleryViewModel>();

            if (viewName.IsNotNullOrEmpty())
                return await Task.FromResult(
                    View(viewName, model)
                    );

            return await Task.FromResult(
                View(model));
        }
    }
}
