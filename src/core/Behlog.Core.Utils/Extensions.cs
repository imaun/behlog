using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Behlog.Core.Utils
{
    public static class Extensions
    {

        //public static void CheckArgumentIsNull(this object obj, string message = "") {
        //    if(obj == null)
        //        throw new ArgumentNullException(nameof(obj), message);
        //}

        public static string MakeSlug(this string slug) =>
            slug == null
                ? null
                : Regex.Replace(slug,
                    @"[^A-Za-z0-9\u0600-\u06FF_\.~]+", "-");
    }
}
