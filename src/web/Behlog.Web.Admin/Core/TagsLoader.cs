using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Services.Extensions;
using Behlog.Services.Contracts.System;

namespace Behlog.Web.Admin.Core {

    public class TagsLoader {
        private readonly ITagService _tagService;

        public TagsLoader(ITagService tagService) {
            tagService.CheckArgumentIsNull(nameof(tagService));
            _tagService = tagService;
        }


        public async Task<string> GetAllTags() {
            var tags = await _tagService.LoadAsync();
            return tags.GetTagsAsString();
        }

    }
}
