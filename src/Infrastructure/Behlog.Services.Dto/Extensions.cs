using Behlog.Core.Models.Content;
using Behlog.Services.Dto.Content;
using System.Collections.Generic;
using System.Linq;

namespace Behlog.Services.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<PostTagItemDto> ExtractTags(
            this ICollection<PostTag> postTags) {
            //string result = string.Empty;
            //if (postTags == null || !postTags.Any())
            //    return null;

            //int totalCount = postTags.Count();
            //int i = 1;
            //foreach(var postTag in postTags) {
            //    result += $"'{postTag.Tag.Title}'";
            //    if (i < totalCount)
            //        result += seperator;
            //    i++;
            //}

            //return result;
            var result = new List<PostTagItemDto>();

            foreach (var postTag in postTags.ToList()) {
                result.Add(new PostTagItemDto {
                    Description = postTag.Tag.Description,
                    Id = postTag.Tag.Id,
                    Slug = postTag.Tag.Slug,
                    Title = postTag.Tag.Title
                }); 
            }

            return result;
        }
    }
}
