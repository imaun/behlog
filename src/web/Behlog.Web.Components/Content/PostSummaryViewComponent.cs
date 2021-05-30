using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Services.Contracts.Content;
using Behlog.Web.ViewModels.Content;
using Mapster;

namespace Behlog.Web.Components.Content
{
    public class PostSummaryViewComponent: ViewComponent {

        private readonly IPostService _postService;

        public PostSummaryViewComponent(IPostService postService) {
            postService.CheckArgumentIsNull(nameof(postService));
            _postService = postService;
        }


        //public async Task<IViewComponentResult> InvokeAsync(string postType, string slug) {
        //    var post = await _postService
        //        .GetPostSummaryAsync(postType, slug);

        //    var result = await Task.FromResult(
        //        post.Adapt<PostSummaryViewModel>()
        //    );

        //    return View(result);
        //}

        public async Task<IViewComponentResult> InvokeAsync(
            string lang, 
            string postType, 
            string slug,
            string viewName = "") {
            
            var post = await _postService
                .GetPostSummaryAsync(lang, postType, slug);

            if (post == null)
                return await Task.FromResult(Content(string.Empty));

            var model = post.Adapt<PostSummaryViewModel>();

            if (post.ViewPath.IsNotNullOrEmpty())
                return View(post.ViewPath, model);

            if (viewName.IsNotNullOrEmpty())
                return await Task.FromResult(
                    View(viewName, model)
                    );

            return View(model);
        }

        //public async Task<IViewComponentResult> InvokeAsync(int id) {
        //    var post = await _postService
        //        .GetPostSummaryAsync(id);

        //    var result = await Task.FromResult(
        //        post.Adapt<PostSummaryViewModel>()
        //    );

        //    return View(result);
        //}


    }
}
