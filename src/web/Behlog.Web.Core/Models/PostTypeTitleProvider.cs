using System.Collections.Generic;
using System.Linq;

namespace Behlog.Web.Core.Extensions {
    public static class PostTypeTitleProvider {

        private static Dictionary<string, string> _dic = new Dictionary<string, string> {
            { "news", "اخبار" },
            { "blog", "وبلاگ" },
            { "service", "خدمات" },
            { "page", "صفحات" },
            { "product", "محصولات" },
            { "article", "مقالات" },
            { "gallery", "گالری" }
        };

        public static string GetPostTypeDisplayName(this string postTypeSlug) {
            if (string.IsNullOrEmpty(postTypeSlug))
                return string.Empty;

            try {
                if (_dic.Any(_ => _.Key == postTypeSlug.ToLower())) 
                    return _dic
                        .FirstOrDefault(_ => _.Key == postTypeSlug.ToLower())
                        .Value;
            }
            catch {
                return postTypeSlug;
            }
            return postTypeSlug;
        }

    }
}
