using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Web.ViewModels.Content;
using Behlog.Services.Contracts.Content;

namespace Behlog.Web.Components.Content {

    public class SliderViewComponent: ViewComponent {

        private readonly IPostService _postService;

        public SliderViewComponent(IPostService postService) {
            postService.CheckArgumentIsNull(nameof(postService));
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string lang,
            string postType,
            string slug,
            string activeStyleName = "",
            string viewName = ""
            ) {

            var post = await _postService.GetPostFileGalleryAsync(
                lang, 
                postType, 
                slug, 
                isComponent: true);

            if (post == null)
                return await Task.FromResult(
                    Content(string.Empty)
                    );

            var result = new SliderViewModel {
                CoverPhoto = post.CoverPhoto,
                Slug = post.Slug,
                Title = post.Title,
                AltTitle = post.AltTitle,
                Images = post.Files.Select(_ => new SliderImageViewModel {
                    Title = _.Title,
                    FileId = _.Id,
                    ImagePath = _.FilePath
                }).ToList()
            };

            string activeCss = "active";
            if (activeStyleName.IsNotNullOrEmpty())
                activeCss = activeStyleName;

            if (result.Images.Any()) 
                result.Images.FirstOrDefault().CssClass = activeCss;
            
            if(post.ViewPath.IsNotNullOrEmpty()) 
                return await Task.FromResult(
                    View(post.ViewPath, result));

            if (viewName.IsNotNullOrEmpty())
                return await Task.FromResult(
                    View(viewName, result)
                    );

            return await Task.FromResult(
                View(result)
                );
        }
    }
}
