using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.Core.SEO
{
    public class TwitterTagInput
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Site { get; set; }
        public string Creator { get; set; }

        //<meta name =”twitter:title” content=”TITLE OF POST OR PAGE”>

        //<meta name =”twitter:description” content=”DESCRIPTION OF PAGE CONTENT”>

        //<meta name =”twitter:image” content=”LINK TO IMAGE”>

        //<meta name =”twitter:site” content=”@USERNAME”>

        //<meta name =”twitter:creator” content=”@USERNAME”>
    }
}
