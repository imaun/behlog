using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Behlog.Web.ViewModels.Content;
using Behlog.Core.Extensions;

namespace Behlog.Web.Components.Content {

    public class CommentInputViewComponent: ViewComponent {
        
        public async Task<IViewComponentResult> InvokeAsync(
            int postId, 
            string viewName = "") {

            var model = new CreateCommentViewModel {
                PostId = postId
            };

            if (viewName.IsNotNullOrEmpty())
                return await Task.FromResult(
                    View(viewName, model)
                    );

            return await Task.FromResult(View(model));
        }
    }
}
