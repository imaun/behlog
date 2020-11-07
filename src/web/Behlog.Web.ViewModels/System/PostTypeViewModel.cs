using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Behlog.Web.ViewModels.System
{
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

        //public static string GetPostTypeDisplayName(this string postTypeSlug) =>
        //     _dic.Values.FirstOrDefault(_ => _ == postTypeSlug.ToLower());

        public static string GetPostTypeDisplayName(this string postTypeSlug) {

            if (_dic.Any(_ => _.Key == postTypeSlug.ToLower())) {
                return _dic.FirstOrDefault(_ => _.Key == postTypeSlug.ToLower()).Value;
            }
            return postTypeSlug;
        }
             
    }
}
