using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Behlog.Services.Security;
using Behlog.Web.Common;
using Behlog.Core.Extensions;
using Behlog.Services.Contracts.Admin;
using Behlog.Web.Data.Content;
using Behlog.Web.Admin.ViewModels.Content;
using Behlog.Services.Dto.Admin.Content;
using Mapster;

namespace Behlog.Web.Admin.Controllers {

    [Area(AreaNames.AdminArea)]
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [Route("[area]/[controller]")]
    public class GalleryController : Controller {

        private readonly IAdminSliderService _sliderService;
        private readonly PostViewModelProvider _postViewModelProvider;

        public GalleryController(
            IAdminSliderService sliderService,
            PostViewModelProvider postViewModelProvider) {

            sliderService.CheckArgumentIsNull(nameof(sliderService));
            _sliderService = sliderService;

            postViewModelProvider.CheckArgumentIsNull(nameof(postViewModelProvider));
            _postViewModelProvider = postViewModelProvider;
        }

        #region Slider 

        [HttpGet("[controller]/slider/new")]
        public async Task<IActionResult> NewSlider() {
            var model = await _postViewModelProvider.BuildCreateSliderViewModelAsync();

            return View(model);
        }

        [HttpPost("[controller]/slider/new")]
        public async Task<IActionResult> NewSlider(CreateSliderViewModel model) {
            model.CheckArgumentIsNull(nameof(model));
            var dto = model.Adapt<AdminCreateSliderDto>();
            var result = await _sliderService.CreateAsync(dto);

            return View();
        }

        [HttpGet("[controller]/slider/{id}/edit")]
        public async Task<IActionResult> EditSlider(int id) {
            var slider = await _sliderService.GetForEditAsync(id);
            var model = slider.Adapt<EditSliderViewModel>();

            return View(model);
        }

        #endregion
    }
}
