using Mapster;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Behlog.Core.Extensions;
using Behlog.Web.Common;
using Behlog.Services.Security;
using Behlog.Services.Contracts.Content;
using Behlog.Services.Dto.Admin.Content;
using Behlog.Web.Admin.ViewModels.Content;

namespace Behlog.Web.Admin.Controllers {

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

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1) {
            var filter = new AdminCommentIndexFilter {
                PageIndex = page-1,
                PageSize = 10
            };
            var result = await _commentService.GetAdminIndexAsync(filter);

            var model = result.Adapt<AdminCommentIndexViewModel>();

            model.Filter.PageIndex = filter.PageIndex;
            model.Filter.PageSize = filter.PageSize;

            return await Task.FromResult(
                View(model)
                );
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminCommentFilterViewModel model) {
            var filter = new AdminCommentIndexFilter {
                Email = model.Email,
                Status = model.Status,
                Title = model.Title
            };

            var result = await _commentService.GetAdminIndexAsync(filter);

            var resultModel = result.Adapt<AdminCommentIndexViewModel>();
            resultModel.DataSource.HasFilter = true;

            return await Task.FromResult(
                View(resultModel)
                );
        }
    }
}
