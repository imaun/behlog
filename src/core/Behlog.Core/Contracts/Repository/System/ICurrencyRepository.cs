using Behlog.Core.Models.System;
using System.Threading.Tasks;

namespace Behlog.Core.Contracts.Repository.System {
    public interface ICurrencyRepository: IBaseRepository<Currency, int> {
        
        Task<Currency> GetBaseCurrencyAsync();
    }
}
