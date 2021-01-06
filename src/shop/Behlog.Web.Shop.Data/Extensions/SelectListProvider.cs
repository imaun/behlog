using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Behlog.Web.ViewModels.System;

namespace Behlog.Web.Shop.Data.Extensions {

    public static partial class Extensions {

        public static IList<SelectListItem> ToSelectListItems(
            this IEnumerable<ProvinceViewModel> provinces,
            int? selectedProvinceId = null) {
            var result = new List<SelectListItem>();
            if (provinces == null)
                return result;

            foreach (var province in provinces)
                result.Add(new SelectListItem {
                    Text = province.Title,
                    Value = province.Id.ToString(),
                    Selected = province.Id == selectedProvinceId
                });

            return result;
        }


    }
}
