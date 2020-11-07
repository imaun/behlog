using System.Collections.Generic;
using System.Linq;
using Behlog.Services.Dto.Content;

namespace Behlog.Web.Data.Extensions {

    public static class Extensions
    {

        public static string GetTagsAsString(this IEnumerable<PostTagItemDto> tags) {
            string result = string.Empty;
            if (tags == null || !tags.Any())
                return result;

            int totalCount = tags.Count();
            int i = 1;
            foreach (var tag in tags) {
                result += $"{tag.Title}";
                if (i < totalCount)
                    result += ",";
                i++;
            }

            return result;
        }
    }
}
