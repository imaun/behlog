using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Behlog.Core;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Behlog.Factories.Contracts.System;
using Behlog.Services.Contracts.System;
using Behlog.Services.Dto.System;
using Behlog.Services.Extensions;
using Behlog.Web.Core.Settings;
using Mapster;

namespace Behlog.Services.System
{
    public class WebsiteOptionService: IWebsiteOptionService {

        private readonly IWebsiteOptionRepository _repository;
        private readonly IWebsiteInfo _websiteInfo;
        private readonly IWebsiteOptionFactory _factory;
        private readonly ILanguageRepository _langRepository;
        private readonly BehlogSetting _setting;

        public WebsiteOptionService(
            IWebsiteOptionRepository repository,
            IWebsiteInfo websiteInfo,
            IWebsiteOptionFactory factory,
            ILanguageRepository langRepository,
            BehlogSetting setting) { 

            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;

            factory.CheckArgumentIsNull(nameof(factory));
            _factory = factory;

            langRepository.CheckArgumentIsNull(nameof(langRepository));
            _langRepository = langRepository;

            setting.CheckArgumentIsNull(nameof(setting));
            _setting = setting;
        }

        public async Task<WebsiteOptionResultDto> GetOptionAsync(
            string optionKey,
            string lang,
            bool enabled = true) {
            var option = await _repository.GetByKeyAsync(_websiteInfo.Id, optionKey, lang);
            
            if(option == null)
                return null;

            if (enabled && option.Status != EntityStatus.Enabled)
                return null;

            var result = option.Adapt<WebsiteOptionResultDto>();
            return await Task.FromResult(result);
        }


        public async Task<WebsiteOptionResultDto> GetOptionAsync(string optionKey) {
            var option = await _repository.GetEnabledByKey(_websiteInfo.Id, optionKey);
            if (option == null)
                return null;

            var result = option.Adapt<WebsiteOptionResultDto>();
            return await Task.FromResult(result);
        }

        public async Task<WebsiteOptionResultDto> CreateOrUpdateAsync(
            CreateWebsiteOptionDto model) {
            var entity = await _repository.GetOptionAsync(
                model.Category,
                model.Key,
                model.LangId) ?? await _factory.MakeAsync(model);

            if (entity.Id != 0)
                _repository.MarkForUpdate(entity);
            else
                _repository.MarkForAdd(entity);

            await _repository.SaveChangesAsync();

            return await Task.FromResult(
                entity.Adapt<WebsiteOptionResultDto>()
            );
        }

        public async Task CreateOrUpdateOptionsAsync(WebsiteOptionCategoryDto model) {
            var options = await _factory.MakeAsync(model);
            
            if(!options.Any()) return;
            
            options = options.ToList();

            foreach(var item in options) {
                var entity = await _repository.GetOptionAsync(
                    model.Category,
                    item.Key,
                    model.LangId) ?? new WebsiteOption();

                entity.Title = item.Title;
                entity.WebsiteId = _websiteInfo.Id;
                entity.Key = item.Key;
                entity.Value = item.Value;
                entity.OrderNum = item.OrderNum;
                if(entity.Id == 0) {
                    entity.Category = model.Category;
                    entity.LangId = model.LangId;
                    entity.Status = EntityStatus.Enabled;
                    _repository.MarkForAdd(entity);
                }
                else
                    _repository.MarkForUpdate(entity);
            }

            await _repository.SaveChangesAsync();
        }

        public async Task<WebsiteContactInfoDto> GetContactInfoAsync(string langKey) {
            var lang = await _langRepository.GetByLangKeyAsync(langKey);
            lang.CheckReferenceIsNull(nameof(lang));

            return await GetContactInfoAsync(lang.Id);
        }

        public async Task<WebsiteContactInfoDto> GetContactInfoAsync(int? langId = null) {
            var categoryData = await _repository
                .GetEnabledOptionsAsync(
                    _websiteInfo.Id,
                    langId,
                    WebsiteOptionCategoryNames.ContactInfo
                );

            return categoryData?
                .ToList()
                .ExtractContactInfo();
        }

        public WebsiteContactInfoDto GetContactInfo(int? langId) {
            var categoryData = _repository.GetEnabledOptions(
                _websiteInfo.Id,
                langId,
                WebsiteOptionCategoryNames.ContactInfo
            );

            return categoryData?
                .ToList()
                .ExtractContactInfo();
        }

