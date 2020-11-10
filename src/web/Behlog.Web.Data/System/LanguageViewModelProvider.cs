using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Services.Contracts.System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Behlog.Web.Data.System
{
    public class LanguageViewModelProvider
    {
        private readonly ILanguageService _languageSvc;


        public LanguageViewModelProvider(
            ILanguageService languageSvc
        ) {
            languageSvc.CheckArgumentIsNull();
            _languageSvc = languageSvc;
        }


        public async Task<List<SelectListItem>> GetSelectListAsync(int? selectedLangId = null) {
            var result = new List<SelectListItem>();
            foreach(var lang in await _languageSvc.GetAllAsync()) {
                result.Add(new SelectListItem(
                    lang.Title, 
                    lang.Id.ToString(), 
                    lang.Id == selectedLangId)
                );
            }

            return await Task.FromResult(result);
        }

    }
}
