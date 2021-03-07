using System.Threading.Tasks;
using System.Collections.Generic;
using Behlog.Core.Extensions;
using Behlog.Core.Exceptions;
using Behlog.Resources.Strings;
using Behlog.Web.Core.Settings;
using Behlog.Core.Models.System;
using Behlog.Services.Dto.System;
using Behlog.Web.ViewModels.System;
using Behlog.Services.Contracts.System;
using Behlog.Core.Contracts.Repository.System;
using Mapster;

namespace Behlog.Web.Data.System {

    public class WebsiteOptionsProvider {

        private readonly ILanguageRepository _langRepository;
        private readonly IWebsiteOptionService _websiteOptionService;
        private readonly WebsiteOptionSetting _setting;

        public WebsiteOptionsProvider(
            ILanguageRepository langRepository,
            IWebsiteOptionService websiteOptionService,
            WebsiteOptionSetting setting) {

            langRepository.CheckArgumentIsNull(nameof(langRepository));
            _langRepository = langRepository;

            websiteOptionService.CheckArgumentIsNull(nameof(websiteOptionService));
            _websiteOptionService = websiteOptionService;

            setting.CheckArgumentIsNull(nameof(setting));
            _setting = setting;
        }

        private async Task<WebsiteOptionViewModel> getOptionAsync(string optionKey) {
            try {
                var option = await _websiteOptionService.GetOptionAsync(optionKey);
                return option.Adapt<WebsiteOptionViewModel>();
            }
            catch {
                return null;
            }
        }

        public async Task<WebsiteOptionViewModel> GetWebsiteLogoOptionAsync()
            => await getOptionAsync("website.logo");

        public async Task<WebsiteOptionViewModel> GetWebsiteFavIconAsync()
            => await getOptionAsync("website.favicon");

        /// <summary>
        /// Seed Website's options with the seed data from appsetting.json file.
        /// </summary>
        /// <returns></returns>
        public async Task SeedOptionsAsync() {
            if (_setting == null)
                throw new WebsiteOptionsSeedException();

            var lang = await _langRepository.GetByLangKeyAsync(_setting.LangKey);

            //Create or Update General options with Seed data from appsetting
            var generalOptions = new WebsiteOptionCategoryDto {
                LangId = lang.Id,
                Category = WebsiteOptionCategoryNames.General,
                Items = new List<WebsiteOptionCategoryItemDto> {
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 1,
                        Key = WebsiteOptionsKey.LogoPath,
                        Title = WebsiteOptionsText.Website_Logo,
                        Value = _setting.LogoPath
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 1,
                        Key = WebsiteOptionsKey.FavIconPath,
                        Title = WebsiteOptionsText.Website_Logo,
                        Value = _setting.LogoPath
                    },
                }
            };
            await _websiteOptionService.CreateOrUpdateOptionsAsync(generalOptions);

            //Create or Update Contact options with Seed data from appsetting
            var contact = _setting.Contact;
            var contactOptions = new WebsiteOptionCategoryDto {
                LangId = lang.Id,
                Category = WebsiteOptionCategoryNames.ContactInfo,
                Items = new List<WebsiteOptionCategoryItemDto> {
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 1,
                        Key = WebsiteOptionsKey.Contact_Address1,
                        Title = WebsiteOptionsText.Address1,
                        Value = contact?.Address1
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 2,
                        Key = WebsiteOptionsKey.Contact_Address2,
                        Title = WebsiteOptionsText.Address2,
                        Value = contact?.Address2
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 3,
                        Key = WebsiteOptionsKey.Contact_Copyright,
                        Title = WebsiteOptionsText.Copyright,
                        Value = contact?.Copyright
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 4,
                        Key = WebsiteOptionsKey.Contact_Phones,
                        Title = WebsiteOptionsText.Phones,
                        Value = contact?.Phones
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 5,
                        Key = WebsiteOptionsKey.Contact_Email,
                        Title = WebsiteOptionsText.Email,
                        Value = contact?.Email
                    },
                }
            };
            await _websiteOptionService.CreateOrUpdateOptionsAsync(contactOptions);

            //Create or Update SocialNetwork options with Seed data from appsetting
            var socialNetworks = _setting.SocialNetworks;
            var socialNetworksOptions = new WebsiteOptionCategoryDto {
                LangId = lang.Id,
                Category = WebsiteOptionCategoryNames.SocialNetwork,
                Items = new List<WebsiteOptionCategoryItemDto> {
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 1,
                        Key = WebsiteOptionsKey.Social_Telegram,
                        Title = WebsiteOptionsText.Social_Telegram,
                        Value = socialNetworks?.Telegram
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 2,
                        Key = WebsiteOptionsKey.Social_Instagram,
                        Title = WebsiteOptionsText.Social_Insta,
                        Value = socialNetworks?.Instagram
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 3,
                        Key = WebsiteOptionsKey.Social_LinkedIn,
                        Title = WebsiteOptionsText.Social_LinkedIn,
                        Value = socialNetworks?.LinkedIn
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 4,
                        Key = WebsiteOptionsKey.Social_WhatsApp,
                        Title = WebsiteOptionsText.Social_Whatsapp,
                        Value = socialNetworks?.Whatsapp
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 5,
                        Key = WebsiteOptionsKey.Social_Twitter,
                        Title = WebsiteOptionsText.Social_Twitter,
                        Value = socialNetworks?.Twitter
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 6,
                        Key = WebsiteOptionsKey.Social_Facebook,
                        Title = WebsiteOptionsText.Social_Facebook,
                        Value = socialNetworks?.Facebook
                    },
                    new WebsiteOptionCategoryItemDto {
                        OrderNum = 1,
                        Key = WebsiteOptionsKey.Social_YouTube,
                        Title = WebsiteOptionsText.Social_YouTube,
                        Value = socialNetworks?.YouTube
                    }
                }
            };
            await _websiteOptionService.CreateOrUpdateOptionsAsync(socialNetworksOptions);

        }
    }

    public static class WebsiteOptionsKey {
        public static string LogoPath = "logo";
        public static string FavIconPath = "favicon";
        public static string Contact_Address1 = "address1";
        public static string Contact_Address2 = "address2";
        public static string Contact_Phones = "phones";
        public static string Contact_Email = "email";
        public static string Contact_Copyright = "copyright";
        public static string Social_Telegram = "telegram";
        public static string Social_Instagram = "instagram";
        public static string Social_WhatsApp = "whatsapp";
        public static string Social_LinkedIn = "linkedin";
        public static string Social_Twitter = "twitter";
        public static string Social_Facebook = "facebook";
        public static string Social_YouTube = "youtube";
        public static string Contact_GoogleMapCode = "googlemapcode";
    } 

}