        public async Task<WebsiteSocialNetworkDto> GetSocialNetworksAsync() {
            var categoryData = await _repository
                .GetEnabledOptionsAsync(
                    _websiteInfo.Id,
                    langId: null,
                    WebsiteOptionCategoryNames.SocialNetwork
                );

            return categoryData?
                .ToList()
                .ExtractSocialNetworks();
        }

        //TODO : Temporary Method 
        public async Task CreateContactOptionsAsync() {
            var faLang = await _langRepository.GetByLangKeyAsync(Language.KEY_fa_IR);

            WebsiteContactSetting contactInfo = null;
            if(_setting.WebsiteSeedInfo.Options?.Contact != null) {
                contactInfo = _setting.WebsiteSeedInfo.Options.Contact;
            }
            var contactOptions = new WebsiteOptionCategoryDto {
                LangId = faLang.Id,
                Items = new List<WebsiteOptionCategoryItemDto> {
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 1,
                        Key = nameof(WebsiteContactInfoDto.Address1),
                        Title = "آدرس 1",
                        Value = contactInfo != null ? contactInfo.Address1 : string.Empty
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 2,
                        Key = nameof(WebsiteContactInfoDto.Address2),
                        Title = "آدرس 2",
                        Value = contactInfo != null ? contactInfo.Address2 : string.Empty
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 3,
                        Title = "متن کپی رایت",
                        Key = nameof(WebsiteContactInfoDto.Copyright),
                        Value = contactInfo != null ? contactInfo.Copyright : string.Empty
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 4,
                        Key = nameof(WebsiteContactInfoDto.Email),
                        Title = "آدرس ایمیل",
                        Value = contactInfo != null ? contactInfo.Email : string.Empty
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 5,
                        Key = nameof(WebsiteContactInfoDto.Phones),
                        Title = "شماره های تماس",
                        Value = contactInfo != null ? contactInfo.Phones : string.Empty
                    }
                },
                Category = WebsiteOptionCategoryNames.ContactInfo
            };

            await CreateOrUpdateOptionsAsync(contactOptions);
        }

        //TODO : Temporary Method 
        public async Task CreateSocialNetworksOptionsAsync() {
            WebsiteSocialNetworksSetting socialNetworkSetting = null;
            if(_setting.WebsiteSeedInfo.Options?.SocialNetworks != null) {
                socialNetworkSetting = _setting.WebsiteSeedInfo.Options.SocialNetworks;
            }
            var socialNetworkOptions = new WebsiteOptionCategoryDto {
                Category = WebsiteOptionCategoryNames.SocialNetwork,
                Items = new List<WebsiteOptionCategoryItemDto> {
                    new WebsiteOptionCategoryItemDto {
                        Key = nameof(WebsiteSocialNetworkDto.Facebook),
                        OrderNum = 1,
                        Title = nameof(WebsiteSocialNetworkDto.Facebook),
                        Value = socialNetworkSetting != null ? socialNetworkSetting.Facebook : string.Empty
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 2,
                        Key = nameof(WebsiteSocialNetworkDto.Instagram),
                        Title = nameof(WebsiteSocialNetworkDto.Instagram),
                        Value = socialNetworkSetting != null ? socialNetworkSetting.Instagram : string.Empty
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 3,
                        Key = nameof(WebsiteSocialNetworkDto.LinkedIn),
                        Title = nameof(WebsiteSocialNetworkDto.LinkedIn),
                        Value = socialNetworkSetting != null ? socialNetworkSetting.LinkedIn : string.Empty
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 4,
                        Key = nameof(WebsiteSocialNetworkDto.Telegram),
                        Title = nameof(WebsiteSocialNetworkDto.Telegram),
                        Value = socialNetworkSetting != null ? socialNetworkSetting.Telegram : string.Empty
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 5,
                        Key = nameof(WebsiteSocialNetworkDto.Twitter),
                        Title = nameof(WebsiteSocialNetworkDto.Twitter),
                        Value = socialNetworkSetting != null ? socialNetworkSetting.Twitter : string.Empty
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 6,
                        Key = nameof(WebsiteSocialNetworkDto.Whatsapp),
                        Title = nameof(WebsiteSocialNetworkDto.Whatsapp),
                        Value = socialNetworkSetting != null ? socialNetworkSetting.Whatsapp : string.Empty
                    }
                }
            };

            await CreateOrUpdateOptionsAsync(socialNetworkOptions);
        }
    }
}
