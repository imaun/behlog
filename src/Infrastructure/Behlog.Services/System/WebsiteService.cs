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
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IWebsiteRepository _repository;
        private readonly IWebsiteFactory _factory;

        public WebsiteService(
            ICurrencyRepository currencyRepository,
            IWebsiteRepository repository,
            IWebsiteFactory factory) 
        {
            currencyRepository.CheckArgumentIsNull(nameof(currencyRepository));
            _currencyRepository = currencyRepository;

            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            factory.CheckArgumentIsNull(nameof(factory));
            _factory = factory;
        }

        public async Task<WebsiteInfo> GetWebsiteInfo(int websiteId) {
            var website = await _repository
                .Query()
                .Include(_ => _.Layout)
                .Include(_ => _.DefaultLanguage)
                .Include(_=> _.Options)
                .Include(_=> _.DefaultCurrency)
                .FirstOrDefaultAsync(_ => _.Id == websiteId);

            if (website == null)
                return null;

            var baseCurrency = await _currencyRepository.GetBaseCurrencyAsync();
            
            var result = new WebsiteInfo {
                Title = website.Title,
                DefaultLangId = website.DefaultLangId,
                DefaultLangKey = website.DefaultLanguage.LangKey,
                Id = website.Id,
                LayoutName = website.Layout.Name,
                Name = website.Name,
                OwnerId = website.OwnerId,
                Description = website.Description,
                Keywords = website.Keywords,
                CurrencyInfo = new WebsiteCurrencyInfo {
                    BaseCurrencySign = baseCurrency.Sign,
                    BaseCurrencyTitle = baseCurrency.Title
                },
                DefaultShippingId = website.DefaultShippingId
            };

            if(website.DefaultCurrency != null) {
                result.CurrencyInfo.DefaultCurrencySign = website.DefaultCurrency.Sign;
                result.CurrencyInfo.DefaultCurrencyTitle = website.DefaultCurrency.Title;
                result.CurrencyInfo.Rate = website.DefaultCurrency.Rate;
            }

            var websitePhone = website.Options
                .FirstOrDefault(_ => _.Key.ToLower() == "website.phone");

            var websiteEmail = website.Options
                .FirstOrDefault(_ => _.Key.ToLower() == "website.email");

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
