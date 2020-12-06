using Mapster;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Behlog.Core.Extensions;
using Behlog.Web.Common;
using Behlog.Services.Security;
using Behlog.Services.Contracts.Feature;
using Behlog.Services.Dto.Admin.Feature;
using Behlog.Web.Admin.ViewModels.Feature;
using Behlog.Services.Contracts.Content;
using Behlog.Services.Dto.Admin.Content;

namespace Behlog.Web.Admin.Areas.Admin.Controllers
{
    [Area(AreaNames.AdminArea)]
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [Route("[area]/[controller]")]
    public class CommentController: Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService) {
            commentService.CheckArgumentIsNull(nameof(commentService));
            _commentService = commentService;
        }

        public async Task<IActionResult> Index(int page = 1) {
            var filter = new AdminCommentIndexFilter {
                PageIndex = page-1,
                PageSize = 10
            };
            var result = await _commentService.GetAdminIndexAsync(filter);

            var model = result.Adapt<>

        }
    }
}
