using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Behlog.Web.ViewModels.Content;

namespace Behlog.Web.Components.Content {

    public class CommentInputViewComponent: ViewComponent {
        
        public async Task<IViewComponentResult> InvokeAsync(int postId) {
            var model = new CreateCommentViewModel {
                PostId = postId
            };

            return await Task.FromResult(View(model));
        }
    }
}
