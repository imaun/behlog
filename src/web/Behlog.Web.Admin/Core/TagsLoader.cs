using Behlog.Core.Extensions;
using Behlog.Services.Contracts.System;
using System.Linq;
using System.Threading.Tasks;

namespace Behlog.Web.Admin.Core
{
    public class TagsLoader
    {
        private readonly ITagService _tagService;

        public TagsLoader(ITagService tagService) {
            tagService.CheckArgumentIsNull(nameof(tagService));
            _tagService = tagService;
        }


        public async Task<string> GetAllTags() {
            var tags = await _tagService.LoadAsync();
            string result = string.Empty;
            int totalCount = tags.Count();
            int i = 1;
            foreach(var tag in tags) {
                result += $"'{tag.Title}'";
                if (i < totalCount)
                    result += ",";
                i++;
            }

            return result;
        }

    }
}
