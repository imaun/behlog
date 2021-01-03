using Behlog.Core.Contracts;
using Behlog.Core.Models.System;
using Behlog.Core.Contracts.Repository.System;

namespace Behlog.Repository.System {
    public class CurrencyRepository: BaseRepository<Currency, int>, ICurrencyRepository {

        public CurrencyRepository(IBehlogContext context): base(context) {  }
    }
}
