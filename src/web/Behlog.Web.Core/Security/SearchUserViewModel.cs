using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Behlog.Web.Core.Security
{
    public class SearchUserViewModel
    {
        [Display(Name = "جستجوی عبارت")]
        public string TextToFind { set; get; }
    }
}
