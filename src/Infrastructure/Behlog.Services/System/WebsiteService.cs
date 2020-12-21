using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Behlog.Core;
using Behlog.Core.Extensions;
using Behlog.Services.Dto.System;
using Behlog.Services.Contracts.System;
using Behlog.Factories.Contracts.System;
using Behlog.Core.Contracts.Repository.System;
using System.Linq;

namespace Behlog.Services.System
{
    public class WebsiteService: IWebsiteService 
    {

        private readonly IWebsiteRepository _repository;
        private readonly IWebsiteFactory _factory;

        public WebsiteService(
            IWebsiteRepository repository,
            IWebsiteFactory factory) 
        {
            repository.CheckArgumentIsNull();
            _repository = repository;

            factory.CheckArgumentIsNull();
            _factory = factory;
        }

        public async Task<WebsiteInfo> GetWebsiteInfo(int websiteId) {
            var website = await _repository
                .Query()
                .Include(_ => _.Layout)
                .Include(_ => _.DefaultLanguage)
                .Include(_=> _.Options)
                .FirstOrDefaultAsync(_ => _.Id == websiteId);

            if (website == null)
                return null;

            var result = new WebsiteInfo {
                Title = website.Title,
                DefaultLangId = website.DefaultLangId,
                DefaultLangKey = website.DefaultLanguage.LangKey,
                Id = website.Id,
                LayoutName = website.Layout.Name,
                Name = website.Name,
                OwnerId = website.OwnerId,
                Description = website.Description,
                Keywords = website.Keywords
            };

            var websitePhone = website.Options
                .FirstOrDefault(_ => _.Key.ToLower() == "website_phone");

            var websiteEmail = website.Options
                .FirstOrDefault(_ => _.Key.ToLower() == "email");

            if (websitePhone != null)
                result.ContactPhone = websitePhone.Value;

            if (websiteEmail != null)
                result.ContactEmail = websiteEmail.Value;

            return await Task.FromResult(result);
        }

        public async Task<WebsiteResultDto> CreateAsync(WebsiteCreateDto model) {
            var website = await _factory.CreateAsync(model);
            await _repository.AddAndSaveAsync(website);

            return website.Adapt<WebsiteResultDto>();
        }

        public async Task<bool> IsThereAnyWebsiteAsync() =>
            await _repository.AnyAsync(_ => _.Id > 0);

    }
}
