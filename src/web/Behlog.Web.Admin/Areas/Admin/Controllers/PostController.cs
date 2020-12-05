using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Behlog.Core.Extensions;
using Behlog.Web.Common.Tools;
using Behlog.Resources.Strings;
using Behlog.Services.Contracts.Content;
using Behlog.Services.Dto.Content;
using Behlog.Services.Security;
using Behlog.Web.Common;
using Behlog.Web.Data.Content;
using Behlog.Web.Data.System;
using Mapster;
using Behlog.Services.Dto.Admin.Content;
using Behlog.Services.Contracts.System;
using System.Collections.Generic;
using Behlog.Web.Core.Settings;
using Behlog.Web.Admin.ViewModels.Content;
using Behlog.Web.Core.Models;

namespace Behlog.Web.Admin.Controllers
{
    [Area(AreaNames.AdminArea)]
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [Route("[area]/[controller]")]
    public class PostController : Controller {

        private readonly IPostService _postService;
        private readonly PostViewModelProvider _postViewModelProvider;
        private readonly CategoryViewModelProvider _categoryViewModelProvider;
        private readonly IOptionsSnapshot<BehlogSetting> _setting;
        private readonly FileUploadHelper _fileUploader;
        private readonly ITagService _tagService;

        public PostController(
            IPostService postService,
            PostViewModelProvider postViewModelProvider,
            CategoryViewModelProvider categoryViewModelProvider,
            IOptionsSnapshot<BehlogSetting> setting,
            FileUploadHelper fileUploader,
            ITagService tagService
        ) {
            postService.CheckArgumentIsNull();
            _postService = postService;

            postViewModelProvider.CheckArgumentIsNull();
            _postViewModelProvider = postViewModelProvider;

            categoryViewModelProvider.CheckArgumentIsNull();
            _categoryViewModelProvider = categoryViewModelProvider;

            setting.CheckArgumentIsNull();
            _setting = setting;

            fileUploader.CheckArgumentIsNull();
            _fileUploader = fileUploader;

            tagService.CheckArgumentIsNull(nameof(tagService));
            _tagService = tagService;
        }

        #region Properties

        public BehlogSetting Options => _setting.Value;

        #endregion


        [HttpGet("{postType}")]
        public async Task<IActionResult> Index(string postType)
        {
            var filter = new AdminPostIndexFilter {
                PostTypeSlug = postType,
                PageIndex = 0,
                PageSize = 10,
                OrderKey = "ordernum"
            };
            var result = await _postService.GetAdminIndexAsync(filter);
            var model = result.Adapt<AdminPostIndexViewModel>();

            return View(model);
        }

        [HttpPost, Route("GetCategoriesAsync")]
        public async Task<JsonResult> GetCategoriesAsync(int postTypeId, int langId) {
            var result = await _categoryViewModelProvider
                .GetSelectListAsync(postTypeId, langId);

            return new JsonResult(result);
        }


        [HttpGet("{postType}/[action]")]
        public async Task<IActionResult> New(string postType) {
            postType.CheckMandatoryOption(nameof(postType));
            var model = await _postViewModelProvider
                .BuildCreateViewModelAsync(postType);

            return View(model);
        }

        [HttpPost("{postType}/[action]"), ValidateAntiForgeryToken]
        public async Task<IActionResult> New(string postType, PostCreateViewModel model) {
            model.CheckArgumentIsNull();

            if(!ModelState.IsValid) {
                model = await _postViewModelProvider
                    .BuildCreateViewModelAsync(model);
                model.ModelMessage = AppTextDisplay.ModelStateError;
                model.HasError = true;
                return View(model);
            }

            if(model.PublishDateModel.Value == null) {
                ModelState.AddModelError(
                    nameof(model.PublishDateModel),
                    AppErrorText.PersianDate_Invalid);
                model = await _postViewModelProvider
                    .BuildCreateViewModelAsync(model);
                model.ModelMessage = AppTextDisplay.ModelStateError;
                model.HasError = true;
                return View(model);
            }

            if(model.CoverPhotoFile != null && 
               model.CoverPhotoFile.Length > 0) {
                var uploadResult = _fileUploader.UploadPhoto(model.CoverPhotoFile);
                if(uploadResult.HasError) {
                    ModelState.AddModelError(
                        "CoverPhoto", 
                        uploadResult.ErrorMessage
                    );
                    model = await _postViewModelProvider
                        .BuildCreateViewModelAsync(model);

                    return View(model);
                }
                model.CoverPhoto = uploadResult.UploadUrl;
            }

            var data = model.Adapt<PostCreateDto>();
            var postId = await _postService.CreateAsync(data);

            return RedirectToAction(nameof(Edit), new {
                    id = postId, notify = true
                }
            );
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> LoadTags(string q) {
            var tags = await _tagService.SearchAsync(q);
            var result = new List<SelectItemViewModel>();
            var jsonResult = new List<string>();
            foreach (var tag in tags) {
                result.Add(new SelectItemViewModel {
                    Id = tag.Id,
                    Text = tag.Title
                });
                jsonResult.Add(tag.Title);
            }

            return Json(
                jsonResult.ToArray()
            );
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Edit(int id, bool notify = false) {
            var model = await _postViewModelProvider
                .BuildEditViewModelAsync(postId: id);
            model.CheckReferenceIsNull();
            model.ShowNotification = notify;
            model.ModelMessage = string.Format(
                AppTextDisplay.ModelAddedMsg,
                AppTextDisplay.PostEntityDisplay
            );
            
            return View(model);
        }

        [HttpPost("[action]/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PostEditViewModel model) {
            model.CheckArgumentIsNull();
            if(!ModelState.IsValid) {
                model = await _postViewModelProvider
                    .BuildEditViewModelAsync(model);
                model.ModelMessage = AppTextDisplay.ModelStateError;
                model.HasError = true;
                return View(model);
            }

            var data = model.Adapt<PostEditDto>();
            await _postService.UpdateAsync(model: data);
            model = await _postViewModelProvider
                .BuildEditViewModelAsync(model);
            model.ShowNotification = true;
            model.ModelMessage = string.Format(
                AppTextDisplay.ModelUpdatedMsg, 
                AppTextDisplay.PostEntityDisplay
            );

            return View(model);
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _postService.SoftDeleteAsync(id);

            return View();
        }

    }
}