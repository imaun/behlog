using System;
using Behlog.Core.Contracts.Services.Common;

namespace Behlog.Core.Services
{
    public class DateService : IDateService
    {
        public DateTime UtcNow() => DateTime.UtcNow;

        public DateTime Now() => DateTime.Now;
    }
}
