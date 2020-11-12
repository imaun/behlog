using Behlog.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.Core.SEO {

    public static class SeoService {

        /// <summary>
        /// page should not be indexed
        /// </summary>
        public static string Robots_NoIndex = "noindex";

        /// <summary>
        ///  links on the page should not be followed
        /// </summary>
        public static string Robot_NoFolllow = "nofollow";

        /// <summary>
        /// links on the page should be followed, even if the page is not to be indexed
        /// </summary>
        public static string Robot_Follow = "follow";

        /// <summary>
        /// images on the page should not be indexed
        /// </summary>
        public static string Robot_NonImageIndex = "noimageindex";

        /// <summary>
        /// search results should not show a cached version of the page
        /// </summary>
        public static string Robot_NoArchive = "noarchive";

        /// <summary>
        /// page should not be indexed beyond a certain date
        /// </summary>
        public static string Robot_Unavailable_After = "unavailable_after";


        public static string GenerateOpenGraphTags(OpenGraphTagInput input) {
            input.CheckArgumentIsNull();
            return input.ToString();
        }

    }

    
}
