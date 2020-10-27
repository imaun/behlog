using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Models.System;
using Behlog.Services.Dto.System;

namespace Behlog.Services.Contracts.System
{
    public interface ILanguageService {
        Task<LanguageResultDto> FindAsync(int id);
        Task<IList<LanguageResultDto>> GetAllAsync();
        Task<LanguageResultDto> CreateDefaultLanguagesAndReturnDefaultLanguageAsync();
        Task<LanguageResultDto> GetByLangKeyAsync(string langKey);
    }
}
