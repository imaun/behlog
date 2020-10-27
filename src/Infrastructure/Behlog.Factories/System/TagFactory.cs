using System;
using System.Threading.Tasks;
using Behlog.Core.Models.System;
using Behlog.Core.Models.Enum;
using Behlog.Core.Utils;
using Behlog.Factories.Contracts.System;
using Behlog.Core;
using Behlog.Core.Extensions;

namespace Behlog.Factories.System
{
    public class TagFactory: ITagFactory
    {
        private readonly IWebsiteInfo _websiteInfo;

        public TagFactory(IWebsiteInfo websiteInfo) {
            websiteInfo.CheckArgumentIsNull(nameof(websiteInfo));
            _websiteInfo = websiteInfo;
        }

        public async Task<Tag> MakeAsync(string tagTitle) {
            if (string.IsNullOrWhiteSpace(tagTitle))
                throw new ArgumentNullException(nameof(tagTitle));

            return await Task.FromResult(
                new Tag {
                    Status = EntityStatus.Enabled,
                    Title = tagTitle,
                    Slug = tagTitle.MakeSlug(),
                    WebsiteId = _websiteInfo.Id
                }
            );
        }
    }
}
