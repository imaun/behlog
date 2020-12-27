using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Extensions;
using Behlog.Core.Security;
using Behlog.Services.Contracts.Content;
using Behlog.Services.Dto.Core;
using Behlog.Services.Dto.Content;
using Behlog.Web.Common.Controllers;
using Behlog.Web.ViewModels.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mapster;
using Behlog.Core.Models.System;
using Behlog.Web.Core.Settings;
using Behlog.Web.Core.Extensions;

namespace Behlog.Web.Controllers
{
    [Route("[controller]")]
    [Controller]
    public class PostController: BehlogController {
        
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;

        public PostController(
            IWebsiteInfo websiteInfo,
            IUserContext userContext,
            IOptionsSnapshot<BehlogSetting> setting,
            ILogger<PostController> logger,
            IPostService postService,
            ICommentService commentService) 
            : base(websiteInfo, userContext, setting, logger) {

            postService.CheckArgumentIsNull(nameof(postService));
            _postService = postService;

            commentService.CheckArgumentIsNull(nameof(commentService));
            _commentService = commentService;
        }

        #region ViewNames

        public string ViewViewName => $"~/{WebsiteInfo.LayoutName}/Post/View.cshtml";
        public string IndexViewName => $"~/{WebsiteInfo.LayoutName}/Post/Index.cshtml";

        private const string ViewPostDetailName = "~/Views/Post/PostDetail.cshtml";
        private const string ViewPageDetailName = "~/Views/Post/PageDetail.cshtml";
        private const string ViewGalleryDetailName = "~/Views/Post/PostGallery.cshtml";

        #endregion

        //[HttpGet("[action]/{postType}/{page}")]
        //public async Task<IActionResult> Index(string postType = "", int page = 1, int? category = null) {
        //    var result = await _postService.GetIndexAsync(
        //        new IndexParams<PostIndexFilter>(page, Options.WebConfig.PageSize)
        //    );

        //    var model = new PostIndexViewModel {
        //        CategoryId = category,
        //        PostTypeId = result.PostTypeId,
        //        PostTypeSlug = result.PostTypeSlug,
        //        CategoryTitle = result.CategoryTitle,
        //        Title = result.Title
        //    };

        //    return View(IndexViewName, model);
        //}

        [HttpGet("{postType:reserved}/{lang?}/{categoryId?}/{page?}", Name = MenuRouteName.PostIndex)]
        //[HttpGet(Name = MenuRouteName.PostIndex)]
        public async Task<IActionResult> Index(
            string postType,
            string lang = Language.KEY_fa_IR,
            int? categoryId = null,
            int page = 1
        ) {
            var param = new IndexParams<PostIndexFilter> {
                PageSize = 10,
                PageNumber = page,
                Filter = new PostIndexFilter {
                    CategoryId = categoryId,
                    PostTypeSlug = postType,
                },
                LangKey = lang
            };

            var result = await _postService.GetIndexAsync(param);

            var model = result.Adapt<PostIndexViewModel>();
            model.Title = result.PostTypeSlug.GetPostTypeDisplayName();

            return await Task.FromResult(View(model));
        }



        [HttpGet("view/{id}")]
        public async Task<IActionResult> View(int id) {
            var result = await _postService.GetResultByIdAsync(id);
            if (result == null)
                return NotFound();

            return View(ViewViewName, result);
        }

        [HttpGet("{postType:reserved}/{slug:reserved}/{lang?}", Name = MenuRouteName.PostDetail)]
        //[HttpGet(Name = MenuRouteName.PostDetail)]
        public async Task<IActionResult> Detail(
            string postType,
            string slug,
            string lang = "fa"
        ) {
            if (postType == PostType.PAGE || postType == PostType.PRODUCT) {
                var page = await _postService
                    .GetPageDetailAsync(slug, lang, postType);
                var pageModel = page.Adapt<PageDetailViewModel>();
                return await Task.FromResult(
                    View(ViewPageDetailName, pageModel)
                );
            }

            if (postType == PostType.GALLERY) {
                var gallery = await _postService
                    .GetPostFileGalleryAsync(lang, PostType.GALLERY, slug);
                var galleryModel = gallery.Adapt<PostFileGalleryViewModel>();
                return await Task.FromResult(
                    View(ViewGalleryDetailName, galleryModel)
                );
            }

            var post = await _postService
                .GetDetailAsync(postType, lang, slug);
            var postModel = post.Adapt<PostDetailViewModel>();
            return await Task.FromResult(
                View(ViewPostDetailName, postModel)
            );
        }


        [HttpGet("{postType:reserved}/{id:int}/{slug:reserved}/{lang?}", Name = MenuRouteName.PostDetaitlById)]
        //[HttpGet(Name = MenuRouteName.PostDetaitlById)]
        public async Task<IActionResult> Detail(
           int id,
           string postType,
           string slug,
           string lang = "fa",
           bool commented = false
           ) {
            if (postType == PostType.PAGE || postType == PostType.PRODUCT) {
                var page = await _postService
                    .GetPageDetailAsync(id);
                var pageModel = page.Adapt<PageDetailViewModel>();
                pageModel.Commented = commented;
                return await Task.FromResult(
                    View(ViewPageDetailName, pageModel)
                );
            }

            if (postType == PostType.GALLERY) {
                var gallery = await _postService
                    .GetPostFileGalleryAsync(id);
                var galleryModel = gallery.Adapt<PostFileGalleryViewModel>();
                galleryModel.Commented = commented;
                return await Task.FromResult(
                    View(ViewGalleryDetailName, galleryModel)
                );
            }

            var post = await _postService
                .GetDetailAsync(id);
            var postModel = post.Adapt<PostDetailViewModel>();
            postModel.Commented = commented;
            return await Task.FromResult(
                View(ViewPostDetailName, postModel)
            );
        }

        [HttpGet("gallery/{categoryId?}/{lang?}/{page?}", Name = "gallery")]
        //[HttpGet(Name = "gallery")]
        public async Task<IActionResult> Gallery(int? categoryId, string lang = "fa", int? page = 1) {
            var indexParam = new IndexParams {
                PageNumber = page != null ? page.Value : 1,
                PageSize = 10,
                OrderBy = "OrderNumber",
                OrderDesc = false
            };
            var gallery = await _postService
                .GetGalleryAsync(indexParam, categoryId, lang);
            gallery.Title = "گالری تصاویر";

            var result = gallery.Adapt<GalleryViewModel>();

            return View(result);
        }

        [HttpPost("post/comment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comment(CreateCommentViewModel model) {
            model.CheckArgumentIsNull(nameof(model));

            var post = await _postService.GetResultByIdAsync(model.PostId);
            post.CheckReferenceIsNull(nameof(post));
            var commentData = model.Adapt<CreateCommentDto>();

            var commentId = await _commentService.CreateAsync(commentData);

            return RedirectToAction(nameof(Detail), new {
                id = post.Id,
                postType = post.PostTypeSlug,
                slug = post.Slug,
                lang = post.LangKey,
                commented = true
            });
        }


    }
}
