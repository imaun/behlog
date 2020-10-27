using System;

namespace Behlog.Core.Contracts.Services.Common
{
    public interface IDateService {
        public DateTime UtcNow();
        public DateTime Now();
    }
}
