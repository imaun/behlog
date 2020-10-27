using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Microsoft.EntityFrameworkCore;

namespace Behlog.Repository.System
{
    public class LanguageRepository: BaseRepository<Language, int>, ILanguageRepository
    {
        public LanguageRepository(IBehlogContext context) : base(context) {
        }

        public async Task<IEnumerable<Language>> GetAllEnabledAsync() {
            return await _dbSet
                .Where(_ => _.Status == EntityStatus.Enabled)
                .ToListAsync();
        }

        public async Task<Language> GetByLangKeyAsync(string langKey) => await 
            SingleOrDefaultAsync(_ => _.LangKey.ToLower() == langKey.ToLower() 
                                      && _.Status == EntityStatus.Enabled);

        public async Task<Language> GetDefaultLanguage() => await
            SingleOrDefaultAsync(_ => _.LangKey.ToLower() == Language.KEY_fa_IR);

    }
}
