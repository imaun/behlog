using Behlog.Core.Contracts;
using Behlog.Core.Models.System;
using Behlog.Core.Contracts.Repository.System;
using System.Threading.Tasks;

namespace Behlog.Repository.System {
    public class CurrencyRepository: BaseRepository<Currency, int>, ICurrencyRepository {

        public CurrencyRepository(IBehlogContext context): base(context) {  }

        public async Task<Currency> GetBaseCurrencyAsync()
            => await FirstOrDefaultAsync(_ => _.IsBase);
    }
}
