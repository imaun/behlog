using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Services.Contracts.Content;
using Behlog.Services.Contracts.System;
using Behlog.Web.ViewModels.Content;
using Behlog.Web.ViewModels.Feature;
using Behlog.Web.ViewModels.System;
using Mapster;

namespace Behlog.Web.Components.System {

    public class WebsiteFooterViewComponent : ViewComponent {

        private readonly IPostService _postService;
        private readonly IWebsiteOptionService _websiteOptionService;

        public WebsiteFooterViewComponent(
            IPostService postService,
            IWebsiteOptionService websiteOptionService) {

            postService.CheckArgumentIsNull(nameof(postService));
            _postService = postService;

            websiteOptionService.CheckArgumentIsNull(nameof(websiteOptionService));
            _websiteOptionService = websiteOptionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string postType, 
            string aboutText,
            string aboutUrl,
            string lang = "fa", 
            int pageSize = 5,
            string viewName = "") {

            var model = new WebsiteFooterViewModel();

            var posts = await _postService.GetLatestPostsAsync(
                            postType, null, lang, pageSize);

            if(posts != null && posts.Items.Any())
                model.Posts = posts.Items.Adapt<List<PostItemViewModel>>();

            model.Subscriber = new SubscriberViewModel();

            var contactInfo = await _websiteOptionService.GetContactInfoAsync(lang);
            //var contactInfo = _websiteOptionService.GetContactInfo(lang);
            if (contactInfo != null)
                model.ContactInfo = contactInfo.Adapt<WebsiteContactInfoViewModel>();

            var copyrightText = await _websiteOptionService.GetOptionAsync("Copyright", lang);
            if (copyrightText != null)
                model.CopyrightText = copyrightText.Value;

            var socialNetworks = await _websiteOptionService
                .GetSocialNetworksAsync();

            if (socialNetworks != null)
                model.SocialNetworks = socialNetworks.Adapt<WebsiteSocialNetworksViewModel>();

            model.AboutText = aboutText;
            model.AboutUrl = aboutUrl;

            if (viewName.IsNotNullOrEmpty())
                return await Task.FromResult(
                    View(viewName, model)
                    );

            return await Task.FromResult(
                View(model)
                );
        }
    }
}
