using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Models.System;

namespace Behlog.Core.Contracts.Repository.System
{
    public interface ILanguageRepository: IBaseRepository<Language, int> {
        Task<IEnumerable<Language>> GetAllEnabledAsync();
        Task<Language> GetByLangKeyAsync(string langKey);
        Task<Language> GetDefaultLanguage();
    }
}
