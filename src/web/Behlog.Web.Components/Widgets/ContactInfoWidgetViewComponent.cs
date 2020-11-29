using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Behlog.Core.Extensions;
using Behlog.Web.ViewModels.Feature;
using Behlog.Services.Contracts.System;

namespace Behlog.Web.Components.Widgets {

    public class ContactInfoWidgetViewComponent: ViewComponent {

        private readonly IWebsiteOptionService _optionService;

        public ContactInfoWidgetViewComponent(IWebsiteOptionService optionService) {
            optionService.CheckArgumentIsNull(nameof(optionService));
            _optionService = optionService;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var contactInfo = await _optionService
                .GetContactInfoAsync();

            var model = new ContactInfoWidgetViewModel {
                Address = contactInfo.Address1,
                Email = contactInfo.Email,
                Phones = contactInfo.Phones
            };

            return await Task.FromResult(
                View(model)
            );
        }

    }
}
