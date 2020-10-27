using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Behlog.Web.ViewModels.Search
{
    public class SearchUserViewModel
    {
        [Display(Name = "جستجوی عبارت")]
        public string TextToFind { set; get; }
    }
}
