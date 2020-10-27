using System;
using System.Collections.Generic;
using System.Linq;
using Behlog.Core.Extensions;
using Behlog.Core.Models.System;
using Behlog.Services.Dto.System;

namespace Behlog.Services.Extensions
{
    public static class WebsiteOptionExtensions
    {

        public static WebsiteContactInfoDto ExtractContactInfo(
            this List<WebsiteOption> options) {
            options.CheckArgumentIsNull(nameof(options));
            var result = new WebsiteContactInfoDto {
                Address1 = options.GetWebsiteOptionValue(nameof(WebsiteContactInfoDto.Address1)),
                Address2 = options.GetWebsiteOptionValue(nameof(WebsiteContactInfoDto.Address2)),
                Copyright = options.GetWebsiteOptionValue(nameof(WebsiteContactInfoDto.Copyright)),
                Email = options.GetWebsiteOptionValue(nameof(WebsiteContactInfoDto.Email)),
                Phones = options.GetWebsiteOptionValue(nameof(WebsiteContactInfoDto.Phones))
            };

            return result;
        }

        public static WebsiteSocialNetworkDto ExtractSocialNetworks(
            this List<WebsiteOption> options) {
            options.CheckArgumentIsNull(nameof(options));
            var result = new WebsiteSocialNetworkDto {
                Facebook = options.GetWebsiteOptionValue(nameof(WebsiteSocialNetworkDto.Facebook)),
                Instagram = options.GetWebsiteOptionValue(nameof(WebsiteSocialNetworkDto.Instagram)),
                LinkedIn = options.GetWebsiteOptionValue(nameof(WebsiteSocialNetworkDto.LinkedIn)),
                Telegram = options.GetWebsiteOptionValue(nameof(WebsiteSocialNetworkDto.Telegram)),
                Twitter = options.GetWebsiteOptionValue(nameof(WebsiteSocialNetworkDto.Twitter)),
                Whatsapp = options.GetWebsiteOptionValue(nameof(WebsiteSocialNetworkDto.Whatsapp)),
                YouTube = options.GetWebsiteOptionValue(nameof(WebsiteSocialNetworkDto.YouTube))
            };

            return result;
        }

        public static string GetWebsiteOptionValue(this WebsiteOption option)
            => option.Value;

        public static string GetWebsiteOptionValue(
            this IEnumerable<WebsiteOption> options, 
            string key) {
            var item = options
                .FirstOrDefault(_ => _.Key.ToLower() == key.ToLower());
            return item?.Value;
        }

    }
}
