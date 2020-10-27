using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Extensions;
using Behlog.Core.Models.System;
using Behlog.Factories.Contracts.System;
using Behlog.Services.Contracts.System;
using Behlog.Services.Dto.System;
using Mapster;

namespace Behlog.Services.System
{
    public class LanguageService: ILanguageService
    {

        private readonly ILanguageRepository _repo;
        private readonly ILanguageFactory _factory;

        public LanguageService(
            ILanguageRepository repo,
            ILanguageFactory factory
        ) {
            repo.CheckArgumentIsNull();
            _repo = repo;

            factory.CheckArgumentIsNull();
            _factory = factory;
        }

        public async Task<LanguageResultDto> FindAsync(int id) => await 
            Task.FromResult(_repo.FindAsync(id).Adapt<LanguageResultDto>()
        );
        
        public async Task<IList<LanguageResultDto>> GetAllAsync() {
            var result = await _repo.GetAllEnabledAsync();
            return result.Adapt<List<LanguageResultDto>>();
        }

        public async Task<LanguageResultDto> CreateDefaultLanguagesAndReturnDefaultLanguageAsync() {
            var callSaveChanges = false;
            var (langFa, langEn) = _factory.CreateDefaultLanguages();

            var langFaRecord = await GetByLangKeyAsync(Language.KEY_fa_IR);
            if (langFaRecord == null) {
                _repo.MarkForAdd(langFa);
                callSaveChanges = true;
            }
            else 
                langFa = langFaRecord.Adapt<Language>();

            var langEnRecord = await GetByLangKeyAsync(Language.KEY_en_US);
            if (langEnRecord == null) {
                _repo.MarkForAdd(langEn);
                callSaveChanges = true;
            }

            if(callSaveChanges)
                await _repo.SaveChangesAsync();

            return await Task.FromResult(langFa.Adapt<LanguageResultDto>());
        }

        public async Task<LanguageResultDto> GetByLangKeyAsync(string langKey) {
            var language = await _repo.GetByLangKeyAsync(langKey);
            return language != null 
                ? await Task.FromResult(language.Adapt<LanguageResultDto>()) 
                : null;
        }


    }
}
